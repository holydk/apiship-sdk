using Bambins.ApiShip.Models;
using System;
using System.Collections.Generic;

namespace Bambins.ApiShip.Client
{
    /// <summary>
    /// Represents a API Exception.
    /// </summary>
    public class ApiException : Exception
    {
        #region Properties

        /// <summary>
        /// Gets the API error response.
        /// </summary>
        public ApiErrorResponse Error { get; }

        /// <summary>
        /// Gets the error code (HTTP status code).
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Gets the HTTP headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="error">The error.</param>
        public ApiException(int errorCode, string message, IDictionary<string, string> headers, ApiErrorResponse error)
            : base(message)
        {
            ErrorCode = errorCode;
            Headers = headers;
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        public ApiException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        #endregion Ctor
    }
}