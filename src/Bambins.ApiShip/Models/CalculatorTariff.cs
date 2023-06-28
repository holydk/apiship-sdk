namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a calculator tariff model.
    /// </summary>
    public class CalculatorTariff
    {
        #region Properties

        /// <summary>
        /// Gets or sets the amount of fees for cash on delivery. NULL if not possible to determine.
        /// </summary>
        public decimal? CashServiceFee { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of delivery days.
        /// </summary>
        public int? DaysMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of delivery days.
        /// </summary>
        public int? DaysMin { get; set; }

        /// <summary>
        /// Gets or sets the tariff cost.
        /// </summary>
        public decimal? DeliveryCost { get; set; }

        /// <summary>
        /// Gets or sets the delivery types (see /lists/deliveryTypes), if not passed, both types are taken.
        /// </summary>
        public int[] DeliveryTypes { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the delivery service charges were included in the total cost (<see cref="DeliveryCost"/>). NULL if not possible to determine.
        /// </summary>
        public bool? FeesIncluded { get; set; }

        /// <summary>
        /// Gets or sets the amount of insurance fees. NULL if not possible to determine.
        /// </summary>
        public decimal? InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the pickup types, if not passed, both types are taken.
        /// </summary>
        public int[] PickupTypes { get; set; }

        /// <summary>
        /// Gets or sets the tariff ID in ApiShip.
        /// </summary>
        public string TariffId { get; set; }

        /// <summary>
        /// Gets or sets the tariff name.
        /// </summary>
        public string TariffName { get; set; }

        /// <summary>
        /// Gets or sets the tariff ID in the delivery service.
        /// </summary>
        public string TariffProviderId { get; set; }

        #endregion Properties
    }
}