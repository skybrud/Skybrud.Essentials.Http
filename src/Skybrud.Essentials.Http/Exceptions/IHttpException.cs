using System.Net;

namespace Skybrud.Essentials.Http.Exceptions {

    /// <summary>
    /// Interface representing an error response as the result of a HTTP request.
    /// </summary>
    interface IHttpException {

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code of the response.
        /// </summary>
        HttpStatusCode StatusCode { get; }

    }

}