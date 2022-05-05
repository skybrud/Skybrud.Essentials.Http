using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Skybrud.Essentials.Http {
    
    public partial class HttpRequest {
       
        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
        /// </summary>
        /// <returns>An instance of <see cref="Task{HttpResponse}"/> representing the response.</returns>
        public virtual async Task<IHttpResponse> GetResponseAsync() {
            return await GetResponseAsync(default);
        }

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="callback">Lets you specify a callback method for modifying the underlying <see cref="HttpWebRequest"/>.</param>
        /// <returns>An instance of <see cref="Task{HttpResponse}"/> representing the response.</returns>
        public virtual async Task<IHttpResponse> GetResponseAsync(Action<HttpWebRequest> callback) {

            // Build the URL
            string url = Url;
            if (QueryString != null && !QueryString.IsEmpty) url += (url.Contains("?") ? "&" : "?") + QueryString;

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Misc
            request.Method = Method.ToUpper();
            request.Credentials = Credentials;
            if (Headers != null) request.Headers = Headers.Headers;
            request.Accept = Accept;
            if (Cookies != null) request.CookieContainer = Cookies.Container;
            if (string.IsNullOrWhiteSpace(ContentType) == false) request.ContentType = ContentType;

#if NET_FRAMEWORK
            request.Timeout = (int) Timeout.TotalMilliseconds;
            if (string.IsNullOrWhiteSpace(Host) == false) request.Host = Host;
            if (string.IsNullOrWhiteSpace(UserAgent) == false) request.UserAgent = UserAgent;
            if (string.IsNullOrWhiteSpace(Referer) == false) request.Referer = Referer;
#endif

#if NET_STANDARD2
            request.AutomaticDecompression = AutomaticDecompression;
            request.MediaType = MediaType;
            request.TransferEncoding = TransferEncoding;
            request.Connection = Connection;
            request.Expect = Expect;
#endif

#if NET_STANDARD
            if (string.IsNullOrWhiteSpace(Host) == false) request.Headers["Host"] = Host;
            if (string.IsNullOrWhiteSpace(UserAgent) == false) request.Headers["User-Agent"] = UserAgent;
            if (string.IsNullOrWhiteSpace(Referer) == false) request.Headers["Referer"] = Referer;
#endif

            // Handle various POST scenarios
            if (string.IsNullOrWhiteSpace(Body) == false) {
                
                // Get the bytes for the request body
                byte[] bytes = Encoding.UTF8.GetBytes(Body);

                // Set the length of the request body
                SetRequestContentLength(request, bytes.Length);

                // Write the body to the request stream
                Task<Stream> hest = request.GetRequestStreamAsync();
                using (Stream stream = hest.Result) {
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                }

            } else if (Method == HttpMethod.Post || Method == HttpMethod.Put || Method == HttpMethod.Patch || Method == HttpMethod.Delete) {
                
                // Make sure we have a POST data instance
                PostData = PostData ?? new HttpPostData();

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
                    string dataString = PostData.ToString();
                    
                    // Get the bytes for the request body
                    byte[] bytes = Encoding.UTF8.GetBytes(dataString);

                    // Set the content type
                    request.ContentType = request.ContentType ?? HttpConstants.ApplicationFormEncoded;

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
                
                return HttpResponse.GetFromWebResponse(response as HttpWebResponse, this);

            } catch (WebException ex) {
                
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                
                return HttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse, this);

            }

        }

    }

}