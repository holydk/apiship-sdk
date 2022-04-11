namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a create sync order response model.
    /// </summary>
    public class CreateSyncOrderResponse : CreateOrderResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the additional order number in the delivery service system.
        /// </summary>
        public string AdditionalProviderNumber { get; set; }

        /// <summary>
        /// Gets or sets the order number in the delivery service system.
        /// </summary>
        public string ProviderNumber { get; set; }

        #endregion Properties
    }
}