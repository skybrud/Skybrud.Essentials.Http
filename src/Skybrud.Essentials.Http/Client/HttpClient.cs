using System;
using Skybrud.Essentials.Http.Options;
using System.Threading.Tasks;

// ReSharper disable ArrangeDefaultValueWhenTypeNotEvident

namespace Skybrud.Essentials.Http.Client;

/// <summary>
/// Class representing a client for making HTTP requests.
/// </summary>
public partial class HttpClient : IHttpClient, IHttpClientAsync {

    #region Other

    /// <summary>
    /// Returns the response of the request identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual IHttpResponse GetResponse(IHttpRequestOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        IHttpRequest request = options.GetRequest();
        PrepareHttpRequest(request);
        return request.GetResponse();
    }

    /// <summary>
    /// Sends a new request as described by <paramref name="request"/> and returns the response.
    /// </summary>
    /// <param name="request">An instance of <see cref="IHttpRequest"/> describing the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public virtual IHttpResponse GetResponse(IHttpRequest request) {
        if (request == null) throw new ArgumentNullException(nameof(request));
        PrepareHttpRequest(request);
        return request.GetResponse();
    }

    /// <summary>
    /// Executes a new the request described by the specified <paramref name="options"/> and returns the
    /// response as an instance of <see cref="IHttpResponse"/>.
    /// </summary>
    /// <returns>An instance of <see cref="Task{IHttpResponse}"/> representing the response.</returns>
    public async Task<IHttpResponse> GetResponseAsync(IHttpRequestOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        IHttpRequest request = options.GetRequest();
        PrepareHttpRequest(request);
        return await request.GetResponseAsync();
    }

    /// <summary>
    /// Executes the specified <paramref name="request"/> and returns the response as an instance of
    /// <see cref="IHttpResponse"/>.
    /// </summary>
    /// <param name="request">An instance of <see cref="IHttpRequest"/> describing the request.</param>
    /// <returns>An instance of <see cref="Task{IHttpResponse}"/> representing the raw response.</returns>
    public virtual async Task<IHttpResponse> GetResponseAsync(IHttpRequest request) {
        if (request == null) throw new ArgumentNullException(nameof(request));
        PrepareHttpRequest(request);
        return await request.GetResponseAsync();
    }

    /// <summary>
    /// Virtual method that can be used for configuring a request.
    /// </summary>
    /// <param name="request">The request.</param>
    protected virtual void PrepareHttpRequest(IHttpRequest request) { }

    #endregion

}