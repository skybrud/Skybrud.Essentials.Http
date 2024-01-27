using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http.Client;

public partial class HttpClient {

    /// <summary>
    /// Makes a HTTP DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> DeleteAsync(string url) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Delete(url));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> DeleteAsync(string url, IHttpQueryString? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        return await GetResponseAsync(HttpRequest.Delete(url, queryString));
    }

    /// <summary>
    /// Makes a DELETE request to the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> DeleteAsync(string url, NameValueCollection? queryString) {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
        IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
        return await GetResponseAsync(HttpRequest.Delete(url, query));
    }

}