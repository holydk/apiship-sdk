using Bambins.ApiShip.Client;
using Bambins.ApiShip.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bambins.ApiShip.Api
{
    /// <summary>
    /// Represents the API to interact with the statuses endpoint.
    /// </summary>
    public class OrdersApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrdersApi" /> class
        /// with the flag to enable the sandbox environment,
        /// the access token and the HTTP client.
        /// </summary>
        /// <param name="isSandbox">The value indicating whether to enable the sandbox environment.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public OrdersApi(bool isSandbox = false, string accessToken = null, HttpClient httpClient = null)
            : base(string.Empty, isSandbox, accessToken, httpClient)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Attempts to delete or cancel an order from the provider's system.
        /// </summary>
        /// <param name="orderId">The ID to delete or cancel order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CancelOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<CancelOrderResponse>> CancelAsync(int orderId)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<CancelOrderResponse>(new RequestContext($"/orders/{orderId}/cancel"));
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="order">The order to create.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CreateOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<CreateOrderResponse>> CreateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return CallAsync<CreateOrderResponse>(new RequestContext($"/orders", HttpMethod.Post).WithBody(order));
        }

        /// <summary>
        /// Creates the synchronous order.
        /// </summary>
        /// <param name="order">The order to create.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CreateSyncOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<CreateSyncOrderResponse>> CreateSyncAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return CallAsync<CreateSyncOrderResponse>(new RequestContext($"/orders/sync", HttpMethod.Post).WithBody(order));
        }

        /// <summary>
        /// Deletes the order by ID.
        /// </summary>
        /// <param name="orderId">The ID to delete order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="DeleteOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<DeleteOrderResponse>> DeleteAsync(int orderId)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<DeleteOrderResponse>(new RequestContext($"/orders/{orderId}", HttpMethod.Delete));
        }

        /// <summary>
        /// Gets the order by ID.
        /// </summary>
        /// <param name="orderId">The ID to get order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Order"/>.</returns>
        public virtual Task<ApiResponse<Order>> GetAsync(int orderId)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<Order>(new RequestContext($"/orders/{orderId}"));
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="request">The request model to get the lables.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetLabelsResponse"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="request"/> is null.</exception>
        public virtual Task<ApiResponse<GetLabelsResponse>> GetLabels(GetLabelsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return CallAsync<GetLabelsResponse>(new RequestContext($"/orders/labels", HttpMethod.Post).WithBody(request));
        }

        /// <summary>
        /// Gets the order status by ID.
        /// </summary>
        /// <param name="orderId">The ID to get the order status.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="OrderStatus"/>.</returns>
        public virtual Task<ApiResponse<OrderStatus>> GetStatusAsync(int orderId)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<OrderStatus>(new RequestContext($"/orders/{orderId}/status"));
        }

        /// <summary>
        /// Gets the order status by client number.
        /// </summary>
        /// <param name="clientNumber">The client number to get the order status.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="OrderStatus"/>.</returns>
        public virtual Task<ApiResponse<OrderStatus>> GetStatusAsync(string clientNumber)
        {
            if (string.IsNullOrEmpty(clientNumber))
                throw new InvalidOperationException($"{nameof(clientNumber)} shouldn't be null or empty.");

            return CallAsync<OrderStatus>(new RequestContext($"/orders/status").WithQuery("clientNumber", clientNumber));
        }

        /// <summary>
        /// Gets the statuses of orders by IDs.
        /// </summary>
        /// <param name="request">The request to get the statuses of orders.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="OrderStatusesResponse"/>.</returns>
        public virtual Task<ApiResponse<OrderStatusesResponse>> GetStatusesAsync(OrderStatusesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return CallAsync<OrderStatusesResponse>(new RequestContext($"/orders/statuses", HttpMethod.Post).WithBody(request));
        }

        /// <summary>
        /// Resends the order to the delivery service.
        /// </summary>
        /// <param name="orderId">The ID to resend order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CreateOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<CreateOrderResponse>> ResendAsync(int orderId)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<CreateOrderResponse>(new RequestContext($"/orders/{orderId}/resend", HttpMethod.Post));
        }

        /// <summary>
        /// Updates the order by ID.
        /// </summary>
        /// <param name="orderId">The ID to update order.</param>
        /// <param name="order">The order to update.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="UpdatedOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<UpdatedOrderResponse>> UpdateAsync(int orderId, Order order)
        {
            if (orderId <= 0)
                throw new InvalidOperationException($"{nameof(orderId)} should be greater than 0.");

            return CallAsync<UpdatedOrderResponse>(new RequestContext($"/orders/{orderId}", HttpMethod.Put).WithBody(order));
        }

        /// <summary>
        /// Validates the order without sending it to the delivery service.
        /// </summary>
        /// <param name="order">The order to validate.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="ValidateOrderResponse"/>.</returns>
        public virtual Task<ApiResponse<ValidateOrderResponse>> ValidateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return CallAsync<ValidateOrderResponse>(new RequestContext($"/orders/validate", HttpMethod.Post).WithBody(order));
        }

        #endregion Methods
    }
}