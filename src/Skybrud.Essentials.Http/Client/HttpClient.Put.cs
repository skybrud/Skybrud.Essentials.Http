using System;
using System.Collections.Specialized;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Essentials.Http.Client {

    public partial class HttpClient {

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Put(string url) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
        public virtual IHttpResponse Put(string url, IHttpGetOptions? options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, options?.GetQueryString()));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
        public virtual IHttpResponse Put(string url, IHttpPostOptions? options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, options?.GetQueryString(), options?.GetPostData()));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, queryString));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The PUT data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpPostData? postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, postData));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, IHttpPostData postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, postData));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, string contentType, string body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Put(url, queryString).SetContentType(contentType).SetBody(body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, JToken body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, JToken body, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body, formatting));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, JToken body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body, formatting));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, XNode body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, XNode body, SaveOptions options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body, options));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, XNode body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, queryString, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, queryString, body, options));
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection? queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection? queryString, NameValueCollection? postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
            return GetResponse(HttpRequest.Put(url, query, post));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection? queryString, string contentType, string body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query).SetContentType(contentType).SetBody(body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection? queryString, JToken body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query, body, formatting));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection queryString, XNode body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body));
        }

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Put(string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            return GetResponse(HttpRequest.Put(url, body, options));
        }

#endif

    }

}