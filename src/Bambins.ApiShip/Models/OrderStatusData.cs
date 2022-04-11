using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the status data of the order.
    /// </summary>
    public class OrderStatusData : OrderStatusDefinition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date and time when this status was set.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the date the status was created in the delivery service system.
        /// </summary>
        public string CreatedProvider { get; set; }

        /// <summary>
        /// Gets or sets the Error code. Example: 100 - error in ApiShip; 200 - error in SD; 300 - client error (incorrect data).
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the status code in the delivery service system.
        /// </summary>
        public string ProviderCode { get; set; }

        /// <summary>
        /// Gets or sets the description of the status in the delivery service system.
        /// </summary>
        public string ProviderDescription { get; set; }

        /// <summary>
        /// Gets or sets the status name in the delivery service system.
        /// </summary>
        public string ProviderName { get; set; }

        #endregion Properties
    }
}