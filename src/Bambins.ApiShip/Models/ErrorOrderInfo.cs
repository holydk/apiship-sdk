namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a error order information.
    /// </summary>
    public class ErrorOrderInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public string OrderId { get; set; }

        #endregion Properties
    }
}