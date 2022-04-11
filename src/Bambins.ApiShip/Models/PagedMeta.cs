namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a paged meta.
    /// </summary>
    public class PagedMeta
    {
        #region Properties

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public int Total { get; set; }

        #endregion Properties
    }
}