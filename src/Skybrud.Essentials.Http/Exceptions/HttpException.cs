using System;
using System.Net;

namespace Skybrud.Essentials.Http.Exceptions;

/// <summary>
/// Class representing a basic HTTP exception.
/// </summary>
public class HttpException : Exception, IHttpException {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
    /// </summary>
    public IHttpResponse Response { get; }

    /// <summary>
    /// Gets the HTTP status code returned by the Toggl API.
    /// </summary>
    public HttpStatusCode StatusCode => Response.StatusCode;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public HttpException(IHttpResponse response) : base($"Invalid response received (status: {(int) response.StatusCode})") {
        Response = response;
    }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="message"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    /// <param name="message">The message for the exception.</param>
    public HttpException(IHttpResponse response, string message) : base(message) {
        Response = response;
    }

    #endregion

}