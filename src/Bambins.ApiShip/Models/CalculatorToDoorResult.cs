namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the tariffs to door.
    /// </summary>
    public class CalculatorToDoorResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the tariffs to door.
        /// </summary>
        public CalculatorTariff[] Tariffs { get; set; }

        #endregion Properties
    }
}