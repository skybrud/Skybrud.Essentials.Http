using System;
using System.Net;
using System.Text;
using Skybrud.Essentials.Http.Collections;
using System.Threading.Tasks;

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
        ICredentials? Credentials { get; set; }

        /// <summary>
        /// Gets or sets the URL of the request. The query string can either be specified directly in the URL, or
        /// separately through the <see cref="QueryString"/> property.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the HTTP host of the request. If left blank, the host will be based on <see cref="Url"/>
        /// instead.
        /// </summary>
        string? Host { get; set; }

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

        /// <summary>
        /// Gets or sets the <see cref="IHttpCookieCollection"/> to be used for the request.
        /// </summary>
        IHttpCookieCollection Cookies { get; set; }

        /// <summary>
        /// Gets or sets the content type of the request.
        /// </summary>
        string? ContentType { get; set; }

        /// <summary>
        /// Gets or sets the body of the request.
        /// </summary>
        string? Body { get; set; }

        /// <summary>
        /// Gets a or sets a list of content types that are acceptable for the response - eg. <c>text/html</c>,
        /// <c>text/html,application/xhtml+xml</c> or <c>application/json</c>. This property corresponds to the
        /// <c>Accept</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        string? Accept { get; set; }

        /// <summary>
        /// Gets or sets the character sets that are acceptable - eg. <c>utf8</c>. This property corresponds to
        /// the <c>Accept-Charset</c> HTTP header.
        /// </summary>
        string? AcceptCharset { get; set; }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <c>gzip</c> or <c>gzip, deflate</c>. This
        /// property corresponds to the <c>Accept-Encoding</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        string? AcceptEncoding { get; set; }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <c>en-US</c>, <c>en</c> or <c>da</c>. This
        /// property corresponds to the <c>Accept-Language</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        string? AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <c>Authorization</c> HTTP header.
        /// </summary>
        string? Authorization { get; set; }

        /// <summary>
        /// Gets or sets the address of the previous web page from which a link to the currently requested page was
        /// followed. (The word "referrer" has been misspelled in the RFC as well as in most implementations to the
        /// point that it has become standard usage and is considered correct terminology). This property corresponds
        /// to the <c>Referer</c> HTTP header.
        /// </summary>
        string? Referer { get; set; }

        /// <summary>
        /// Gets or sets a string representing the user agent. This property corresponds to the <c>User-Agent</c>
        /// HTTP header.
        /// </summary>
        string? UserAgent { get; set; }

#if NET_FRAMEWORK_OR_NET_STANDARD_2

        /// <summary>
        /// Gets or sets the type of decompression that is used.
        /// </summary>
        DecompressionMethods AutomaticDecompression { get; set; }

        /// <summary>
        /// Gets or sets the media type of the request.
        /// </summary>
        string? MediaType { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Transfer-encoding</strong> HTTP header.
        /// </summary>
        string? TransferEncoding { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Connection</strong> HTTP header.
        /// </summary>
        string? Connection { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Expect</strong> HTTP header.
        /// </summary>
        string? Expect { get; set; }

#endif

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="IHttpResponse"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        IHttpResponse GetResponse();

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="IHttpResponse"/>.
        /// </summary>
        /// <returns>An instance of <see cref="Task"/> representing the response.</returns>
        Task<IHttpResponse> GetResponseAsync();

    }

}