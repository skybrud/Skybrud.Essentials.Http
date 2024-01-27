using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Skybrud.Essentials.Http.Client;

/// <summary>
/// Static class with various extension methods for <see cref="IHttpClientAsync"/>.
/// </summary>
public static class HttpClientAsyncExtensions {

    #region GetAsync(...)

    /// <summary>
    /// Makes a HTTP GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> GetAsync(this IHttpClientAsync client, string url) {
        return await client.GetResponseAsync(HttpRequest.Get(url));
    }

    /// <summary>
    /// Makes a GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> GetAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString) {
        return await client.GetResponseAsync(HttpRequest.Get(url, queryString));
    }

    /// <summary>
    /// Makes a GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> GetAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Get(url, query));
    }

    #endregion

    #region PostAsync(...)

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url) {
        return await client.GetResponseAsync(HttpRequest.Post(url));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Post(url, null, postData));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, postData));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Post(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Post(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Post(url, queryString, body, options));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, post));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, string contentType, string body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PostAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Post(url, query, body, options));
    }

    #endregion

    #region PatchAsync(...)

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url) {
        return await client.GetResponseAsync(HttpRequest.Patch(url));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, postData));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, postData));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, string contentType, string body) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Patch(url, queryString, body, options));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, post));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, string contentType, string body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PatchAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Patch(url, query, body, options));
    }

    #endregion

    #region PutAsync(...)

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url) {
        return await client.GetResponseAsync(HttpRequest.Put(url));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Put(url, postData));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, postData));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, string contentType, string body) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Put(url, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Put(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Put(url, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Put(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return await client.GetResponseAsync(HttpRequest.Put(url, queryString, body, options));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, post));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, string contentType, string body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static async Task<IHttpResponse> PutAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Put(url, query, body, options));
    }

    #endregion

    #region DeleteAsync(...)

    /// <summary>
    /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> DeleteAsync(this IHttpClientAsync client, string url) {
        return await client.GetResponseAsync(HttpRequest.Delete(url));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> DeleteAsync(this IHttpClientAsync client, string url, IHttpQueryString? queryString) {
        return await client.GetResponseAsync(HttpRequest.Delete(url, queryString));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static async Task<IHttpResponse> DeleteAsync(this IHttpClientAsync client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await client.GetResponseAsync(HttpRequest.Delete(url, query));
    }

    #endregion

}