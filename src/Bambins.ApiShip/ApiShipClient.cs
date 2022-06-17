using Bambins.ApiShip.Api;
using Bambins.ApiShip.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Bambins.ApiShip
{
    /// <summary>
    /// Represents the API to interact with the ApiShip endpoints.
    /// </summary>
    public class ApiShipClient
    {
        #region Fields

        private readonly IDictionary<string, Lazy<ApiAccessor>> apiAccessors;
        private string _accessToken;
        private HttpClient _client;
        private bool _isSandbox;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken
        {
            get => _accessToken;
            set
            {
                _accessToken = value;
                ConfigureAllActiveApi(api => api.AccessToken = value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        public HttpClient Client
        {
            get => _client;
            set
            {
                _client = value;
                ConfigureAllActiveApi(api => api.Client = value);
            }
        }

        /// <summary>
        /// Gets the value indicating whether to enable the sandbox environment.
        /// </summary>
        public bool IsSandbox
        {
            get => _isSandbox;
            set
            {
                _isSandbox = value;
                ConfigureAllActiveApi(api => api.IsSandbox = value);
            }
        }

        #region APIs

        /// <summary>
        /// Gets or sets the <see cref="CalculatorApi"/>.
        /// </summary>
        public CalculatorApi Calculator => GetApi<CalculatorApi>();

        /// <summary>
        /// Gets or sets the <see cref="ListsApi"/>.
        /// </summary>
        public ListsApi Lists => GetApi<ListsApi>();

        /// <summary>
        /// Gets or sets the <see cref="OrdersApi"/>.
        /// </summary>
        public OrdersApi Orders => GetApi<OrdersApi>();

        /// <summary>
        /// Gets or sets the <see cref="UsersApi"/>.
        /// </summary>
        public UsersApi Users => GetApi<UsersApi>();

        #endregion APIs

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiShipClient" /> class
        /// with the access token and the HTTP client.
        /// </summary>
        /// <param name="accessToken">The access token (optional).</param>
        /// <param name="httpClient">The HTTP client (optional; if null, uses default).</param>
        public ApiShipClient(string accessToken = null, HttpClient httpClient = null)
            : this(false, accessToken, httpClient)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ApiShipClient" /> class
        /// with the flag to enable the sandbox environment, the access token and the HTTP client.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessToken">The access token (optional).</param>
        /// <param name="httpClient">The HTTP client (optional; if null, uses default).</param>
        public ApiShipClient(bool isSandbox, string accessToken = null, HttpClient httpClient = null)
        {
            _isSandbox = isSandbox;
            _accessToken = accessToken;
            _client = httpClient ?? new HttpClient();

            apiAccessors = new Dictionary<string, Lazy<ApiAccessor>>
            {
                { GetApiKey<CalculatorApi>(), CreateApi<CalculatorApi>() },
                { GetApiKey<ListsApi>(), CreateApi<ListsApi>() },
                { GetApiKey<OrdersApi>(), CreateApi<OrdersApi>() },
                { GetApiKey<UsersApi>(), CreateApi<UsersApi>() },
            };
        }

        #endregion Ctor

        #region Utilities

        private void ConfigureAllActiveApi(Action<ApiAccessor> action)
        {
            foreach (var accessor in apiAccessors)
            {
                if (accessor.Value.IsValueCreated)
                    action(accessor.Value.Value);
            }
        }

        private Lazy<ApiAccessor> CreateApi<TApi>() where TApi : ApiAccessor
        {
            Func<ApiAccessor> factory = () => (TApi)Activator.CreateInstance(
                typeof(TApi), new object[] { _isSandbox, _accessToken, _client });

            return new Lazy<ApiAccessor>(factory);
        }

        private TApi GetApi<TApi>() where TApi : ApiAccessor
        {
            return (TApi)apiAccessors[GetApiKey<TApi>()].Value;
        }

        private string GetApiKey<TApi>() where TApi : ApiAccessor
        {
            var apiName = typeof(TApi).Name;
            return apiName.Remove(apiName.IndexOf("Api"));
        }

        #endregion Utilities
    }
}