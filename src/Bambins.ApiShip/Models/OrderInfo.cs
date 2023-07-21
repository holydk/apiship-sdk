namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the information about order.
    /// </summary>
    public class OrderInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the additional order number in the delivery service system.
        /// </summary>
        public string AdditionalProviderNumber { get; set; }

        /// <summary>
        /// Gets or sets the order number for barcode printing.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the order number in the customer's system.
        /// </summary>
        public string ClientNumber { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the delivery service code.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the order number in the delivery service system.
        /// </summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// Gets or sets the order return number in the delivery service system
        /// </summary>
        public string ReturnProviderNumber { get; set; }

        #endregion Properties
    }
}