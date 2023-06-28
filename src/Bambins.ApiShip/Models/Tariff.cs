namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a tariff model.
    /// </summary>
    public class Tariff
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alternative name.
        /// </summary>
        public string AliasName { get; set; }

        /// <summary>
        /// Gets or sets the delivery type (1 - to the door, 2 - to the pickup point, null - both options are available).
        /// </summary>
        public int? DeliveryType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID in ApiShip.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the shipment acceptance type (1 - from the door, 2 - from the pickup point, null - both options are available).
        /// </summary>
        public int? PickupType { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the maximum weight limit for fare (grams).
        /// </summary>
        public int? WeightMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum weight limit for fare (grams).
        /// </summary>
        public int? WeightMin { get; set; }

        #endregion Properties
    }
}