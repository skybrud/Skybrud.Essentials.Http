using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth.Models;
using Skybrud.Essentials.Http.OAuth.Responses;

namespace Skybrud.Essentials.Http.OAuth {

    /// <summary>
    /// OAuth client following the OAuth 1.0a protocol. The client will handle the necessary communication with the
    /// OAuth server (Service Provider). This includes the technical part with signatures, authorization headers and
    /// similar. The client can also be used for 3-legged logins.
    /// </summary>
    public partial class OAuthClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the consumer key of your application.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret of your application. The consumer secret is sensitive information used to
        /// identify your application. Users should never be shown this value.
        /// </summary>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets a unique/random value specifying the <c>oauth_nonce</c> parameter in the OAuth protocol.
        /// Along with <c>oauth_timestamp</c>, it will make sure each request is only sent once to the OAuth
        /// server (provider).
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Gets or sets the current UNIX timestamp specifying the <c>oauth_timestamp</c> in the OAuth protocol.
        /// Along with <c>oauth_nonce</c>, it will make sure each request is only sent once to the OAuth server
        /// (provider).
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the request token or access token used to access the OAuth server on behalf of a user.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the request token secret or access token secret used to access the OAuth server on behalf of a
        /// user.
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the version of the OAuth protocol.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the callback URL. This property specified the <c>oauth_callback</c> parameter and is
        /// used for 3-legged logins. You only need to specify this property for authentication - it is not necessary
        /// toset this property when just making calls to the API. 
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Gets or sets the request token URL. As the first step of the 3-legged login process, the client must obtain
        /// a request token through this URL. If possible this URL should always use HTTPS.
        /// </summary>
        public string RequestTokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the authorization URL. As the second step of the 3-legged login process, the user is
        /// redirected to this URL for authorizing the login. If possible this URL should always use HTTPS.
        /// </summary>
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// Gets or sets the access token URL. In the final step of the 3-legged login process, the OAuth client will
        /// exchange the request token for an access token. It will do so using this URL. If possible this URL should
        /// always use HTTPS.
        /// </summary>
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// If <c>true</c>, new requests will automatically reset the <c>oauth_timestamp</c> and
        /// <c>oauth_nonce</c> with new values. It should only be disabled for testing purposes.
        /// </summary>
        public bool AutoReset { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client with default options.
        /// </summary>
        public OAuthClient() {
            AutoReset = true;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="consumerKey"/> and
        /// <paramref name="consumerSecret"/>.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        public OAuthClient(string consumerKey, string consumerSecret) {
            AutoReset = true;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="consumerKey"/>,
        /// <paramref name="consumerKey"/> and <paramref name="callback"/>.
        /// </summary>
        /// <param name="consumerKey">The consumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="callback">The callback URI of your application.</param>
        public OAuthClient(string consumerKey, string consumerSecret, string callback) {
            AutoReset = true;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Callback = callback;
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
            Version = "1.0";
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Updates the <c>oauth_timestamp</c> and <c>oauth_nonce</c> OAuth parameters with new values for another
        /// request. If the <see cref="AutoReset"/> property is <c>true</c>, this method will be called automatically
        /// before each request to the underlying API.
        /// </summary>
        public virtual void Reset() {
            Nonce = OAuthUtils.GenerateNonce();
            Timestamp = OAuthUtils.GetTimestamp();
        }

        /// <summary>
        /// Generates the string for the authorization header based on the specified <paramref name="signature"/>.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <returns>The generated header string.</returns>
        public virtual string GenerateHeaderString(string signature) {
            string oauthHeaders = "OAuth realm=\"\",";
            if (!String.IsNullOrEmpty(Callback)) oauthHeaders += "oauth_callback=\"" + Uri.EscapeDataString(Callback) + "\",";
            oauthHeaders += "oauth_consumer_key=\"" + Uri.EscapeDataString(ConsumerKey) + "\",";
            oauthHeaders += "oauth_nonce=\"" + Uri.EscapeDataString(Nonce) + "\",";
            oauthHeaders += "oauth_signature=\"" + Uri.EscapeDataString(signature) + "\",";
            oauthHeaders += "oauth_signature_method=\"HMAC-SHA1\",";
            oauthHeaders += "oauth_timestamp=\"" + Timestamp + "\",";
            if (!String.IsNullOrEmpty(Token)) oauthHeaders += "oauth_token=\"" + Uri.EscapeDataString(Token) + "\",";
            oauthHeaders += "oauth_version=\"" + Version + "\"";
            return oauthHeaders;
        }

        /// <summary>
        /// Generates the the string of parameters used for making the signature.
        /// </summary>
        /// <param name="queryString">Values representing the query string.</param>
        /// <param name="body">Values representing the POST body.</param>
        /// <returns>The generated parameter string.</returns>
        public virtual string GenerateParameterString(IHttpQueryString queryString, IHttpPostData body) {

            // The parameters must be alphabetically sorted
            SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();

            // Add parameters from the query string
            if (queryString != null) {
                foreach (string key in queryString.Keys) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(queryString[key]));
                }
            }

            // Add parameters from the POST data
            if (body != null) {
                foreach (string key in body.Keys) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(body[key]));
                }
            }

