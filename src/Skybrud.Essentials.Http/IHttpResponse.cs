using System;
using System.Net;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Interface representing a HTTP response.
    /// </summary>
    public interface IHttpResponse {

        /// <summary>
        /// Gets a reference to the <see cref="HttpRequest"/> that resulted in the response.
        /// </summary>
        IHttpRequest? Request { get; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        string StatusDescription { get; }

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        string Method { get; }

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets a collections of headers returned by the server.
        /// </summary>
        IHttpHeaderCollection Headers { get; }

        /// <summary>
        /// Gets the URI of the response (eg. if the request was redirected).
        /// </summary>
        Uri ResponseUri { get; }

        /// <summary>
        /// Gets the response body as a raw string.
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets the response body as an array of <see cref="byte"/>.
        /// </summary>
        byte[] BinaryBody { get; }

    }

}