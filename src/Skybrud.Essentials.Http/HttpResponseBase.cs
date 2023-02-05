using System;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Xml;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Http {

    /// <summary>
    /// Class representing a response from a call to a server. Generally this class (or other classes inheriting from
    /// this class) should be used to represent the object oriented (parsed) response wrapping an instance of
    /// <see cref="HttpResponse"/> (raw response).
    /// </summary>
    public class HttpResponseBase {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying raw response.
        /// </summary>
        public IHttpResponse Response { get; }

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
        /// Gets a collection of headers returned by the server.
        /// </summary>
        public IHttpHeaderCollection Headers => Response.Headers;

        /// <summary>
        /// /// Gets the URI of the response (may differ from the requested URI - eg. if the request was redirected).
        /// </summary>
        public Uri ResponseUri => Response.ResponseUri;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected HttpResponseBase(IHttpResponse response) {
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <see cref="JToken"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static JToken ParseJsonToken(string json) {
            return JsonUtils.ParseJsonToken(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T ParseJsonToken<T>(string json) {
            return JsonUtils.ParseJsonToken<T>(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JToken"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T ParseJsonToken<T>(string json, Func<JToken, T> func) {
            return JsonUtils.ParseJsonToken(json, func);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static JObject ParseJsonObject(string json) {
            return JsonUtils.ParseJsonObject(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonObject(json, func);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JArray"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static JArray ParseJsonArray(string json) {
            return JsonUtils.ParseJsonArray(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonArray(json, func);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JToken"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonToken(string json, [NotNullWhen(true)] out JToken? result) {
            return JsonUtils.TryParseJsonToken(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output object.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonToken<T>(string json, [NotNullWhen(true)] out T? result) {
            return JsonUtils.TryParseJsonToken(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output object.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="callback">A callback function used for converting a <see cref="JToken"/> into an instance of <typeparamref name="T"/>.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonToken<T>(string json, Func<JToken, T> callback, [NotNullWhen(true)] out T? result) {
            return JsonUtils.TryParseJsonToken(json, callback, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonObject(string json, [NotNullWhen(true)] out JObject? result) {
            return JsonUtils.TryParseJsonObject(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output object.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonObject<T>(string json, [NotNullWhen(true)] out T? result) {
            return JsonUtils.TryParseJsonObject(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output object.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="callback">A callback function used for converting a <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonObject<T>(string json, Func<JObject, T> callback, [NotNullWhen(true)] out T? result) {
            return JsonUtils.TryParseJsonObject(json, callback, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed <see cref="JArray"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonArray(string json, [NotNullWhen(true)] out JArray? result) {
            return JsonUtils.TryParseJsonArray(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output Array.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonArray<T>(string json, [NotNullWhen(true)] out T[]? result) {
            return JsonUtils.TryParseJsonArray(json, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output array.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="callback">A callback function used for converting a <see cref="JArray"/> into an instance of <typeparamref name="T"/>.</param>
        /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonArray<T>(string json, Func<JArray, T[]> callback, [NotNullWhen(true)] out T[]? result) {
            return JsonUtils.TryParseJsonArray(json, callback, out result);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the output array.</typeparam>
        /// <param name="json">The JSON string to parse.</param>
        /// <param name="callback">A callback function used for converting the individual <see cref="JObject"/> of the parsed array into instances of <typeparamref name="T"/>.</param>
        /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
        protected static bool TryParseJsonArray<T>(string json, Func<JObject, T> callback, [NotNullWhen(true)] out T[]? result) {
            return JsonUtils.TryParseJsonArray(json, callback, out result);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>An instance of <see cref="XElement"/>.</returns>
        protected static XElement ParseXmlElement(string xml) {
            return XmlUtils.ParseXmlElement(xml);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>, which is then converted
        /// into an instance of <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converting the parsed <see cref="XElement"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the specified <paramref name="xml"/>.</returns>
        protected static T ParseXmlElement<T>(string xml, Func<XElement, T> callback) {
            return XmlUtils.ParseXmlElement(xml, callback);
        }

        #endregion

    }

}