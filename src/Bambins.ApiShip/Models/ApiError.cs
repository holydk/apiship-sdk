namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a API error.
    /// </summary>
    public class ApiError
    {
        #region Properties

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        #endregion Properties
    }
}