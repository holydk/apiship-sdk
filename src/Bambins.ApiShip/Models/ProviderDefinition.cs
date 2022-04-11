namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a delivery provider definition.
    /// </summary>
    public class ProviderDefinition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}