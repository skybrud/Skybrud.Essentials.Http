using System;
using Skybrud.Essentials.Http.OAuth.Models;

namespace Skybrud.Essentials.Http.OAuth.Responses;

/// <summary>
/// Class representing the response of a call to get an OAuth 1.0a access token.
/// </summary>
public class OAuthAccessTokenResponse : HttpResponseBase {

    #region Properties

    /// <summary>
    /// Gets a reference to the response body.
    /// </summary>
    public OAuthAccessToken Body { get; protected set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="response">The raw response.</param>
    /// <param name="body">The object representing the response body.</param>
    protected OAuthAccessTokenResponse(IHttpResponse response, OAuthAccessToken body) : base(response) {
        Body = body;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="response">The raw response.</param>
    /// <param name="body">The object representing the response body.</param>
    /// <returns>An instance of <see cref="OAuthAccessTokenResponse"/>.</returns>
    public static OAuthAccessTokenResponse ParseResponse(IHttpResponse response, OAuthAccessToken body) {
        if (response == null) throw new ArgumentNullException(nameof(response));
        return new OAuthAccessTokenResponse(response, body);
    }

    #endregion

}