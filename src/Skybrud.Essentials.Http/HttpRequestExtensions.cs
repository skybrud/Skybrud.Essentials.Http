using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Security;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Http;

/// <summary>
/// Various extension methods for <see cref="IHttpRequest"/>.
/// </summary>
public static class HttpRequestExtensions {

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Method"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="method">The new HTTP method of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetMethod<T>(this T? request, HttpMethod method) where T : IHttpRequest {
        if (request != null) request.Method = method;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Url"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="url">The new URL of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetUrl<T>(this T? request, string url) where T : IHttpRequest {
        if (request != null) request.Url = url;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.QueryString"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="queryString">The new query string of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetQueryString<T>(this T? request, IHttpQueryString? queryString) where T : IHttpRequest {
        if (request != null) request.QueryString = queryString!;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.PostData"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="postData">The new POST data of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetPostData<T>(this T? request, IHttpPostData? postData) where T : IHttpRequest {
        if (request != null) request.PostData = postData!;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, string? body) where T : IHttpRequest {
        if (request != null) request.Body = body;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <param name="contentType">The new content type of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, string? body, string? contentType) where T : IHttpRequest {
        if (request != null) request.Body = body;
        if (request != null) request.ContentType = contentType;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, byte[]? body) where T : HttpRequest {
        if (request != null) request.BinaryBody = body;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <param name="contentType">The new content type of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, byte[]? body, string? contentType) where T : HttpRequest {
        if (request != null) request.BinaryBody = body;
        if (request != null) request.ContentType = contentType;
        return request;
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, JToken? body) where T : IHttpRequest {
        return SetBody(request, body, Formatting.None);
    }

    /// <summary>
    /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="body">The new body of the request.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetBody<T>(this T? request, JToken? body, Formatting formatting) where T : IHttpRequest {
        if (request == null) return default;
        request.ContentType = HttpConstants.ApplicationJson;
        request.Body = body?.ToString(formatting);
        return request;
    }

    /// <summary>
    /// Sets the <strong>Accept</strong> header of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetAcceptHeader<T>(this T? request, string? value) where T : IHttpRequest {
        if (request != null) request.Accept = value;
        return request;
    }

    /// <summary>
    /// Sets the <strong>Accept</strong> header of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetAcceptHeader<T>(this T? request, IEnumerable<string>? value) where T : IHttpRequest {
        if (request != null) request.Accept = value == null ? null : string.Join(",", value);
        return request;
    }

    /// <summary>
    /// Sets the <strong>Authorization</strong> header of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetAuthorizationHeader<T>(this T? request, string? value) where T : IHttpRequest {
        if (request != null) request.Headers.Authorization = value;
        return request;
    }

    /// <summary>
    /// Sets the <strong>Authorization</strong> header of <paramref name="request"/> to use <strong>Basic</strong>
    /// authentication based on the specified <paramref name="username"/> and <paramref name="password"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetAuthorizationBasic<T>(this T? request, string username, string password) where T : IHttpRequest {
        if (request != null) request.Headers.Authorization = $"Basic {SecurityUtils.Base64Encode($"{username}:{password}")}";
        return request;
    }

    /// <summary>
    /// Sets the <strong>Authorization</strong> header of <paramref name="request"/> using the specified
    /// <strong>Bearer</strong> <paramref name="token"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="token">The bearer token.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetAuthorizationBearer<T>(this T? request, string token) where T : IHttpRequest {
        if (request != null) request.Headers.Authorization = $"Bearer {token}";
        return request;
    }

    /// <summary>
    /// Sets the <strong>ContentType</strong> header of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetContentType<T>(this T? request, string? value) where T : IHttpRequest {
        if (request != null) request.ContentType = value;
        return request;
    }

    /// <summary>
    /// Sets the <strong>SetUserAgent</strong> header of <paramref name="request"/>.
    /// </summary>
    /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="value">The value of the header.</param>
    /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
    [return: NotNullIfNotNull("request")]
    public static T? SetUserAgent<T>(this T? request, string? value) where T : IHttpRequest {
        if (request != null) request.UserAgent = value;
        return request;
    }

}