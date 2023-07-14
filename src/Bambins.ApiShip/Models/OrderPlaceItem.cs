namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents the order place item model.
    /// </summary>
    public class OrderPlaceItem : Sizes
    {
        #region Properties

        /// <summary>
        /// Gets or sets the articul.
        /// </summary>
        public string Articul { get; set; }

        /// <summary>
        /// Gets or sets the estimated cost of a unit of goods (in rubles).
        /// </summary>
        public decimal? AssessedCost { get; set; }

        /// <summary>
        /// Gets or sets the Barcode on the product.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the INN of the supplier / seller of goods.
        /// </summary>
        public string CompanyInn { get; set; }

        /// <summary>
        /// Gets or sets the name of the company supplier / seller of goods.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the cash on delivery amount, including VAT (in rubles).
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Gets or sets the VAT percentage.
        /// </summary>
        public OrderVatType? CostVat { get; set; }

        /// <summary>
        /// Gets or sets the name of product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the marking code (UTF-8).
        /// </summary>
        public string MarkCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity of goods. If <see cref="MarkCode"/> is specified, count cannot be > 1.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the not redeemed quantity. It is filled only with partial delivery and shows how many units of the product were redeemed.
        /// </summary>
        public int? QuantityDelivered { get; set; }

        #endregion Properties
    }
}