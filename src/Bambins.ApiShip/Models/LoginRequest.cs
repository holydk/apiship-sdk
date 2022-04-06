namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a request model to get the access token.
    /// </summary>
    public class LoginRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        #endregion Properties
    }
}