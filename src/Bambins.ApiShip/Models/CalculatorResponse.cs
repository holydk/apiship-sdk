namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model containing the tariffs.
    /// </summary>
    public class CalculatorResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the delivery to door.
        /// </summary>
        public CalculatorToDoorResult[] DeliveryToDoor { get; set; }

        /// <summary>
        /// Gets or sets the delivery to point.
        /// </summary>
        public CalculatorToPointResult[] DeliveryToPoint { get; set; }

        #endregion Properties
    }
}