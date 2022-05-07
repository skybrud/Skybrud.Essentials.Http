using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Essentials.Http {

    public static partial class HttpUtils {

        /// <summary>
        /// Static class with utility methods related to making HTTP requests.
        /// </summary>
        public static partial class Requests {

            #region Get

            /// <summary>
            /// Makes a HTTP GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Get(string url) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Get, url, default(IHttpQueryString), null);
            }

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Get(string url, IHttpGetOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Get, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Get(string url, IHttpQueryString queryString) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Get, url, queryString, null);
            }

            #endregion

            #region Post

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Post, url, default(IHttpQueryString), default);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Post(string url, IHttpGetOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Post, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Post(string url, IHttpPostOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Post, url, options.GetQueryString(), options.GetPostData());
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString queryString) {
                return DoHttpRequest(HttpMethod.Post, url, queryString, null);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Post(string url, IHttpPostData postData) {
                return DoHttpRequest(HttpMethod.Post, url, null, postData);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Post, url, queryString, postData);
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/> and JSON <paramref name="body"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="body">The <see cref="JToken"/> representing the POST body.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, JToken body) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (body == null) throw new ArgumentNullException(nameof(body));
                return new HttpRequest(HttpMethod.Post, url, body).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/> and JSON <paramref name="body"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="body">The <see cref="JToken"/> representing the POST body.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString queryString, JToken body) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (body == null) throw new ArgumentNullException(nameof(body));
                return new HttpRequest(HttpMethod.Post, url, queryString, body).GetResponse();
            }

            #endregion

            #region Put

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Put(string url) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Put, url, default(IHttpQueryString), default);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Put(string url, IHttpGetOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Put, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Put(string url, IHttpPostOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Put, url, options.GetQueryString(), options.GetPostData());
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Put(string url, IHttpQueryString queryString) {
                return DoHttpRequest(HttpMethod.Put, url, queryString, null);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PUT data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Put(string url, IHttpPostData postData) {
                return DoHttpRequest(HttpMethod.Put, url, null, postData);
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PUT data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Put(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Put, url, queryString, postData);
            }

            #endregion

            #region Patch

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Patch(string url) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Patch, url, default(IHttpQueryString), default);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Patch(string url, IHttpGetOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Patch, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Patch(string url, IHttpPostOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Patch, url, options.GetQueryString(), options.GetPostData());
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Patch(string url, IHttpQueryString queryString) {
                return DoHttpRequest(HttpMethod.Patch, url, queryString, null);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PATCH data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Patch(string url, IHttpPostData postData) {
                return DoHttpRequest(HttpMethod.Patch, url, null, postData);
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PATCH data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Patch(string url, IHttpQueryString queryString, IHttpPostData postData) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Patch, url, queryString, postData);
            }

            #endregion

            #region Delete

            /// <summary>
            /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Delete(string url) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Delete, url, default(IHttpQueryString), null);
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Delete(string url, IHttpGetOptions options) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (options == null) throw new ArgumentNullException(nameof(options));
                return DoHttpRequest(HttpMethod.Delete, url, options.GetQueryString(), null);
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Delete(string url, IHttpQueryString queryString) {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                return DoHttpRequest(HttpMethod.Delete, url, queryString, null);
            }

            #endregion

            #region DoHttpRequest

            /// <summary>
            /// Makes a HTTP request using the specified <paramref name="url"/> and <paramref name="method"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="method">The HTTP method of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            private static IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData) {

                // Initialize the request
                HttpRequest request = new HttpRequest {
                    Url = url,
                    Method = method,
                    QueryString = queryString,
                    PostData = postData
                };

                // Make the call to the URL
                return request.GetResponse();

            }

            #endregion

        }

    }

}