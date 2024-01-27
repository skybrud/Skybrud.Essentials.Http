using System;
using System.Collections.Specialized;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http;

public static partial class HttpUtils {

    public static partial class Requests {

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public static IHttpResponse Get(string url, NameValueCollection? queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpMethod.Get, url, queryString);
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public static IHttpResponse Post(string url, NameValueCollection? queryString) {
            return GetResponse(HttpMethod.Post, url, queryString, null);
        }

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public static IHttpResponse Post(string url, NameValueCollection? queryString, NameValueCollection? postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpMethod.Post, url, queryString, postData);
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public static IHttpResponse Put(string url, NameValueCollection? queryString) {
            return GetResponse(HttpMethod.Put, url, queryString, null);
        }

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The PUT data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public static IHttpResponse Put(string url, NameValueCollection? queryString, NameValueCollection? postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpMethod.Put, url, queryString, postData);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public static IHttpResponse Patch(string url, NameValueCollection? queryString) {
            return GetResponse(HttpMethod.Patch, url, queryString, null);
        }

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The PATCH data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public static IHttpResponse Patch(string url, NameValueCollection? queryString, NameValueCollection? postData) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpMethod.Patch, url, queryString, postData);
        }

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public static IHttpResponse Delete(string url, NameValueCollection? queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpMethod.Delete, url, queryString);
        }

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        private static IHttpResponse GetResponse(HttpMethod method, string url, NameValueCollection? queryString) {
            return GetResponse(method, url, queryString == null ? null : new HttpQueryString(queryString), null);
        }

        /// <summary>
        /// Makes a HTTP request using the specified <paramref name="url"/> and <paramref name="method"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        private static IHttpResponse GetResponse(HttpMethod method, string url, NameValueCollection? queryString, NameValueCollection? postData) {
            return GetResponse(method, url, queryString == null ? null : new HttpQueryString(queryString), postData == null ? null : new HttpPostData(postData));
        }

    }

}