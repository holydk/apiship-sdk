namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a address model for order.
    /// </summary>
    public class OrderAddress : Address
    {
        #region Properties

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the building.
        /// </summary>
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets the brand name.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the company INN.
        /// </summary>
        public string CompanyInn { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the name of contact person.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the email of contact person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the office / apartment.
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// Gets or sets the phone number of contact person.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string PostIndex { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }

        #endregion Properties
    }
}