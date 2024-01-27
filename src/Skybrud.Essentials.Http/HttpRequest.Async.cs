using Skybrud.Essentials.Strings.Extensions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable SYSLIB0014

// ReSharper disable UseAwaitUsing
// ReSharper disable ConvertToUsingDeclaration

namespace Skybrud.Essentials.Http;

public partial class HttpRequest {

    /// <summary>
    /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
    /// </summary>
    /// <returns>An instance of <see cref="Task{HttpResponse}"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> GetResponseAsync() {
        return await GetResponseAsync(null);
    }

    /// <summary>
    /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
    /// </summary>
    /// <param name="callback">Lets you specify a callback method for modifying the underlying <see cref="HttpWebRequest"/>.</param>
    /// <returns>An instance of <see cref="Task{HttpResponse}"/> representing the response.</returns>
    public virtual async Task<IHttpResponse> GetResponseAsync(Action<HttpWebRequest>? callback) {

        // Build the URL
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

#if NET_STANDARD2
        request.AutomaticDecompression = AutomaticDecompression;
        request.MediaType = MediaType;
        request.TransferEncoding = TransferEncoding;
        request.Connection = Connection;
        request.Expect = Expect;
#endif

#if NET_FRAMEWORK
            request.Timeout = (int) Timeout.TotalMilliseconds;
            if (string.IsNullOrWhiteSpace(Host) == false) request.Host = Host;
            if (string.IsNullOrWhiteSpace(UserAgent) == false) request.UserAgent = UserAgent;
            if (string.IsNullOrWhiteSpace(Referer) == false) request.Referer = Referer;
#else
        if (string.IsNullOrWhiteSpace(Host) == false) request.Headers["Host"] = Host;
        if (string.IsNullOrWhiteSpace(UserAgent) == false) request.Headers["User-Agent"] = UserAgent;
        if (string.IsNullOrWhiteSpace(Referer) == false) request.Headers["Referer"] = Referer;
#endif

        // Handle various POST scenarios
        if (string.IsNullOrWhiteSpace(Body) == false) {

            // Get the bytes for the request body
            byte[] bytes = Encoding.UTF8.GetBytes(Body!);

            // Set the length of the request body
            SetRequestContentLength(request, bytes.Length);

            // Write the body to the request stream
            Task<Stream> hest = request.GetRequestStreamAsync();
            using (Stream stream = hest.Result) {
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }

        } else if (BinaryBody != null) {

            // Set the length of the request body
            SetRequestContentLength(request, BinaryBody.Length);

            // Write the body to the request stream
            using (Stream stream = request.GetRequestStreamAsync().Result) {
                await stream.WriteAsync(BinaryBody, 0, BinaryBody.Length);
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
                string dataString = PostData.ToString() ?? string.Empty;

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
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                }

            }

        }

        // Call the callback
        callback?.Invoke(request);

        // Get the response
        try {

            WebResponse response = await request.GetResponseAsync();

            return HttpResponse.GetFromWebResponse((HttpWebResponse) response, this);

        } catch (WebException ex) {

            if (ex.Status != WebExceptionStatus.ProtocolError) throw;

            return HttpResponse.GetFromWebResponse((HttpWebResponse) ex.Response!, this);

        }

    }

}