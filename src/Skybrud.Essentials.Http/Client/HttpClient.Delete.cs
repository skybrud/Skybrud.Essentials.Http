using System;
using System.Collections.Specialized;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Essentials.Http.Client;

public partial class HttpClient {

    /// <summary>
    /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual IHttpResponse Delete(string url) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return GetResponse(HttpRequest.Delete(url));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
    public virtual IHttpResponse Delete(string url, IHttpGetOptions options) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        if (options == null) throw new ArgumentNullException(nameof(options));
        return GetResponse(HttpRequest.Delete(url, options.GetQueryString()));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual IHttpResponse Delete(string url, IHttpQueryString? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return GetResponse(HttpRequest.Delete(url, queryString));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual IHttpResponse Delete(string url, NameValueCollection? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return GetResponse(HttpRequest.Delete(url, query));
    }

}