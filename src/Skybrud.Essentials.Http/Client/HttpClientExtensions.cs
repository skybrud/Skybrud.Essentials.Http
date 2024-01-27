using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace Skybrud.Essentials.Http.Client;

/// <summary>
/// Static class with various extension methods for <see cref="IHttpClient"/> .
/// </summary>
public static class HttpClientExtensions {

    #region Get(...)

    /// <summary>
    /// Makes a HTTP GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Get(this IHttpClient client, string url) {
        return client.GetResponse(HttpRequest.Get(url));
    }

    /// <summary>
    /// Makes a GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Get(this IHttpClient client, string url, IHttpQueryString? queryString) {
        return client.GetResponse(HttpRequest.Get(url, queryString));
    }

#if NAME_VALUE_COLLECTION

    /// <summary>
    /// Makes a GET request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Get(this IHttpClient client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Get(url, query));
    }

#endif

    #endregion

    #region Post(...)

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url) {
        return client.GetResponse(HttpRequest.Post(url));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString) {
        return client.GetResponse(HttpRequest.Post(url, queryString));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Post(url, null, postData));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Post(url, queryString, postData));
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
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, string contentType, string body) {
        return client.GetResponse(HttpRequest.Post(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, JToken body) {
        return client.GetResponse(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Post(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body) {
        return client.GetResponse(HttpRequest.Post(url, queryString, body));
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
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Post(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, XNode body) {
        return client.GetResponse(HttpRequest.Post(url, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Post(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body) {
        return client.GetResponse(HttpRequest.Post(url, queryString, body));
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
    public static IHttpResponse Post(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Post(url, queryString, body, options));
    }

#if NAME_VALUE_COLLECTION

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query));
    }

    /// <summary>
    /// Makes a POST request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return client.GetResponse(HttpRequest.Post(url, query, post));
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
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, string contentType, string body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query, body));
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
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP POST request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query, body));
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
    public static IHttpResponse Post(this IHttpClient client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Post(url, query, body, options));
    }

#endif

    #endregion

    #region Patch(...)

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url) {
        return client.GetResponse(HttpRequest.Patch(url));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString) {
        return client.GetResponse(HttpRequest.Patch(url, queryString));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Patch(url, postData));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, postData));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, JToken body) {
        return client.GetResponse(HttpRequest.Patch(url, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Patch(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, body));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, XNode body) {
        return client.GetResponse(HttpRequest.Patch(url, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Patch(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, body));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Patch(url, queryString, body, options));
    }

#if NAME_VALUE_COLLECTION

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query));
    }

    /// <summary>
    /// Makes a PATCH request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return client.GetResponse(HttpRequest.Patch(url, query, post));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, string? contentType, string? body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query, body));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PATCH request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query, body));
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
    public static IHttpResponse Patch(this IHttpClient client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Patch(url, query, body, options));
    }

#endif

    #endregion

    #region Put(...)

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url) {
        return client.GetResponse(HttpRequest.Put(url));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString) {
        return client.GetResponse(HttpRequest.Put(url, queryString));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The POST data.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Put(url, postData));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return client.GetResponse(HttpRequest.Put(url, queryString, postData));
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
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return client.GetResponse(HttpRequest.Put(url, queryString, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, JToken body) {
        return client.GetResponse(HttpRequest.Put(url, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Put(url, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body) {
        return client.GetResponse(HttpRequest.Put(url, queryString, body));
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
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return client.GetResponse(HttpRequest.Put(url, queryString, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, XNode body) {
        return client.GetResponse(HttpRequest.Put(url, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">The body of the request.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Put(url, body, options));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body) {
        return client.GetResponse(HttpRequest.Put(url, queryString, body));
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
    public static IHttpResponse Put(this IHttpClient client, string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return client.GetResponse(HttpRequest.Put(url, queryString, body, options));
    }

#if NAME_VALUE_COLLECTION

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query));
    }

    /// <summary>
    /// Makes a PUT request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The POST data of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, NameValueCollection? postData) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        IHttpPostData? post = postData == null ? null : new HttpPostData(postData);
        return client.GetResponse(HttpRequest.Put(url, query, post));
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
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, string? contentType, string? body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query, contentType, body));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, JToken body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query, body));
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
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, JToken body, Formatting formatting) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query, body, formatting));
    }

    /// <summary>
    /// Makes a HTTP PUT request based on the specified parameters.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, XNode body) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query, body));
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
    public static IHttpResponse Put(this IHttpClient client, string url, NameValueCollection? queryString, XNode body, SaveOptions options) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Put(url, query, body, options));
    }

#endif

    #endregion

    #region Delete(...)

    /// <summary>
    /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Delete(this IHttpClient client, string url) {
        return client.GetResponse(HttpRequest.Delete(url));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Delete(this IHttpClient client, string url, IHttpQueryString? queryString) {
        return client.GetResponse(HttpRequest.Delete(url, queryString));
    }

#if NAME_VALUE_COLLECTION

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public static IHttpResponse Delete(this IHttpClient client, string url, NameValueCollection? queryString) {
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return client.GetResponse(HttpRequest.Delete(url, query));
    }

#endif

    #endregion

}