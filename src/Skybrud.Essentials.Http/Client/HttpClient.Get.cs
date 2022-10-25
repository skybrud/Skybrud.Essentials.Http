using System;
using System.Collections.Specialized;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Essentials.Http.Client {

    public partial class HttpClient {

        /// <summary>
        /// Makes a HTTP GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Get(string url) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Get(url));
        }

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <paramref name="url"/>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        [Obsolete("Use 'GetResponse' method and 'IHttpRequestOptions' class as parameter instead.")]
        public virtual IHttpResponse Get(string url, IHttpGetOptions options) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetResponse(HttpRequest.Get(url, options.GetQueryString()));
        }

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Get(string url, IHttpQueryString queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            return GetResponse(HttpRequest.Get(url, queryString));
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        public virtual IHttpResponse Get(string url, NameValueCollection? queryString) {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            IHttpQueryString? query = queryString == null ? null : new HttpQueryString(queryString);
            return GetResponse(HttpRequest.Get(url, query));
        }

#endif

    }

}