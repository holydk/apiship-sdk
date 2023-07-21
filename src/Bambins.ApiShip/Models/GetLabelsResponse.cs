namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a respnse model to get the labels.
    /// </summary>
    public class GetLabelsResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the failed orders.
        /// </summary>
        public ErrorOrderInfo[] FailedOrders { get; set; }

        /// <summary>
        /// Gets or sets the URL to file.
        /// </summary>
        public string Url { get; set; }

        #endregion Properties
    }
}