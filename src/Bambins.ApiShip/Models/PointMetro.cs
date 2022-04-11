namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a metro description for <see cref="Point"/>.
    /// </summary>
    public class PointMetro
    {
        #region Properties

        /// <summary>
        /// Gets or sets the distance to metro in km.
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Gets or sets the metro line.
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Gets or sets the metro name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}