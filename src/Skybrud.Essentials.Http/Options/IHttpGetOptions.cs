﻿using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http.Options {

    /// <summary>
    /// Interface representing the options of a HTTP GET request.
    /// </summary>
    public interface IHttpGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        IHttpQueryString GetQueryString();

        #endregion

    }

}