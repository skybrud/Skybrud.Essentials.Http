using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http.Client;

public partial class HttpClient {

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Post(url));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Post(url, queryString));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpPostData? postData) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Post(url, postData));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Post(url, queryString, postData));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, string contentType, string body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Post(url, queryString).SetContentType(contentType).SetBody(body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, JToken body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, JToken body, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, JToken body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, XNode body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, XNode body, SaveOptions options) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, XNode body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        return await GetResponseAsync(HttpRequest.Post(url, queryString, body, options));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, NameValueCollection? postData) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return await GetResponseAsync(HttpRequest.Post(url, query, post));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, string? contentType, string? body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query).SetContentType(contentType).SetBody(body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, JToken body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, XNode body) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="url">The base URL of the request (no query string).</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> PostAsync(string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (body == null) throw new ArgumentNullException(nameof(body));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Post(url, query, body, options));
    }

}