namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model that contains information about orders with statuses.
    /// </summary>
    public class OrderStatusesResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the failed orders.
        /// </summary>
        public ErrorOrderInfo[] FailedOrders { get; set; }

        /// <summary>
        /// Gets or sets the succeed orders.
        /// </summary>
        public OrderStatus[] SucceedOrders { get; set; }

        #endregion Properties
    }
}