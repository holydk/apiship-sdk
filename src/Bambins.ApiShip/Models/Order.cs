using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a order data container model.
    /// </summary>
    public class Order
    {
        #region Properties

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public Cost Cost { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("order")]
        public OrderData Data { get; set; }

        /// <summary>
        /// Gets or sets the extra params.
        /// </summary>
        public KeyValuePair<string, string>[] ExtraParams { get; set; }

        /// <summary>
        /// Gets or sets the places.
        /// </summary>
        public OrderPlace[] Places { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        public OrderAddress Recipient { get; set; }

        /// <summary>
        /// Gets or sets the return address.
        /// </summary>
        public OrderAddress ReturnAddress { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        public OrderAddress Sender { get; set; }

        #endregion Properties
    }
}