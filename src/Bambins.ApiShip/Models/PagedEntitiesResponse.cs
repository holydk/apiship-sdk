namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a response model with paginable entities.
    /// </summary>
    public class PagedEntitiesResponse<TEntity>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        public PagedMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        public TEntity[] Rows { get; set; }

        #endregion Properties
    }
}