using Skybrud.Essentials.Http.Options;

namespace Skybrud.Essentials.Http.Client {

    /// <summary>
    /// Interface describing a client for making HTTP requests.
    /// </summary>
    public interface IHttpClient2 {

        /// <summary>
        /// Returns the response of the request identified by the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        IHttpResponse GetResponse(IHttpRequestOptions options);

        /// <summary>
        /// Sends a new request as described by <paramref name="request"/> and returns the response.
        /// </summary>
        /// <param name="request">An instance of <see cref="IHttpRequest"/> describing the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        IHttpResponse GetResponse(IHttpRequest request);

    }

}