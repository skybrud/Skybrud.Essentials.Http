using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using System;

namespace Skybrud.Essentials.Http.Client {

    /// <summary>
    /// Interface describing a client for making HTTP requests.
    /// </summary>
    public interface IHttpClient : IHttpClient2 {

        #region DoHttpGetRequest

        /// <summary>
        /// Makes a HTTP GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpGetRequest(string url);

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpGetRequest(string url, IHttpQueryString queryString);

        #endregion

        #region DoHttpPostRequest

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url);

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpPostOptions options);

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString);

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpPostData postData);

        /// <summary>
        /// Makes a POST request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, IHttpPostData postData);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, string contentType, string body);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, JToken body);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, JToken body);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, XNode body);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, XNode body, SaveOptions options);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, XNode body);

        /// <summary>
        /// Makes a HTTP POST request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPostRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options);

        #endregion

        #region DoHttpPutRequest

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url);

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpPostOptions options);

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString);

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpPostData postData);

        /// <summary>
        /// Makes a PUT request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, IHttpPostData postData);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, string contentType, string body);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, JToken body);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, JToken body);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, XNode body);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, XNode body, SaveOptions options);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, XNode body);

        /// <summary>
        /// Makes a HTTP PUT request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPutRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options);

        #endregion

        #region DoHttpPatchRequest

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url);

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpPostOptions options);

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString);

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpPostData postData);

        /// <summary>
        /// Makes a PATCH request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, IHttpPostData postData);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, string contentType, string body);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, JToken body);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, JToken body);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, XNode body);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, XNode body, SaveOptions options);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, XNode body);

        /// <summary>
        /// Makes a HTTP PATCH request based on the specified parameters.
        /// </summary>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpPatchRequest(string url, IHttpQueryString queryString, XNode body, SaveOptions options);

        #endregion

        #region DoHttpDeleteRequest

        /// <summary>
        /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpDeleteRequest(string url);

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpDeleteRequest(string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a DELETE request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpDeleteRequest(string url, IHttpQueryString queryString);

        #endregion

        #region DoHttpRequest

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url);

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpGetOptions options);

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString);

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpPostData postData);

        /// <summary>
        /// Makes a HTTP request to the underlying API based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="postData">The POST data.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, IHttpPostData postData);

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
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, string contentType, string body);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, JToken body);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, JToken body);

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
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, JToken body, Formatting formatting);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, XNode body);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="body">The body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, XNode body, SaveOptions options);

        /// <summary>
        /// Makes a HTTP request based on the specified parameters.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="url">The base URL of the request (no query string).</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        [Obsolete("Don't use. Method will be removed in a future release.")]
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, XNode body);

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
        IHttpResponse DoHttpRequest(HttpMethod method, string url, IHttpQueryString queryString, XNode body, SaveOptions options);

        #endregion

    }

}