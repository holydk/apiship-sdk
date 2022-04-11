namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a request model to get the order statuses.
    /// </summary>
    public class OrderStatusesRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the order IDs
        /// </summary>
        public int[] OrderIds { get; set; }

        #endregion Properties
    }
}