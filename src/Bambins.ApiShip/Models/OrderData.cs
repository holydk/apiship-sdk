using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a order data.
    /// </summary>
    public class OrderData : Sizes
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
        /// Gets or sets the delivery date.
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the delivery end time (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 18:00).
        /// </summary>
        public string DeliveryTimeEnd { get; set; }

        /// <summary>
        /// Gets or sets the start delivery time (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 09:00).
        /// </summary>
        public string DeliveryTimeStart { get; set; }

        /// <summary>
        /// Gets or sets the delivery type.
        /// </summary>
        public int DeliveryType { get; set; }

        /// <summary>
        /// Gets or sets the order description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the estimated date of transfer of the goods to the delivery service.
        /// </summary>
        public DateTime? PickupDate { get; set; }

        /// <summary>
        /// Gets or sets the pickup end time (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 18:00).
        /// </summary>
        public string PickupTimeEnd { get; set; }

        /// <summary>
        /// Gets or sets the start pickup time (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 09:00).
        /// </summary>
        public string PickupTimeStart { get; set; }

        /// <summary>
        /// Gets or sets the pickup type.
        /// </summary>
        public int PickupType { get; set; }

        /// <summary>
        /// Gets or sets the point ID to send the order.
        /// </summary>
        public int? PointInId { get; set; }

        /// <summary>
        /// Gets or sets the point ID to receive the order.
        /// </summary>
        public int? PointOutId { get; set; }

        /// <summary>
        /// Gets or sets the ID of connection of your company to SD.
        /// </summary>
        public string ProviderConnectId { get; set; }

        /// <summary>
        /// Gets or sets the delivery service code.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the order number in the delivery service system.
        /// </summary>
        public string ProviderNumber { get; set; }

        /// <summary>
        /// Gets or sets the tariff ID in ApiShip.
        /// </summary>
        public int TariffId { get; set; }

        #endregion Properties
    }
}