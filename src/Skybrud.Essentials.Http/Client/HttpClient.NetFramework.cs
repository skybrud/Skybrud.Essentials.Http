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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Get(url, query));
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Post method instead.")]
        public virtual IHttpResponse DoHttpPostRequest(string url, NameValueCollection queryString) {
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            IHttpPostData post = postData == null ? null : new HttpPostData(postData);
            return GetResponse(HttpRequest.Post(url, query, post));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query).SetContentType(contentType).SetBody(body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query, body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query, body, formatting));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query, body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Post(url, query, body, options));
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString) {
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            IHttpPostData post = postData == null ? null : new HttpPostData(postData);
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
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, string contentType, string body) {
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query).SetContentType(contentType).SetBody(body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
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
        [Obsolete("Use the Put method instead.")]
        public virtual IHttpResponse DoHttpPutRequest(string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query, body, formatting));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query, body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Put(url, query, body, options));
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Use the Patch method instead.")]
        public virtual IHttpResponse DoHttpPatchRequest(string url, NameValueCollection queryString) {
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            IHttpPostData post = postData == null ? null : new HttpPostData(postData);
            return GetResponse(HttpRequest.Patch(url, query, post));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query).SetContentType(contentType).SetBody(body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query, body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query, body, formatting));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query, body));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Patch(url, query, body, options));
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
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Delete(url, query));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query));
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, NameValueCollection postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            IHttpPostData post = postData == null ? null : new HttpPostData(postData);
            return GetResponse(new HttpRequest(method, url, query, post));
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
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, string contentType, string body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query).SetContentType(contentType).SetBody(body));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, JToken body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query, body));
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
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, JToken body, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query, body, formatting));
        }

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, XNode body) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query).SetBody(body));
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
        [Obsolete("Don't use. Method will be removed in a future release.")]
        public virtual IHttpResponse DoHttpRequest(HttpMethod method, string url, NameValueCollection queryString, XNode body, SaveOptions options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (body == null) throw new ArgumentNullException(nameof(body));
            IHttpQueryString query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(new HttpRequest(method, url, query).SetBody(body, options));
        }

    }

}

#endif