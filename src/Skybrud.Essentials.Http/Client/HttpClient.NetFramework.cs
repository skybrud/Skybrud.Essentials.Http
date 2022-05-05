#if NET_FRAMEWORK

using System;
using System.Collections.Specialized;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http.Client {

    public partial class HttpClient {

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Get method instead.")]
        public virtual IHttpResponse DoHttpGetRequest(string url, NameValueCollection queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(HttpMethod.Get, url, queryString);
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(HttpMethod.Post, url, queryString, default(NameValueCollection));
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(HttpMethod.Post, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(HttpMethod.Post, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Post, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Post, url, queryString, body, options);
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(HttpMethod.Put, url, queryString, default(NameValueCollection));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(HttpMethod.Put, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(HttpMethod.Put, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Put, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Put, url, queryString, body, options);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString) {
            return DoHttpRequest(HttpMethod.Patch, url, queryString, default(NameValueCollection));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, NameValueCollection postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(HttpMethod.Patch, url, queryString, postData);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(HttpMethod.Patch, url, queryString, contentType, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Patch, url, queryString, body);
        }

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(HttpMethod.Patch, url, queryString, body, options);
        }

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use the Delete method instead.")]
        public virtual IHttpResponse DoHttpDeleteRequest(string url, NameValueCollection queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return DoHttpRequest(HttpMethod.Delete, url, queryString);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString) {
            return DoHttpRequest(method, url, queryString == null ? null : new HttpQueryString(queryString), default(IHttpPostData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(method, url, queryString == null ? null : new HttpQueryString(queryString), postData == null ? null : new HttpPostData(postData));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, string contentType, string body) {
            return DoHttpRequest(method, url, queryString == null ? null : new HttpQueryString(queryString), contentType, body);
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, JToken body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, HttpConstants.ApplicationJson, body.ToString(Formatting.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, HttpConstants.ApplicationJson, body.ToString(formatting));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, XNode body) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, HttpConstants.TextXml, body.ToString(SaveOptions.None));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            return DoHttpRequest(method, url, queryString, HttpConstants.TextXml, body.ToString(options));
        }

    }

}

#endif