namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents the order place model.
    /// </summary>
    public class OrderPlace : Sizes
    {
        #region Properties

        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public OrderPlaceItem[] Items { get; set; }

        /// <summary>
        /// Gets or sets the place number in the customer's information system.
        /// </summary>
        public string PlaceNumber { get; set; }

        #endregion Properties
    }
}