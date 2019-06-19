using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http.OAuth.Models {

    /// <summary>
    /// Class representing the response body of a call to get an OAuth 1.0a access token.
    /// </summary>
    public class OAuthAccessToken {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public OAuthClient Client { get; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Gets the access token secret.
        /// </summary>
        public string TokenSecret { get; }

        /// <summary>
        /// Gets a reference to the query string representing the response body.
        /// </summary>
        public IHttpQueryString Query { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="client"/> and <paramref name="query"/>.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string as specified by the response body.</param>
        protected OAuthAccessToken(OAuthClient client, IHttpQueryString query) {
            Client = client;
            Token = query["oauth_token"];
            TokenSecret = query["oauth_token_secret"];
            Query = query;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public static OAuthAccessToken Parse(OAuthClient client, string str) {

            // Convert the query string to an IHttpQueryString
            IHttpQueryString query = HttpQueryString.ParseQueryString(str);

            // Initialize a new instance
            return new OAuthAccessToken(client, query);

        }

        #endregion

    }

}