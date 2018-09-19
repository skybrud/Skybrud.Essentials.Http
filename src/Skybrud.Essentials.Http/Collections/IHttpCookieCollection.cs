using System.Net;

namespace Skybrud.Essentials.Http.Collections {

    /// <summary>
    /// Interface describing a collection of cookies.
    /// </summary>
    public interface IHttpCookieCollection {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <see cref="CookieContainer"/>.
        /// </summary>
        CookieContainer Container { get; }

        #endregion

    }

}