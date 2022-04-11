﻿using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Api
{
    /// <summary>
    /// Represents the API to interact with the calculator endpoint.
    /// </summary>
    public class CalculatorApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CalculatorApi" /> class
        /// with the flag to enable the sandbox environment, the credentials factory and the HTTP client factory.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessTokenFactory">The factory to create the access token.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public CalculatorApi(bool isSandbox = false, Func<string> accessTokenFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/calculator", isSandbox, accessTokenFactory, httpClientFactory)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Calculates the tariffs.
        /// </summary>
        /// <param name="request">The request to calculate the tariffs.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CalculatorResponse"/>.</returns>
        public virtual Task<ApiResponse<CalculatorResponse>> CalculateAsync(CalculatorRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return CallAsync<CalculatorResponse>(new RequestContext(HttpMethod.Post).WithBody(request));
        }

        #endregion Methods
    }
}