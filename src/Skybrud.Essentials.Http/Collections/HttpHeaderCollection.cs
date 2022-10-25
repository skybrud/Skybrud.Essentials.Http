﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Skybrud.Essentials.Http.Collections {

    /// <summary>
    /// Collection of HTTP headers.
    /// </summary>
    public class HttpHeaderCollection : IHttpHeaderCollection {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <see cref="WebHeaderCollection"/>.
        /// </summary>
        public WebHeaderCollection Headers { get; }

        /// <summary>
        /// Gets or sets the character sets that are acceptable - eg. <c>utf8</c>. This property corresponds to
        /// the <c>Accept-Charset</c> HTTP header.
        /// </summary>
        public string? AcceptCharset {
            get => Headers["Accept-Charset"];
            set => Headers["Accept-Charset"] = value;
        }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <c>gzip</c> or <c>gzip, deflate</c>. This
        /// property corresponds to the <c>Accept-Encoding</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        public string? AcceptEncoding {
            get => Headers["Accept-Encoding"];
            set => Headers["Accept-Encoding"] = value;
        }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <c>en-US</c>, <c>en</c> or
        /// <c>da</c>. This property corresponds to the <c>Accept-Language</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string? AcceptLanguage {
            get => Headers["Accept-Language"];
            set => Headers["Accept-Language"] = value;
        }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <c>Authorization</c> HTTP header.
        /// </summary>
        public string? Authorization {
            get => Headers["Authorization"];
            set => Headers["Authorization"] = value;
        }

        /// <summary>
        /// Gets amount of headers added to the collection.
        /// </summary>
        public int Count => Headers.Count;

        /// <summary>
        /// Gets a <see cref="System.String"/> array representing the keys of the header collection.
        /// </summary>
        public string[] Keys => Headers.AllKeys.ToArray();

        /// <summary>
        /// Gets or set the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the header.</param>
        /// <returns>The value of the header.</returns>
        public string? this[string key] {
            get => Headers[key];
            set => Headers[key] = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an empty collection of headers.
        /// </summary>
        public HttpHeaderCollection() {
            Headers = new WebHeaderCollection();
        }

        /// <summary>
        /// Creates a new instance based on the specified <paramref name="headers"/>.
        /// </summary>
        public HttpHeaderCollection(WebHeaderCollection? headers) {
            Headers = headers ?? new WebHeaderCollection();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Add(string name, string value) {
            Headers[name] = value;
        }

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Add(string name, object value) {
            Headers[name] = string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return Headers.AllKeys.Select(x => new KeyValuePair<string, string>(x, Headers[x]!)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Creates a new instance from the specified <paramref name="headers"/>.
        /// </summary>
        /// <param name="headers">The <see cref="WebHeaderCollection"/> representing the headers.</param>
        public static implicit operator HttpHeaderCollection(WebHeaderCollection? headers) {

            // Initialize a new instance of HttpHeaderCollection
            HttpHeaderCollection collection = new(headers);

            return collection;

        }

        #endregion

    }

}