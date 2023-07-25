namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the order information with status history.
    /// </summary>
    public class OrderStatusHistory : PagedEntitiesResponse<OrderStatusData>
    {
        #region Properties

        /// <summary>
        /// Gets or sets order info.
        /// </summary>
        public OrderInfo OrderInfo { get; set; }

        #endregion Properties
    }
}