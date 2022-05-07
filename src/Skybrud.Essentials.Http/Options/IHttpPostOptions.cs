using Skybrud.Essentials.Http.Collections;
using System;

namespace Skybrud.Essentials.Http.Options {

    /// <summary>
    /// Interface representing the options of a HTTP POST request.
    /// </summary>
    [Obsolete("Use 'IHttpRequestOptions' class instead.")]
    public interface IHttpPostOptions : IHttpGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST data.
        /// </summary>
        IHttpPostData GetPostData();

        #endregion

    }

}