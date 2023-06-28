using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Api
{
    /// <summary>
    /// Represents the API to interact with the lists endpoint.
    /// </summary>
    public class ListsApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ListsApi" /> class
        /// with the flag to enable the sandbox environment,
        /// the access token and the HTTP client.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ListsApi(bool isSandbox = false, string accessToken = null, HttpClient httpClient = null)
            : base(string.Empty, isSandbox, accessToken, httpClient)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the delivery types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with array <see cref="DeliveryType"/>.</returns>
        public virtual Task<ApiResponse<DeliveryType[]>> GetDeliveryTypesAsync()
        {
            return CallAsync<DeliveryType[]>(new RequestContext("/lists/deliveryTypes"));
        }

        /// <summary>
        /// Gets the pickup types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with array <see cref="PickupType"/>.</returns>
        public virtual Task<ApiResponse<PickupType[]>> GetPickupTypesAsync()
        {
            return CallAsync<PickupType[]>(new RequestContext("/lists/pickupTypes"));
        }

        /// <summary>
        /// Gets the pickup points.
        /// </summary>
        /// <param name="limit">The page limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="filter">The filter. Filtering by fields key, name is possible.</param>
        /// <param name="fields">The list of output fields, if not specified, all fields are returned.</param>
        /// <param name="stateCheckOff">If true, pickup points are also given for which the location address is not specified.</param>
        /// <returns>The <see cref="Task"/> containing the API response with paged <see cref="Point"/>.</returns>
        public virtual Task<ApiResponse<PagedEntitiesResponse<Point>>> GetPointsAsync(int? limit = null, int? offset = null, string filter = "", string fields = "", bool? stateCheckOff = null)
        {
            var requestContext = new RequestContext("/lists/points");

            if (limit.HasValue)
                requestContext.WithQuery("limit", limit.Value.ToString());

            if (offset.HasValue)
                requestContext.WithQuery("offset", offset.Value.ToString());

            if (!string.IsNullOrEmpty(filter))
                requestContext.WithQuery("filter", filter.ToString());

            if (!string.IsNullOrEmpty(fields))
                requestContext.WithQuery("fields", fields.ToString());

            if (stateCheckOff.HasValue)
                requestContext.WithQuery("stateCheckOff", stateCheckOff.Value.ToString());

            return CallAsync<PagedEntitiesResponse<Point>>(requestContext);
        }

        /// <summary>
        /// Gets the delivery types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with array <see cref="PointType"/>.</returns>
        public virtual Task<ApiResponse<PointType[]>> GetPointTypesAsync()
        {
            return CallAsync<PointType[]>(new RequestContext("/lists/pointTypes"));
        }

        /// <summary>
        /// Gets the delivery providers.
        /// </summary>
        /// <param name="limit">The page limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="filter">The filter. Filtering by fields key, name is possible.</param>
        /// <param name="fields">The list of output fields, if not specified, all fields are returned.</param>
        /// <returns>The <see cref="Task"/> containing the API response with paged <see cref="ProviderDefinition"/>.</returns>
        public virtual Task<ApiResponse<PagedEntitiesResponse<ProviderDefinition>>> GetProvidersAsync(int? limit = null, int? offset = null, string filter = "", string fields = "")
        {
            var requestContext = new RequestContext("/lists/providers");

            if (limit.HasValue)
                requestContext.WithQuery("limit", limit.Value.ToString());

            if (offset.HasValue)
                requestContext.WithQuery("offset", offset.Value.ToString());

            if (!string.IsNullOrEmpty(filter))
                requestContext.WithQuery("filter", filter.ToString());

            if (!string.IsNullOrEmpty(fields))
                requestContext.WithQuery("fields", fields.ToString());

            return CallAsync<PagedEntitiesResponse<ProviderDefinition>>(requestContext);
        }

        /// <summary>
        /// Gets the order statuses.
        /// </summary>
        /// <param name="limit">The page limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="filter">The filter. Filtering by fields key, name is possible.</param>
        /// <param name="fields">The list of output fields, if not specified, all fields are returned.</param>
        /// <returns>The <see cref="Task"/> containing the API response with paged <see cref="OrderStatusDefinition"/>.</returns>
        public virtual Task<ApiResponse<PagedEntitiesResponse<OrderStatusDefinition>>> GetStatusesAsync(int? limit = null, int? offset = null, string filter = "", string fields = "")
        {
            var requestContext = new RequestContext("/lists/statuses");

            if (limit.HasValue)
                requestContext.WithQuery("limit", limit.Value.ToString());

            if (offset.HasValue)
                requestContext.WithQuery("offset", offset.Value.ToString());

            if (!string.IsNullOrEmpty(filter))
                requestContext.WithQuery("filter", filter.ToString());

            if (!string.IsNullOrEmpty(fields))
                requestContext.WithQuery("fields", fields.ToString());

            return CallAsync<PagedEntitiesResponse<OrderStatusDefinition>>(requestContext);
        }

        /// <summary>
        /// Gets the tariffs.
        /// </summary>
        /// <param name="limit">The page limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="filter">The filter. Filtering by fields id, providerKey, name is possible.</param>
        /// <param name="fields">The list of output fields, if not specified, all fields are returned.</param>
        /// <returns>The <see cref="Task"/> containing the API response with paged <see cref="Tariff"/>.</returns>
        public virtual Task<ApiResponse<PagedEntitiesResponse<Tariff>>> GetTariffsAsync(int? limit = null, int? offset = null, string filter = "", string fields = "")
        {
            var requestContext = new RequestContext("/lists/tariffs");

            if (limit.HasValue)
                requestContext.WithQuery("limit", limit.Value.ToString());

            if (offset.HasValue)
                requestContext.WithQuery("offset", offset.Value.ToString());

            if (!string.IsNullOrEmpty(filter))
                requestContext.WithQuery("filter", filter.ToString());

            if (!string.IsNullOrEmpty(fields))
                requestContext.WithQuery("fields", fields.ToString());

            return CallAsync<PagedEntitiesResponse<Tariff>>(requestContext);
        }

        #endregion Methods
    }
}