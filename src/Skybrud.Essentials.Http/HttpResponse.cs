﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Wrapper class for <see cref="HttpWebResponse"/>.
    /// </summary>
    public class HttpResponse : IHttpResponse {

        private HttpHeaderCollection _headers;
        private byte[] _binary;
        private string _body;

        #region Properties

        /// <summary>
        /// Gets a reference to the <see cref="HttpRequest"/> that resulted in the response.
        /// </summary>
        public IHttpRequest Request { get; }

        /// <summary>
        /// Gets a reference to the underlying <see cref="HttpWebResponse"/>.
        /// </summary>
        public HttpWebResponse Response { get; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        public string StatusDescription => Response.StatusDescription;

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        public string Method => Response.Method;

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        public string ContentType => Response.ContentType;

        /// <summary>
        /// Gets a collections of headers returned by the server.
        /// </summary>
        public IHttpHeaderCollection Headers => _headers ?? (_headers = new HttpHeaderCollection(Response.Headers));

        /// <summary>
        /// Gets the URI of the response (eg. if the request was redirected).
        /// </summary>
        public Uri ResponseUri => Response.ResponseUri;

        /// <summary>
        /// Gets a reference to the <see cref="Encoding"/>. The underlying <see cref="HttpWebResponse"/> doesn't
        /// explicitly expode the encoding of the response, so the value of this property is a "best guess" based on
        /// the HTTP headers of the response.
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Gets the response body as a raw string.
        /// </summary>
        public string Body {
            get {
                if (_body == null) ReadResponseBody();
                return _body;
            }
        }
        
        /// <summary>
        /// Gets the response body as an array of <see cref="byte"/>.
        /// </summary>
        public byte[] BinaryBody {
            get {
                if (_binary == null) ReadResponseBody();
                return _binary;
            }
        }

        #endregion

        #region Constructor

        private HttpResponse(IHttpRequest request, HttpWebResponse response) {
            Request = request;
            Response = response;
            Encoding = DetectResponseEncoding();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Attemps to detect the encoding of the response body. The result is currently only based on the
        /// <c>Content-Type</c> HTTP header. If an encoding can't be detected, <c>UTF8</c> will be used as fallback.
        /// </summary>
        /// <returns>The <see cref="Encoding"/> of the response body.</returns>
        private Encoding DetectResponseEncoding() {

            // Information in the header is seperated by ";"
            foreach (string piece in (ContentType ?? "").Split(';')) {

                // Search for the charset
                Match regex = Regex.Match(piece.Trim().ToLowerInvariant(), "^charset=(.+?)$");

                if (regex.Success) {
                    switch (regex.Groups[1].Value) {
                        case "us-ascii": return Encoding.ASCII;
                        case "iso-8859-1":
                        case "windows-1252": return Encoding.GetEncoding(1252);
                        case "utf-7": return Encoding.UTF7;
                        case "utf-8": return Encoding.UTF8;
                        case "utf-16": return Encoding.Unicode;
                        case "utf-32": return Encoding.UTF32;
                    }
                }

            }

            // Use UTF8 as fallback
            return Encoding.UTF8;

        }

        /// <summary>
        /// Reads the response body from the response stream. The method will read the response body using an instance
        /// of <see cref="BinaryReader"/> with a buffer size of <c>4096 bytes</c>.
        /// </summary>
        private void ReadResponseBody() {

            // If "binary" isn't NULL, we have already read the response body
            // once, and the stream is therefore already disposed
            if (_binary != null) return;

            // Get a reference to the response stream (and dispose it once we're done)
            using (Stream stream = Response.GetResponseStream()) {
                
                // The stream really shouldn't be NULL, but just to be sure
                if (stream == null) return;

                // Read the response stream into a binary array
                using (BinaryReader reader = new BinaryReader(stream)) {
                    byte[] allBytes;
                    const int bufferSize = 4096;
                    using (var ms = new MemoryStream()) {
                        byte[] buffer = new byte[bufferSize];
                        int count;
                        while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                            ms.Write(buffer, 0, count);
                        allBytes = ms.ToArray();
                    }
                    _binary = allBytes;
                }

                // Convert the binary array into a raw text string
                _body = Encoding.GetString(_binary);

            }

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="HttpWebResponse"/> to be parsed.</param>
        /// <returns>A new instance of <see cref="HttpWebResponse"/> based on the specified <paramref name="response"/>.</returns>
        public static HttpResponse GetFromWebResponse(HttpWebResponse response) {
            return response == null ? null : new HttpResponse(null, response);
        }

        /// <summary>
        /// Creates a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="HttpWebResponse"/> to be parsed.</param>
        /// <param name="request">The instance of <see cref="HttpWebRequest"/> that resulted in the response.</param>
        /// <returns>A new instance of <see cref="HttpWebResponse"/> based on the specified <paramref name="response"/>.</returns>
        public static HttpResponse GetFromWebResponse(HttpWebResponse response, HttpRequest request) {
            return response == null ? null : new HttpResponse(request, response);
        }

        #endregion

    }

}