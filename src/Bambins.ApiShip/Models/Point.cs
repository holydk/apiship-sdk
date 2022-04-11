using System.Collections.Generic;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a pickup point.
    /// </summary>
    public class Point
    {
        #region Properties

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the operation type (1 - receiving, 2 - issuing, 3 - receiving and issuing).
        /// </summary>
        public int? AvailableOperation { get; set; }

        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the FIAS code of the city or settlement in the fias.nalog.ru database.
        /// </summary>
        public string CityGuid { get; set; }

        /// <summary>
        /// Gets or sets the city type.
        /// </summary>
        public string CityType { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to possible to pay on delivery (null - no data, 1 - payment available, 0 - payment not available).
        /// </summary>
        public int? Cod { get; set; }

        /// <summary>
        /// Gets or sets the terminal code in the delivery service system.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the community.
        /// </summary>
        public string Community { get; set; }

        /// <summary>
        /// Gets or sets the FIAS code of the community.
        /// </summary>
        public string CommunityGuid { get; set; }

        /// <summary>
        /// Gets or sets the type of the community.
        /// </summary>
        public string CommunityType { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the description of the pickup point, how to get there.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the additional options for the service.
        /// </summary>
        public Dictionary<string, string> Extra { get; set; }

        /// <summary>
        /// Gets or sets the presence of a fitting room.
        /// </summary>
        public int? FittingRoom { get; set; }

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public decimal? Lat { get; set; }

        /// <summary>
        /// Gets or sets limits.
        /// </summary>
        public PointLimits Limits { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public decimal? Lng { get; set; }

        /// <summary>
        /// Gets or sets the list of nearest metro stations (up to three).
        /// </summary>
        public List<PointMetro> Metro { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to possible to issue multiple items (null - no data, 1 - issue is possible, 0 - issue is not possible).
        /// </summary>
        public int? MultiplaceDeliveryAllowed { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to possible to pay by bank card (null - no data, 1 - card payment is available, 0 - card payment is not available).
        /// </summary>
        public int? PaymentCard { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to possible to pay in cash (null - no data, 1 - cash payment available, 0 - cash payment not available).
        /// </summary>
        public int? PaymentCash { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets photos (links).
        /// </summary>
        public List<string> Photos { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string PostIndex { get; set; }

        /// <summary>
        /// Gets or sets the delivery service ID.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the region type.
        /// </summary>
        public string RegionType { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street type.
        /// </summary>
        public string StreetType { get; set; }

        /// <summary>
        /// Gets or sets the timetable.
        /// </summary>
        public string Timetable { get; set; }

        /// <summary>
        /// Gets or sets the type of point (1 - Point of issue of the order, 2 - Postamat, 3 - Department of the Russian Post, 4 - Terminal)
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Gets or sets the home page.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the working hours by days (1 - Mon; 7 - Sun). Absence of a day means a day off.
        /// </summary>
        public Dictionary<string, string> Worktime { get; set; }

        #endregion Properties
    }
}