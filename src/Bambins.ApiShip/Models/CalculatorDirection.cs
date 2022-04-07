namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model for determining the direction of the tariffs calculation.
    /// </summary>
    public class CalculatorDirection
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
        /// Gets or sets the postcode
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Gets or sets the latitude. Be sure to indicate if this is a taxi delivery, for example, Yandex.Delivery, Gett, etc.
        /// </summary>
        public decimal? Lat { get; set; }

        /// <summary>
        /// Gets or sets the longitude. Be sure to indicate if this is a taxi delivery, for example, Yandex.Delivery, Gett, etc.
        /// </summary>
        public decimal? Lng { get; set; }

        /// <summary>
        /// Gets or sets the region
        /// </summary>
        public string Region { get; set; }

        #endregion Properties
    }
}