            // Add OAuth values
            if (!String.IsNullOrEmpty(Callback)) sorted.Add("oauth_callback", Uri.EscapeDataString(Callback));
            sorted.Add("oauth_consumer_key", Uri.EscapeDataString(ConsumerKey));
            sorted.Add("oauth_nonce", Uri.EscapeDataString(Nonce));
            sorted.Add("oauth_signature_method", "HMAC-SHA1");
            sorted.Add("oauth_timestamp", Uri.EscapeDataString(Timestamp));
            if (!String.IsNullOrEmpty(Token)) sorted.Add("oauth_token", Uri.EscapeDataString(Token));
            sorted.Add("oauth_version", Uri.EscapeDataString(Version));

            // Merge all parameters
            return sorted.Aggregate("", (current, pair) => current + ("&" + pair.Key + "=" + pair.Value)).Substring(1);

        }

        /// <summary>
        /// Generates the key used for making the signature.
        /// </summary>
        /// <returns>The generated signature key.</returns>
        public virtual string GenerateSignatureKey() {
            return Uri.EscapeDataString(ConsumerSecret ?? "") + "&" + Uri.EscapeDataString(TokenSecret ?? "");
        }

        /// <summary>
        /// Generates the string value used for making the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        /// <returns>The generated signature value.</returns>
        public virtual string GenerateSignatureValue(HttpMethod method, string url, IHttpQueryString queryString, IHttpPostData body) {
            return String.Format(
                "{0}&{1}&{2}",
                method.ToString().ToUpper(),
                Uri.EscapeDataString(url.Split('#')[0].Split('?')[0]),
                Uri.EscapeDataString(GenerateParameterString(queryString, body))
            );
        }

        /// <summary>
        /// Generates the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        /// <returns>The generated signature.</returns>
        public virtual string GenerateSignature(HttpMethod method, string url, IHttpQueryString queryString, IHttpPostData body) {
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(GenerateSignatureKey()));
            return Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(GenerateSignatureValue(method, url, queryString, body))));
        }

        /// <summary>
        /// Gets a request token from the provider. After acquiring a request token, the user should be redirected
        /// to the website of the provider for approving the application. If successful, the user will be redirected
        /// back to the specified callback URL where you then can exchange the request token for an access token.
        /// </summary>
        /// <returns>An instance of <see cref="OAuthRequestTokenResponse"/> representing the response.</returns>
        public virtual OAuthRequestTokenResponse GetRequestToken() {

            // Make the call to the API/provider
            HttpResponse response = GetRequestTokenResponse();

            // Parse the response body
            OAuthRequestToken body = OAuthRequestToken.Parse(this, response.Body);

            // Parse the response
            return OAuthRequestTokenResponse.ParseResponse(response, body);

        }

        /// <returns>An instance of <see cref="HttpResponse"/> representing the raw response.</returns>
        protected virtual HttpResponse GetRequestTokenResponse() {

            // Some error checking
            if (String.IsNullOrWhiteSpace(RequestTokenUrl)) throw new PropertyNotSetException(nameof(RequestTokenUrl));
            if (String.IsNullOrWhiteSpace(AuthorizeUrl)) throw new PropertyNotSetException(nameof(AuthorizeUrl));

            // Make the call to the API/provider
            return DoHttpPostRequest(RequestTokenUrl);

        }

        /// <summary>
        /// Following the 3-legged authorization, you can exchange a request token for an access token
        /// using this method. This is the third and final step of the authorization process.
        /// </summary>
        /// <param name="verifier">The verification key received after the user has accepted the app.</param>
        /// <returns>An instance of <see cref="OAuthAccessTokenResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/auth/3-legged-authorization</cref>
        /// </see>
        public virtual OAuthAccessTokenResponse GetAccessToken(string verifier) {

            // Some error checking
            if (String.IsNullOrWhiteSpace(verifier)) throw new ArgumentNullException(nameof(verifier));

            // Make the call to the API/provider
            HttpResponse response = GetAccessTokenResponse(verifier);

            // Parse the response body
            OAuthAccessToken body = OAuthAccessToken.Parse(this, response.Body);

            // Parse the response
            return OAuthAccessTokenResponse.ParseResponse(response, body);

        }

        /// <returns>An instance of <see cref="HttpResponse"/> representing the raw response.</returns>
        protected virtual HttpResponse GetAccessTokenResponse(string verifier) {

            // Some error checking
            if (String.IsNullOrWhiteSpace(AccessTokenUrl)) throw new PropertyNotSetException(nameof(AccessTokenUrl));

            // Initialize the POST data
            IHttpPostData postData = new HttpPostData();
            postData.Add("oauth_verifier", verifier);

            // Make the call to the API/provider
            return DoHttpPostRequest(AccessTokenUrl, null, postData);

        }

        /// <summary>
        /// Helper method for generating the OAuth signature for an instance of <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="request">The instance of <see cref="HttpRequest"/> the signature should be based on.</param>
        /// <returns>The generated OAuth signature.</returns>
        protected virtual string GenerateSignature(HttpRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (String.IsNullOrWhiteSpace(request.Url)) throw new PropertyNotSetException(nameof(request.Url));
            return GenerateSignature(request.Method, request.Url, request.QueryString, request.PostData);
        }

        /// <summary>
        /// Adds the OAuth 1.0a authorization header to the request
        /// </summary>
        /// <param name="request"></param>
        protected override void PrepareHttpRequest(HttpRequest request) {

            // Generate the signature
            string signature = GenerateSignature(request);

            // Generate the header
            string header = GenerateHeaderString(signature);

            // Add the authorization header
            request.Headers.Headers["Authorization"] = header;

            // Make sure we reset the client (timestamp and nonce)
            if (AutoReset) Reset();

        }

        #endregion

    }

}