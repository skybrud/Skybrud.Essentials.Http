using Skybrud.Essentials.Http.Options;
using System.Threading.Tasks;

namespace Skybrud.Essentials.Http.Client;

/// <summary>
/// Interface describing a client for making async HTTP requests.
/// </summary>
public interface IHttpClientAsync {

    /// <summary>
    /// Sends a new request as described by <paramref name="request"/> and returns the response.
    /// </summary>
    /// <param name="request">An instance of <see cref="IHttpRequest"/> describing the request.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    Task<IHttpResponse> GetResponseAsync(IHttpRequest request);

    /// <summary>
    /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
    /// </summary>
    /// <param name="options">The options describing the request.</param>
    /// <returns>An instance of <see cref="HttpResponse"/> representing the response.</returns>
    Task<IHttpResponse> GetResponseAsync(IHttpRequestOptions options);

}