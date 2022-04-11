namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the order information with status.
    /// </summary>
    public class OrderStatus
    {
        #region Properties

        /// <summary>
        /// Gets or sets order info.
        /// </summary>
        public OrderInfo OrderInfo { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public OrderStatusData Status { get; set; }

        #endregion Properties
    }
}