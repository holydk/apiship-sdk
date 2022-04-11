namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a order status definition.
    /// </summary>
    public class OrderStatusDefinition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the order status ID.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the status name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}