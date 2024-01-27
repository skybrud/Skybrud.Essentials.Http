using System;
using Skybrud.Essentials.Http.OAuth.Models;

namespace Skybrud.Essentials.Http.OAuth.Responses;

/// <summary>
/// Class representing the response of a call to get an OAuth 1.0a request token.
/// </summary>
public class OAuthRequestTokenResponse : HttpResponseBase {

    #region Properties

    /// <summary>
    /// Gets a reference to the response body.
    /// </summary>
    public OAuthRequestToken Body { get; protected set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="response">The raw response.</param>
    /// <param name="body">The object representing the response body.</param>
    protected OAuthRequestTokenResponse(IHttpResponse response, OAuthRequestToken body) : base(response) {
        Body = body;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="response">The raw response.</param>
    /// <param name="body">The object representing the response body.</param>
    /// <returns>An instance of <see cref="OAuthRequestTokenResponse"/>.</returns>
    public static OAuthRequestTokenResponse ParseResponse(IHttpResponse response, OAuthRequestToken body) {
        if (response == null) throw new ArgumentNullException(nameof(response));
        return new OAuthRequestTokenResponse(response, body);
    }

    #endregion

}