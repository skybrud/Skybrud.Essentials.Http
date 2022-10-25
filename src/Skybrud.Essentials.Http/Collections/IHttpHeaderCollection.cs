using System.Collections.Generic;
using System.Net;

namespace Skybrud.Essentials.Http.Collections {

    /// <summary>
    /// Interface describing a collection of HTTP headers.
    /// </summary>
    public interface IHttpHeaderCollection : IEnumerable<KeyValuePair<string, string>> {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <see cref="WebHeaderCollection"/>.
        /// </summary>
        WebHeaderCollection Headers { get; }

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
        /// Gets or sets the accept language header of the request - eg. <c>en-US</c>, <c>en</c> or
        /// <c>da</c>. This property corresponds to the <c>Accept-Language</c> HTTP header.
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
        /// Gets amount of headers added to the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a <see cref="System.String"/> array representing the keys of the header collection.
        /// </summary>
        string[] Keys { get; }

        /// <summary>
        /// Gets or set the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the header.</param>
        /// <returns>The value of the header.</returns>
        string? this[string key] { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        void Add(string name, string value);

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        void Add(string name, object value);

        #endregion

    }

}