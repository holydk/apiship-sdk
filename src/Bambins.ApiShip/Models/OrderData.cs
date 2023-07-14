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
        /// Gets or sets the order number for barcode printing. If an order is sent with an indication of places (Place), then the barcode must be specified in the <see cref="OrderPlace.Barcode"/> parameter.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the order number in the customer's system. Can be reused if the order is canceled or deleted.
        /// </summary>
        public string ClientNumber { get; set; }

        /// <summary>
        /// Gets or sets the expected delivery date.
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the end time for order delivery (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 18:00).
        /// </summary>
        public string DeliveryTimeEnd { get; set; }

        /// <summary>
        /// Gets or sets the start time for order delivery (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 09:00).
        /// </summary>
        public string DeliveryTimeStart { get; set; }

        /// <summary>
        /// Gets or sets the delivery type (1 - to the door, 2 - to the pickup point).
        /// </summary>
        public int DeliveryType { get; set; }

        /// <summary>
        /// Gets or sets the order description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the planned date of transfer of the order to the delivery service (courier call).
        /// </summary>
        public DateTime? PickupDate { get; set; }

        /// <summary>
        /// Gets or sets the end time for order transfer (courier call) (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 18:00).
        /// </summary>
        public string PickupTimeEnd { get; set; }

        /// <summary>
        /// Gets or sets the start time for order transfer (courier call) (pattern: ^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$, example: 09:00).
        /// </summary>
        public string PickupTimeStart { get; set; }

        /// <summary>
        /// Gets or sets the pickup type (1 - from the door, 2 - from the pickup point).
        /// </summary>
        public int PickupType { get; set; }

        /// <summary>
        /// Gets or sets the point ID to send the order. Mandatory if shipment to the warehouse of the delivery service.
        /// </summary>
        public int? PointInId { get; set; }

        /// <summary>
        /// Gets or sets the point ID to receive the order. Mandatory if delivery to the pickup point.
        /// </summary>
        public int? PointOutId { get; set; }

        /// <summary>
        /// Gets or sets the connection ID of your company to the delivery service. It is used when several contracts from the same delivery service are connected to one ApiShip account.
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