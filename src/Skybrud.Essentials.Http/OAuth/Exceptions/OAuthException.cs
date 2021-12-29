using System;

namespace Skybrud.Essentials.Http.OAuth.Exceptions {

    /// <summary>
    /// Class representing an OAuth exception.
    /// </summary>
    public class OAuthException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public HttpResponse Response { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The underlying response.</param>
        /// <param name="message">The message.</param>
        public OAuthException(HttpResponse response, string message) : base(message) {
            Response = response;
        }

        #endregion

    }

}