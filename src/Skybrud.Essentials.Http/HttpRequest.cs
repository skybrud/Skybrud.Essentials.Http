﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using System.Xml.Linq;

#pragma warning disable SYSLIB0014

// ReSharper disable ConvertToUsingDeclaration
// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Http;

/// <summary>
/// Wrapper class for <see cref="HttpWebResponse"/>.
/// </summary>
public partial class HttpRequest : IHttpRequest {

    #region Private fields

    private IHttpHeaderCollection _headers = new HttpHeaderCollection();
    private IHttpQueryString _queryString = new HttpQueryString();
    private IHttpPostData _postData = new HttpPostData();
    private IHttpCookieCollection _cookies = new HttpCookieCollection();

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the HTTP method of the request.
    /// </summary>
    public HttpMethod Method { get; set; }

    /// <summary>
    /// Gets or sets the credentials (username and password) of the request.
    /// </summary>
    public ICredentials? Credentials { get; set; }

    /// <summary>
    /// Gets or sets the URL of the request. The query string can either be specified directly in the URL, or
    /// separately through the <see cref="QueryString"/> property.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the HTTP host of the request. If left blank, the host will be based on <see cref="Url"/>
    /// instead.
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// Gets or sets the encoding of the request. Default is UTF-8.
    /// </summary>
    public Encoding Encoding { get; set; }

    /// <summary>
    /// Gets or sets the timeout of the request. Default is 100 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; }

    /// <summary>
    /// Gets or sets the collection of headers.
    /// </summary>
    public IHttpHeaderCollection Headers {
        get => _headers;
        set => _headers = value ?? new HttpHeaderCollection();
    }

    /// <summary>
    /// Gets or sets the query string of the request.
    /// </summary>
    public IHttpQueryString QueryString {
        get => _queryString;
        set => _queryString = value ?? new HttpQueryString();
    }

    /// <summary>
    /// Gets or sets the POST data of the request.
    /// </summary>
    public IHttpPostData PostData {
        get => _postData;
        set => _postData = value ?? new HttpPostData();
    }

    /// <summary>
    /// Gets or sets the <see cref="IHttpCookieCollection"/> to be used for the request.
    /// </summary>
    public IHttpCookieCollection Cookies {
        get => _cookies;
        set => _cookies = value ?? new HttpCookieCollection();
    }

    /// <summary>
    /// Gets or sets the content type of the request.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    /// Gets or sets the body of the request.
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// Gets or sets the binary body of the request.
    /// </summary>
    public byte[]? BinaryBody { get; set; }

    #region HTTP Headers

    /// <summary>
    /// Gets a or sets a list of content types that are acceptable for the response - eg. <c>text/html</c>,
    /// <c>text/html,application/xhtml+xml</c> or <c>application/json</c>. This property corresponds to the
    /// <c>Accept</c> HTTP header.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
    /// </see>
    public string? Accept { get; set; }

    /// <summary>
    /// Gets or sets the character sets that are acceptable - eg. <c>utf8</c>. This property corresponds to
    /// the <c>Accept-Charset</c> HTTP header.
    /// </summary>
    public string? AcceptCharset {
        get => Headers.AcceptCharset;
        set => Headers.AcceptCharset = value;
    }

    /// <summary>
    /// Gets or sets the a list of acceptable encodings - eg. <c>gzip</c> or <c>gzip, deflate</c>. This
    /// property corresponds to the <c>Accept-Encoding</c> HTTP header.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
    /// </see>
    public string? AcceptEncoding {
        get => Headers.AcceptEncoding;
        set => Headers.AcceptEncoding = value;
    }

    /// <summary>
    /// Gets or sets the accept language header of the request - eg. <c>en-US</c>, <c>en</c> or <c>da</c>. This
    /// property corresponds to the <c>Accept-Language</c> HTTP header.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
    /// </see>
    public string? AcceptLanguage {
        get => Headers.AcceptLanguage;
        set => Headers.AcceptLanguage = value;
    }

    /// <summary>
    /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
    /// <c>Authorization</c> HTTP header.
    /// </summary>
    public string? Authorization {
        get => Headers.Authorization;
        set => Headers.Authorization = value;
    }

    /// <summary>
    /// Gets or sets the address of the previous web page from which a link to the currently requested page was
    /// followed. (The word "referrer" has been misspelled in the RFC as well as in most implementations to the
    /// point that it has become standard usage and is considered correct terminology). This property corresponds
    /// to the <c>Referer</c> HTTP header.
    /// </summary>
    public string? Referer { get; set; }

    /// <summary>
    /// Gets or sets a string representing the user agent. This property corresponds to the <c>User-Agent</c>
    /// HTTP header.
    /// </summary>
    public string? UserAgent { get; set; }

