using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a cancel order response model.
    /// </summary>
    public class CancelOrderResponse : OrderResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date and time when the order was canceled.
        /// </summary>
        public DateTime Canceled { get; set; }

        #endregion Properties
    }
}