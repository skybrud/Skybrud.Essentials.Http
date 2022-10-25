using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Various extension methods for <see cref="IHttpRequest"/>.
    /// </summary>
    public static class HttpRequestXmlExtensions {

        /// <summary>
        /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="body">The new body of the request.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        [return: NotNullIfNotNull("request")]
        public static T? SetBody<T>(this T? request, XNode? body) where T : IHttpRequest {
            return SetBody(request, body, SaveOptions.None);
        }

        /// <summary>
        /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="body">The new body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        [return: NotNullIfNotNull("request")]
        public static T? SetBody<T>(this T? request, XNode? body, SaveOptions options) where T : IHttpRequest {
            if (request == null) return default;
            request.ContentType = HttpConstants.TextXml;
            request.Body = body?.ToString(options);
            return request;
        }

        /// <summary>
        /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="contentType">The new content type of the request.</param>
        /// <param name="body">The new body of the request.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        [return: NotNullIfNotNull("request")]
        public static T? SetBody<T>(this T? request, string? contentType, XNode? body) where T : IHttpRequest {
            return SetBody(request, contentType, body, SaveOptions.None);
        }

        /// <summary>
        /// Sets the <see cref="IHttpRequest.Body"/> property of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="contentType">The new content type of the request.</param>
        /// <param name="body">The new body of the request.</param>
        /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        [return: NotNullIfNotNull("request")]
        public static T? SetBody<T>(this T? request, string? contentType, XNode? body, SaveOptions options) where T : IHttpRequest {
            if (request == null) return default;
            request.ContentType = contentType;
            request.Body = body?.ToString(options);
            return request;
        }

    }

}