namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a address.
    /// </summary>
    public class Address
    {
        #region Properties

        /// <summary>
        /// Gets or sets the full postal address. If filled, it is considered a priority, if <see cref="CityGuid"/> is not specified
        /// </summary>
        public string AddressString { get; set; }

        /// <summary>
        /// Gets or sets the City name (required if <see cref="CityGuid"/> is not filled in)
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the FIAS code of the city or settlement in the fias.nalog.ru database (required if <see cref="City"/> is not filled in)
        /// </summary>
        public string CityGuid { get; set; }

        /// <summary>
        /// Gets or sets the country code according to ISO 3166-1 alpha-2
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public decimal? Lat { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public decimal? Lng { get; set; }

        /// <summary>
        /// Gets or sets the region
        /// </summary>
        public string Region { get; set; }

        #endregion Properties
    }
}