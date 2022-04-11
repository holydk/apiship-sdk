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
        /// with the flag to enable the sandbox environment,
        /// the access token and the HTTP client.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public UsersApi(bool isSandbox = false, string accessToken = null, HttpClient httpClient = null)
            : base(string.Empty, isSandbox, accessToken, httpClient)
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