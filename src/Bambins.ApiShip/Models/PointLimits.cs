namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a limits for <see cref="Point"/>.
    /// </summary>
    public class PointLimits
    {
        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of cash on delivery in rubles.
        /// </summary>
        public decimal? MaxCod { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of side A in cm.
        /// </summary>
        public int? MaxSizeA { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of side B in cm.
        /// </summary>
        public int? MaxSizeB { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of side C in cm.
        /// </summary>
        public int? MaxSizeC { get; set; }

        /// <summary>
        /// Gets or sets the maximum sum of lengths of all sides in cm.
        /// </summary>
        public int? MaxSizeSum { get; set; }

        /// <summary>
        /// Gets or sets the maximum volume in cm3.
        /// </summary>
        public int? MaxVolume { get; set; }

        /// <summary>
        /// Gets or sets the minimum weight in gramm.
        /// </summary>
        public int? MaxWeight { get; set; }

        /// <summary>
        /// Gets or sets the
        /// </summary>
        public int? MinWeight { get; set; }

        #endregion Properties
    }
}