    #endregion

    /// <summary>
    /// Gets or sets the type of decompression that is used.
    /// </summary>
    public DecompressionMethods AutomaticDecompression { get; set; }

    /// <summary>
    /// Gets or sets the media type of the request.
    /// </summary>
    public string? MediaType { get; set; }

    /// <summary>
    /// Gets or sets the value of the <strong>Transfer-encoding</strong> HTTP header.
    /// </summary>
    public string? TransferEncoding { get; set; }

    /// <summary>
    /// Gets or sets the value of the <strong>Connection</strong> HTTP header.
    /// </summary>
    public string? Connection { get; set; }

    /// <summary>
    /// Gets or sets the value of the <strong>Expect</strong> HTTP header.
    /// </summary>
    public string? Expect { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new request with default options.
    /// </summary>
    public HttpRequest() {
        Method = HttpMethod.Get;
        Encoding = Encoding.UTF8;
        Url = string.Empty;
        Timeout = TimeSpan.FromSeconds(100);
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/> and <paramref name="url"/>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request. The query string may be part of the specified URL or via the <see cref="QueryString"/> property.</param>
    public HttpRequest(HttpMethod method, string url) : this() {
        Method = method;
        Url = url;
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/>, <paramref name="url"/> and <paramref name="queryString"/>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public HttpRequest(HttpMethod method, string url, IHttpQueryString? queryString) : this() {
        Method = method;
        Url = url;
        QueryString = queryString!;
    }

    /// <summary>
    /// Initializes a new request on the specified <paramref name="method"/>, <paramref name="url"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The HTTP POST data of the request.</param>
    public HttpRequest(HttpMethod method, string url, IHttpPostData? postData) : this() {
        Method = method;
        Url = url;
        PostData = postData!;
    }

    /// <summary>
    /// Initializes a new request on the specified <paramref name="method"/>, <paramref name="url"/>, <paramref name="queryString"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The HTTP POST data of the request.</param>
    public HttpRequest(HttpMethod method, string url, IHttpQueryString? queryString, IHttpPostData? postData) : this() {
        Method = method;
        Url = url;
        QueryString = queryString!;
        PostData = postData!;
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/>, <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this constructor, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public HttpRequest(HttpMethod method, string url, JToken body) : this() {
        Method = method;
        Url = url;
        ContentType = HttpConstants.ApplicationJson;
        Body = body?.ToString(Formatting.None);
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/>, <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this constructor, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public HttpRequest(HttpMethod method, string url, JToken body, Formatting formatting) : this() {
        Method = method;
        Url = url;
        ContentType = HttpConstants.ApplicationJson;
        Body = body?.ToString(formatting);
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/>, <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this constructor, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public HttpRequest(HttpMethod method, string url, IHttpQueryString? queryString, JToken body) : this() {
        Method = method;
        Url = url;
        QueryString = queryString!;
        ContentType = HttpConstants.ApplicationJson;
        Body = body?.ToString(Formatting.None);
    }

    /// <summary>
    /// Initializes a new request based on the specified <paramref name="method"/>, <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this constructor, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="method">The HTTP method for the request - eg. <see cref="HttpMethod.Get"/> or <see cref="HttpMethod.Post"/>.</param>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public HttpRequest(HttpMethod method, string url, IHttpQueryString? queryString, JToken body, Formatting formatting) : this() {
        Method = method;
        Url = url;
        QueryString = queryString!;
        ContentType = HttpConstants.ApplicationJson;
        Body = body?.ToString(formatting);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    public virtual IHttpResponse GetResponse() {
        return GetResponse(null);
    }

    /// <summary>
    /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
    /// </summary>
    /// <param name="callback">Lets you specify a callback method for modifying the underlying <see cref="HttpWebRequest"/>.</param>
    /// <returns>An instance of <see cref="HttpResponse"/> representing the response.</returns>
    public virtual IHttpResponse GetResponse(Action<HttpWebRequest>? callback) {

        // Build the URL
        if (string.IsNullOrWhiteSpace(Url)) throw new PropertyNotSetException(nameof(Url));
        string url = Url;
        if (!QueryString.IsEmpty) url += (url.Contains("?") ? "&" : "?") + QueryString;

        // Initialize the request
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

        // Misc
        request.Method = Method.ToUpper();
        request.Credentials = Credentials;
        request.Headers = Headers.Headers;
        request.Accept = Accept;
        request.CookieContainer = Cookies.Container;
        if (string.IsNullOrWhiteSpace(ContentType) == false) request.ContentType = ContentType;
        request.AutomaticDecompression = AutomaticDecompression;
        request.MediaType = MediaType;
        request.TransferEncoding = TransferEncoding;
        request.Connection = Connection;
        request.Expect = Expect;
        request.Timeout = (int) Timeout.TotalMilliseconds;
        if (string.IsNullOrWhiteSpace(Host) == false) request.Host = Host;
        if (string.IsNullOrWhiteSpace(UserAgent) == false) request.UserAgent = UserAgent;
        if (string.IsNullOrWhiteSpace(Referer) == false) request.Referer = Referer;

        // Handle various POST scenarios
        if (string.IsNullOrWhiteSpace(Body) == false) {

            // Get the bytes for the request body
            byte[] bytes = Encoding.UTF8.GetBytes(Body!);

            // Set the length of the request body
            SetRequestContentLength(request, bytes.Length);

            // Write the body to the request stream
            Task<Stream> hest = request.GetRequestStreamAsync();
            using (Stream stream = hest.Result) {
                stream.Write(bytes, 0, bytes.Length);
            }

        } else if (BinaryBody != null) {

            // Set the length of the request body
            SetRequestContentLength(request, BinaryBody.Length);

            // Write the body to the request stream
            using (Stream stream = request.GetRequestStreamAsync().Result) {
                stream.Write(BinaryBody, 0, BinaryBody.Length);
            }

        } else if (Method is HttpMethod.Post or HttpMethod.Put or HttpMethod.Patch or HttpMethod.Delete) {

            if (PostData.IsMultipart) {

                // Declare the boundary to be used for the multipart data
                string boundary = Guid.NewGuid().ToString().Replace("-", "");

                // Set the content type (including the boundary)
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                // Write the multipart body to the request stream
                Task<Stream> hest = request.GetRequestStreamAsync();
                hest.Wait();
                using (Stream stream = hest.Result) {
                    PostData.WriteMultipartFormData(stream, boundary);
                }

            } else {

                // Convert the POST data to an URL encoded string
                string dataString = PostData.ToString()!;

                // Get the bytes for the request body
                byte[] bytes = Encoding.UTF8.GetBytes(dataString);

                // Set the content type
                request.ContentType ??= HttpConstants.ApplicationFormEncoded;

                // Set the length of the request body
                SetRequestContentLength(request, bytes.Length);

                // Write the body to the request stream
                Task<Stream> hest = request.GetRequestStreamAsync();
                hest.Wait();
                using (Stream stream = hest.Result) {
                    stream.Write(bytes, 0, bytes.Length);
                }

            }

        }

        // Call the callback
        callback?.Invoke(request);

        // Get the response
        try {

            return HttpResponse.GetFromWebResponse((HttpWebResponse) request.GetResponse(), this);

        } catch (AggregateException ex) {

            if (ex.InnerException is WebException { Status: WebExceptionStatus.ProtocolError } web) {
                return HttpResponse.GetFromWebResponse((HttpWebResponse) web.Response!, this);
            }

            throw;

        } catch (WebException ex) {
            if (ex.Status != WebExceptionStatus.ProtocolError) throw;
            return HttpResponse.GetFromWebResponse((HttpWebResponse) ex.Response!, this);
        }

    }

    private void SetRequestContentLength(HttpWebRequest request, int contentLength) {
        request.ContentLength = contentLength;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new request with default options.
    /// </summary>
    /// <returns>A new instance of <see cref="HttpRequest"/>.</returns>
    public static HttpRequest New() {
        return new HttpRequest();
    }

    /// <summary>
    /// Initializes a new GET request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request. The query string may be part of the specified URL or via the <see cref="QueryString"/> property.</param>
    public static HttpRequest Get(string url) {
        return new HttpRequest(HttpMethod.Get, url);
    }

    /// <summary>
    /// Initializes a new GET request based on the specified <paramref name="url"/> and <paramref name="queryString"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public static HttpRequest Get(string url, IHttpQueryString? queryString) {
        return new HttpRequest(HttpMethod.Get, url, queryString);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    public static HttpRequest Post(string url) {
        return new HttpRequest(HttpMethod.Post, url);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString) {
        return new HttpRequest(HttpMethod.Post, url, queryString);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The HTTP POST data of the request.</param>
    public static HttpRequest Post(string url, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Post, url, postData);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The HTTP POST data of the request.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Post, url, queryString, postData);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>, <paramref name="queryString"/>, <paramref name="contentType"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="HttpRequest"/>.</returns>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return new HttpRequest(HttpMethod.Post, url, queryString).SetContentType(contentType).SetBody(body);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Post(string url, JToken body) {
        return new HttpRequest(HttpMethod.Post, url, body);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Post(string url, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Post, url, body, formatting);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, JToken body) {
        return new HttpRequest(HttpMethod.Post, url, queryString, body);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Post, url, queryString, body, formatting);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Post(string url, XNode? body) {
        return new HttpRequest(HttpMethod.Post, url).SetBody(body);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Post(string url, XNode? body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Post, url).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, XNode? body) {
        return new HttpRequest(HttpMethod.Post, url, queryString).SetBody(body);
    }

    /// <summary>
    /// Initializes a new POST request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Post(string url, IHttpQueryString? queryString, XNode? body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Post, url, queryString).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    public static HttpRequest Put(string url) {
        return new HttpRequest(HttpMethod.Put, url);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString) {
        return new HttpRequest(HttpMethod.Put, url, queryString);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The HTTP PUT data of the request.</param>
    public static HttpRequest Put(string url, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Put, url, postData);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The HTTP PUT data of the request.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Put, url, queryString, postData);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>, <paramref name="queryString"/>, <paramref name="contentType"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="HttpRequest"/>.</returns>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return new HttpRequest(HttpMethod.Put, url, queryString).SetContentType(contentType).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the PUT body.</param>
    public static HttpRequest Put(string url, JToken body) {
        return new HttpRequest(HttpMethod.Put, url, body);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Put(string url, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Put, url, body, formatting);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the PUT body.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, JToken body) {
        return new HttpRequest(HttpMethod.Put, url, queryString, body);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Put, url, queryString, body, formatting);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Put(string url, XNode body) {
        return new HttpRequest(HttpMethod.Put, url).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Put(string url, XNode body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Put, url).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, XNode body) {
        return new HttpRequest(HttpMethod.Put, url, queryString).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PUT request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Put(string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Put, url, queryString).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    public static HttpRequest Patch(string url) {
        return new HttpRequest(HttpMethod.Patch, url);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString) {
        return new HttpRequest(HttpMethod.Patch, url, queryString);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="postData">The HTTP PATCH data of the request.</param>
    public static HttpRequest Patch(string url, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Patch, url, postData);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and <paramref name="postData"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="postData">The HTTP PATCH data of the request.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, IHttpPostData? postData) {
        return new HttpRequest(HttpMethod.Patch, url, queryString, postData);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>, <paramref name="queryString"/>, <paramref name="contentType"/> and <paramref name="body"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="contentType">The content type of the request - eg. <c>application/json</c>.</param>
    /// <param name="body">The body of the request.</param>
    /// <returns>An instance of <see cref="HttpRequest"/>.</returns>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, string? contentType, string? body) {
        return new HttpRequest(HttpMethod.Patch, url, queryString).SetContentType(contentType).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the PATCH body.</param>
    public static HttpRequest Patch(string url, JToken body) {
        return new HttpRequest(HttpMethod.Patch, url, body);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Patch(string url, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Patch, url, body, formatting);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the PATCH body.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, JToken body) {
        return new HttpRequest(HttpMethod.Patch, url, queryString, body);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/>, <paramref name="queryString"/> and JSON <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>application/json</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="formatting">The formatting to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, JToken body, Formatting formatting) {
        return new HttpRequest(HttpMethod.Patch, url, queryString, body, formatting);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Patch(string url, XNode body) {
        return new HttpRequest(HttpMethod.Patch, url).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Patch(string url, XNode body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Patch, url).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, XNode body) {
        return new HttpRequest(HttpMethod.Patch, url, queryString).SetBody(body);
    }

    /// <summary>
    /// Initializes a new PATCH request based on the specified <paramref name="url"/> and XML <paramref name="body"/>.
    ///
    /// With this method, the <see cref="ContentType"/> property is automatically set to <c>text/xml</c>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string.</param>
    /// <param name="body">An instance of <see cref="JToken"/> representing the POST body.</param>
    /// <param name="options">The options to be used when serializing <paramref name="body"/>.</param>
    public static HttpRequest Patch(string url, IHttpQueryString? queryString, XNode body, SaveOptions options) {
        return new HttpRequest(HttpMethod.Patch, url, queryString).SetBody(body, options);
    }

    /// <summary>
    /// Initializes a new DELETE request based on the specified <paramref name="url"/>.
    /// </summary>
    /// <param name="url">The URL of the request. The query string may be part of the specified URL or via the <see cref="QueryString"/> property.</param>
    public static HttpRequest Delete(string url) {
        return new HttpRequest(HttpMethod.Delete, url);
    }

    /// <summary>
    /// Initializes a new DELETE request based on the specified <paramref name="url"/> and <paramref name="queryString"/>.
    /// </summary>
    /// <param name="url">The URL of the request.</param>
    /// <param name="queryString">The query string of the request.</param>
    public static HttpRequest Delete(string url, IHttpQueryString? queryString) {
        return new HttpRequest(HttpMethod.Delete, url, queryString);
    }

    #endregion

}