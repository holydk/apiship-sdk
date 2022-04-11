using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a create order response model.
    /// </summary>
    public class CreateOrderResponse : OrderResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date and time when the order was created.
        /// </summary>
        public DateTime Created { get; set; }

        #endregion Properties
    }
}