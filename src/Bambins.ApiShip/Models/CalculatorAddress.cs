namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a address model for the tariffs calculation.
    /// </summary>
    public class CalculatorAddress : Address
    {
        #region Properties

        /// <summary>
        /// Gets or sets the postcode
        /// </summary>
        public string Index { get; set; }

        #endregion Properties
    }
}