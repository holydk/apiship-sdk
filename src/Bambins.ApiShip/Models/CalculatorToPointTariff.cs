namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model for tariff to point.
    /// </summary>
    public class CalculatorToPointTariff : CalculatorTariff
    {
        #region Properties

        /// <summary>
        /// Gets or sets the array of IDs of available pickup points for each of the tariffs.
        /// </summary>
        public int[] PointIds { get; set; }

        #endregion Properties
    }
}