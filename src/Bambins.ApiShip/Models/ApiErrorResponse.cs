namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a API error response.
    /// </summary>
    public class ApiErrorResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        public ApiError[] Errors { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the link to the full description of the error.
        /// </summary>
        public string MoreInfo { get; set; }

        #endregion Properties
    }
}