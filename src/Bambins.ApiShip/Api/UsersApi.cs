using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Api
{
    /// <summary>
    /// Represents the API to interact with the Users endpoint.
    /// </summary>
    public class UsersApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="UsersApi" /> class
        /// with the flag to enable the sandbox environment, the credentials factory and the HTTP client factory.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessTokenFactory">The factory to create the access token.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public UsersApi(bool isSandbox = false, Func<string> accessTokenFactory = null, Func<HttpClient> httpClientFactory = null)
            : base(string.Empty, isSandbox, accessTokenFactory, httpClientFactory)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the access token by user credentials.
        /// </summary>
        /// <param name="request">The user credentials to get the access token.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="LoginResponse"/>.</returns>
        public virtual Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return CallAsync<LoginResponse>(new RequestContext("/users/login", HttpMethod.Post).WithBody(request));
        }

        #endregion Methods
    }
}