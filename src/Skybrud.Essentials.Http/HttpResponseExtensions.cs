using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Static class with various extension methods for <see cref="IHttpResponse"/>.
    /// </summary>
    public static class HttpResponseExtensions {

        /// <summary>
        /// Throws a <see cref="HttpException"/> exception if <paramref name="response"/> doesn't have a successful status code.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns><paramref name="response"/> - useful for method chaining.</returns>
        /// <exception cref="HttpException">If <paramref name="response"/> doesn't have a successful status code.</exception>
        public static IHttpResponse ThrowIfNotSuccessful(this IHttpResponse response) {
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.Created) return response;
            throw new HttpException(response);
        }

        /// <summary>
        /// Throw a new <see cref="HttpException"/> exception if the response of <paramref name="task"/> doesn't have a successful status code.
        /// </summary>
        /// <param name="task">The task holding the response.</param>
        /// <returns><paramref name="task"/> - useful for method chaining.</returns>
        /// <exception cref="HttpException">If the response of <paramref name="task"/> doesn't have a successful status code.</exception>
        public static async Task<IHttpResponse> ThrowIfNotSuccessful(this Task<IHttpResponse> task) {
            IHttpResponse response = await task;
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.Created) return response;
            throw new HttpException(response);
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <see cref="JToken"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="JToken"/> representing the deserialized value.</returns>
        public static JToken AsJson(this IHttpResponse response) {
            return JsonUtils.ParseJsonToken(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static T AsJson<T>(this IHttpResponse response) {
            return JsonUtils.ParseJsonToken<T>(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="callback">A callback function used for converting the response body from <see cref="JToken"/> to <typeparamref name="T"/></param>
        /// <returns>An instance of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static T AsJson<T>(this IHttpResponse response, Func<JToken, T> callback) {
            return callback(JsonUtils.ParseJsonToken<JToken>(response.Body));
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="callback">A callback function used for converting the response body from <see cref="JObject"/> to <typeparamref name="T"/></param>
        /// <returns>An instance of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static T AsJson<T>(this IHttpResponse response, Func<JObject, T> callback) {
            return callback(JsonUtils.ParseJsonToken<JObject>(response.Body));
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="JArray"/> representing the deserialized value.</returns>
        public static JArray AsJsonArray(this IHttpResponse response) {
            return JsonUtils.ParseJsonArray(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the specified <paramref name="response"/> into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="callback">A callback function used for converting the response body from a <see cref="JObject"/> array to an array of <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static T[] AsJsonArray<T>(this IHttpResponse response, Func<JObject, T> callback) {
            return JsonUtils.ParseJsonArray(response.Body, callback);
        }

        /// <summary>
        /// Deserializes the response body of the response of the specified <paramref name="task"/> into an instance of <see cref="JToken"/>.
        /// </summary>
        /// <param name="task">A task wrapping the response.</param>
        /// <returns>An instance of <see cref="JToken"/> representing the deserialized value.</returns>
        public static async Task<JToken> AsJson(this Task<IHttpResponse> task) {
            IHttpResponse response = await task;
            return JsonUtils.ParseJsonToken(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the response of the specified <paramref name="task"/> into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="task">A task wrapping the response.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static async Task<T> AsJson<T>(this Task<IHttpResponse> task) {
            IHttpResponse response = await task;
            return JsonUtils.ParseJsonToken<T>(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the response of the specified <paramref name="task"/> into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="task">A task wrapping the response.</param>
        /// <returns>An instance of <see cref="JArray"/> representing the deserialized value.</returns>
        public static async Task<JArray> AsJsonArray(this Task<IHttpResponse> task) {
            IHttpResponse response = await task;
            return JsonUtils.ParseJsonArray(response.Body);
        }

        /// <summary>
        /// Deserializes the response body of the response of the specified <paramref name="task"/> into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="task">A task wrapping the response.</param>
        /// <param name="callback">A callback function used for converting the response body from <see cref="JObject"/> to <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> representing the deserialized value.</returns>
        public static async Task<T[]> AsJsonArray<T>(this Task<IHttpResponse> task, Func<JObject, T> callback) {
            IHttpResponse response = await task;
            return JsonUtils.ParseJsonArray(response.Body, callback);
        }

    }

}