namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the tariffs to point.
    /// </summary>
    public class CalculatorToPointResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the tariffs to point.
        /// </summary>
        public CalculatorToPointTariff[] Tariffs { get; set; }

        #endregion Properties
    }
}