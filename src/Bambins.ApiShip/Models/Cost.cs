namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a cost.
    /// </summary>
    public class Cost
    {
        #region Properties

        /// <summary>
        /// Gets or sets the estimated cost / amount of insurance (in rubles).
        /// </summary>
        public decimal? AssessedCost { get; set; }

        /// <summary>
        /// Gets or sets the cash on delivery amount including VAT (in rubles).
        /// </summary>
        public decimal? CodCost { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost from the recipient including VAT (in rubles). <see cref="CodCost"/> must contain this amount.
        /// </summary>
        public decimal? DeliveryCost { get; set; }

        /// <summary>
        /// Gets or sets the VAT percentage.
        /// </summary>
        public OrderVatType? DeliveryCostVat { get; set; }

        /// <summary>
        /// Gets or sets the flag to indicate the person that pays for delivery services (0-sender, 1-receiver)
        /// </summary>
        public bool? IsDeliveryPayedByRecipient { get; set; }

        #endregion Properties
    }
}