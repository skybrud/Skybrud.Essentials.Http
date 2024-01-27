using System.Net;

namespace Skybrud.Essentials.Http.Collections;

/// <summary>
/// Collection of cookies.
/// </summary>
public class HttpCookieCollection : IHttpCookieCollection {

    #region Properties

    /// <summary>
    /// Gets a reference to the internal instance of <see cref="CookieContainer"/>.
    /// </summary>
    public CookieContainer Container { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates an empty collection of headers.
    /// </summary>
    public HttpCookieCollection() {
        Container = new CookieContainer();
    }

    /// <summary>
    /// Creates a new instance based on the specified <paramref name="cookies"/>.
    /// </summary>
    public HttpCookieCollection(CookieContainer? cookies) {
        Container = cookies ?? new CookieContainer();
    }

    #endregion

}