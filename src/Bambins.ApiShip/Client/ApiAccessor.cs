using Bambins.ApiShip.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bambins.ApiShip.Client
{
    /// <summary>
    /// Represents a abstraction to interact with the API endpoint(s).
    /// </summary>
    public abstract class ApiAccessor
    {
        #region Fields

        private JsonSerializerSettings _defaultReadSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        };

        private JsonSerializerSettings _defaultWriteSettings = new JsonSerializerSettings
        {
            DateFormatString = ApiDefaults.DEFAULT_DATETIME_FORMAT,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = DefaultContractResolver,
        };

        internal static CamelCasePropertyNamesContractResolver DefaultContractResolver { get; } = new CamelCasePropertyNamesContractResolver();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        internal string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        internal HttpClient Client { get; set; }

        /// <summary>
        /// Gets the value indicating whether to enable the sandbox environment.
        /// </summary>
        internal bool IsSandbox { get; set; }

        /// <summary>
        /// Gets the API endpoint relative path.
        /// </summary>
        internal string Path { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiAccessor" /> class
        /// with the API endpoint relative path, the flag to enable the sandbox environment,
        /// the access token and the HTTP client.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ApiAccessor(string relativePath, bool isSandbox = false, string accessToken = null, HttpClient httpClient = null)
        {
            Path = relativePath;
            IsSandbox = isSandbox;
            AccessToken = accessToken;
            Client = httpClient;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Deserializes the model into the JSON string.
        /// </summary>
        /// <param name="obj">The model.</param>
        /// <returns>The JSON string.</returns>
        internal virtual string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj, _defaultWriteSettings) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected virtual async Task<ApiResponse<TResponse>> CallAsync<TResponse>(RequestContext context, [CallerMemberName] string callerName = "")
        {
            using (var httpResponse = await InternalCallAsync(context, callerName))
            {
                var model = await DeserializeAsync<TResponse>(httpResponse);

                return new ApiResponse<TResponse>((int)httpResponse.StatusCode, httpResponse.Headers
                .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value)), model);
            }
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        protected virtual async Task<ApiResponse> CallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            using (var httpResponse = await InternalCallAsync(context, callerName))
            {
                return new ApiResponse((int)httpResponse.StatusCode, httpResponse.Headers
                    .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value)));
            }
        }

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="response">The HTTP response message.</param>
        /// <returns>The <see cref="Task"/> containing the parsed data.</returns>
        /// <exception cref="ArgumentNullException">Throws, if the response is null.</exception>
        /// <exception cref="ApiException">Throws, if the deserialization error has occurred.</exception>
        protected virtual async Task<TResponse> DeserializeAsync<TResponse>(HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                return await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(responseContent, _defaultReadSettings));
            }
            catch (Exception e)
            {
                throw new ApiException(500, $"Error when deserializing HTTP response content. HTTP status code - 500. {e.Message}");
            }
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the HTTP response.</returns>
        protected virtual async Task<HttpResponseMessage> InternalCallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (Client == null)
                throw new ApiException(500, $"Cannot resolve the HTTP client.");

            HttpResponseMessage response = null;

            using (var request = CreateHttpRequest(context))
            {
                if (context.Body != null)
                {
                    var serializedContent = Serialize(context.Body);
                    request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
                }

                try
                {
                    response = await Client.SendAsync(request);
                }
                catch (Exception e)
                {
                    throw new ApiException(500, $"Error when calling '{callerName}'. HTTP status code - 500. {e.Message}");
                }

                int status = (int)response.StatusCode;
                if (status >= 400)
                {
                    var errorMessage = $"Error calling '{callerName}'. HTTP status code - {status}\n";

                    ApiErrorResponse errorResponse = null;
                    if (response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                    {
                        try
                        {
                            errorResponse = await DeserializeAsync<ApiErrorResponse>(response);
                        }
                        catch (Exception) { }
                    }

                    var headers = response.Headers
                        .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value));

                    throw new ApiException(status, errorMessage, headers, errorResponse);
                }

                request.Content?.Dispose();
            }

            return response;
        }

        #endregion Methods

        #region Utilities

        private HttpRequestMessage CreateHttpRequest(RequestContext context)
        {
            var relativeUri = string.IsNullOrEmpty(context.Path) ? Path : context.Path;
            if (context.Query?.Any() == true)
            {
                var parsedQuery = HttpUtility.ParseQueryString(string.Empty);
                foreach (var keyValuePair in context.Query)
                    parsedQuery[keyValuePair.Key] = keyValuePair.Value;

                relativeUri += $"?{parsedQuery}";
            }

            var baseAddress = Client.BaseAddress == null
                ? IsSandbox
                    ? new Uri(ApiDefaults.DEFAULT_SANDBOX_BASE_PATH)
                    : new Uri(ApiDefaults.DEFAULT_PROD_BASE_PATH)
                : Client.BaseAddress;

            if (!Uri.TryCreate(baseAddress, relativeUri, out var uri))
                throw new ApiException(500, $"Cannot create the HTTP request URI.");

            var request = new HttpRequestMessage(context.Method, uri);

            if (!string.IsNullOrEmpty(AccessToken))
                request.Headers.Add("Authorization", AccessToken);

            foreach (var header in context.Headers)
                request.Headers.Add(header.Key, header.Value);

            if (!Client.DefaultRequestHeaders.Contains("UserAgent"))
                request.Headers.Add("UserAgent", ApiDefaults.DEFAULT_USER_AGENT);

            if (!Client.DefaultRequestHeaders.Contains("Accept"))
                request.Headers.Add("Accept", "*/*");

            return request;
        }

        #endregion Utilities
    }
}