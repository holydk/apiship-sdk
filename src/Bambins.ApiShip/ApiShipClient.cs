using Bambins.ApiShip.Api;
using Bambins.ApiShip.Client;
using System;
using System.Net.Http;

namespace Bambins.ApiShip
{
    /// <summary>
    /// Represents the API to interact with the ApiShip endpoints.
    /// </summary>
    public class ApiShipClient
    {
        #region Fields

        private readonly Lazy<CalculatorApi> _calculatorApi;
        private readonly Lazy<ListsApi> _listsApi;
        private readonly Lazy<OrdersApi> _ordersApi;
        private readonly Lazy<UsersApi> _usersApi;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CalculatorApi"/>.
        /// </summary>
        public CalculatorApi Calculator => _calculatorApi.Value;

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        public HttpClient Client { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ListsApi"/>.
        /// </summary>
        public ListsApi Lists => _listsApi.Value;

        /// <summary>
        /// Gets or sets the <see cref="OrdersApi"/>.
        /// </summary>
        public OrdersApi Orders => _ordersApi.Value;

        /// <summary>
        /// Gets or sets the <see cref="UsersApi"/>.
        /// </summary>
        public UsersApi Users => _usersApi.Value;

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiShipClient" /> class
        /// with the access token and the HTTP client.
        /// </summary>
        /// <param name="accessToken">The access token (optional).</param>
        /// <param name="httpClient">The HTTP client (optional; if null, uses default).</param>
        public ApiShipClient(string accessToken = null, HttpClient httpClient = null)
        {
            AccessToken = accessToken;
            Client = httpClient ?? new HttpClient();

            if (!Client.DefaultRequestHeaders.Contains("UserAgent"))
                Client.DefaultRequestHeaders.Add("UserAgent", ApiDefaults.DEFAULT_USER_AGENT);

            if (!Client.DefaultRequestHeaders.Contains("Accept"))
                Client.DefaultRequestHeaders.Add("Accept", "*/*");

            _calculatorApi = new Lazy<CalculatorApi>(CreateApi<CalculatorApi>);
            _listsApi = new Lazy<ListsApi>(CreateApi<ListsApi>);
            _ordersApi = new Lazy<OrdersApi>(CreateApi<OrdersApi>);
            _usersApi = new Lazy<UsersApi>(CreateApi<UsersApi>);
        }

        #endregion Ctor

        #region Utilities

        private TApi CreateApi<TApi>() where TApi : ApiAccessor
        {
            return (TApi)Activator.CreateInstance(
                typeof(TApi), new object[] { (Func<string>)(() => AccessToken), (Func<HttpClient>)(() => Client) });
        }

        #endregion Utilities
    }
}