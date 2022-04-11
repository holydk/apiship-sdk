using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a delete order response model.
    /// </summary>
    public class DeleteOrderResponse : OrderResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date and time when the order was deleted.
        /// </summary>
        public DateTime Deleted { get; set; }

        #endregion Properties
    }
}