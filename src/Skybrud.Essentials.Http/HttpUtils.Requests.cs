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
                return HttpRequest.Get(url).GetResponse();
            }

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Get(string url, IHttpGetOptions? options) {
                return HttpRequest.Get(url, options?.GetQueryString()).GetResponse();
            }

            /// <summary>
            /// Makes a GET request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Get(string url, IHttpQueryString? queryString) {
                return HttpRequest.Get(url, queryString).GetResponse();
            }

            #endregion

            #region Post

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url) {
                return HttpRequest.Post(url).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Post(string url, IHttpGetOptions? options) {
                return HttpRequest.Post(url, options?.GetQueryString()).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Post(string url, IHttpPostOptions? options) {
                return HttpRequest.Post(url, options?.GetQueryString(), options?.GetPostData()).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString? queryString) {
                return HttpRequest.Post(url, queryString).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The POST data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Post(string url, IHttpPostData? postData) {
                return HttpRequest.Post(url, postData).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The POST data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString queryString, IHttpPostData postData) {
                return HttpRequest.Post(url, queryString, postData).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/> and JSON <paramref name="body"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="body">The <see cref="JToken"/> representing the POST body.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, JToken body) {
                return HttpRequest.Post(url, body).GetResponse();
            }

            /// <summary>
            /// Makes a POST request to the specified <paramref name="url"/> and JSON <paramref name="body"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="body">The <see cref="JToken"/> representing the POST body.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Post(string url, IHttpQueryString? queryString, JToken body) {
                return HttpRequest.Post(url, queryString, body).GetResponse();
            }

            #endregion

            #region Put

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Put(string url) {
                return HttpRequest.Put(url).GetResponse();
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Put(string url, IHttpGetOptions? options) {
                return HttpRequest.Put(url, options?.GetQueryString()).GetResponse();
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Put(string url, IHttpPostOptions? options) {
                return HttpRequest.Put(url, options?.GetQueryString(), options?.GetPostData()).GetResponse();
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Put(string url, IHttpQueryString? queryString) {
                return HttpRequest.Put(url, queryString).GetResponse();
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PUT data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Put(string url, IHttpPostData? postData) {
                return HttpRequest.Put(url, postData).GetResponse();
            }

            /// <summary>
            /// Makes a PUT request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PUT data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Put(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
                return HttpRequest.Put(url, queryString, postData).GetResponse();
            }

            #endregion

            #region Patch

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Patch(string url) {
                return HttpRequest.Patch(url).GetResponse();
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Patch(string url, IHttpGetOptions? options) {
                return HttpRequest.Patch(url, options?.GetQueryString()).GetResponse();
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Patch(string url, IHttpPostOptions? options) {
                return HttpRequest.Patch(url, options?.GetQueryString(), options?.GetPostData()).GetResponse();
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="queryString">The query string.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Patch(string url, IHttpQueryString? queryString) {
                return HttpRequest.Patch(url, queryString).GetResponse();
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The base URL of the request (no query string).</param>
            /// <param name="postData">The PATCH data.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
            public static IHttpResponse Patch(string url, IHttpPostData? postData) {
                return HttpRequest.Patch(url, postData).GetResponse();
            }

            /// <summary>
            /// Makes a PATCH request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <param name="postData">The PATCH data of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Patch(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
                return HttpRequest.Patch(url, queryString, postData).GetResponse();
            }

            #endregion

            #region Delete

            /// <summary>
            /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Delete(string url) {
                return HttpRequest.Delete(url).GetResponse();
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
            public static IHttpResponse Delete(string url, IHttpGetOptions? options) {
                return HttpRequest.Delete(url, options?.GetQueryString()).GetResponse();
            }

            /// <summary>
            /// Makes a DELETE request to the specified <paramref name="url"/>.
            /// </summary>
            /// <param name="url">The URL of the request.</param>
            /// <param name="queryString">The query string of the request.</param>
            /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
            public static IHttpResponse Delete(string url, IHttpQueryString? queryString) {
                return HttpRequest.Delete(url, queryString).GetResponse();
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
            private static IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
                return new HttpRequest(method, url, queryString, postData).GetResponse();
            }

            #endregion

        }

    }

}