namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a request model to get the labels.
    /// </summary>
    public class GetLabelsRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the format (default pdf).
        /// </summary>
        public string Format { get; set; } = "pdf";

        /// <summary>
        /// Gets or sets the order IDs.
        /// </summary>
        public int[] OrderIds { get; set; }

        #endregion Properties
    }
}