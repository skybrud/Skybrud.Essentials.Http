using System;
using System.Net;
using System.Text;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Interface describing a HTTP request.
    /// </summary>
    public interface IHttpRequest {

        /// <summary>
        /// Gets or sets the HTTP method of the request.
        /// </summary>
        HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the credentials (username and password) of the request.
        /// </summary>
        ICredentials Credentials { get; set; }

        /// <summary>
        /// Gets or sets the URL of the request. The query string can either be specified directly in the URL, or
        /// separately through the <see cref="QueryString"/> property.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the HTTP host of the request. If left blank, the host will be based on <see cref="Url"/>
        /// instead.
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the encoding of the request. Default is UTF-8.
        /// </summary>
        Encoding Encoding { get; set; }

#if NET_FRAMEWORK

        /// <summary>
        /// Gets or sets the timeout of the request. Default is 100 seconds.
        /// </summary>
        TimeSpan Timeout { get; set; }

#endif

        /// <summary>
        /// Gets or sets the collection of headers.
        /// </summary>
        IHttpHeaderCollection Headers { get; set; }

        /// <summary>
        /// Gets or sets the query string of the request.
        /// </summary>
        IHttpQueryString QueryString { get; set; }

        /// <summary>
        /// Gets or sets the POST data of the request.
        /// </summary>
        IHttpPostData PostData { get; set; }

    }

}