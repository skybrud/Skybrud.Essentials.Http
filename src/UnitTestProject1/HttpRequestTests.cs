using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace UnitTestProject1 {

    [TestClass]
    public class HttpRequestTests {

        [TestMethod]
        public void SetMethod() {

            IHttpRequest request1 = HttpRequest
                .New()
                .SetMethod(HttpMethod.Get);

            IHttpRequest request2 = HttpRequest
                .New()
                .SetMethod(HttpMethod.Post);

            Assert.AreEqual(HttpMethod.Get, request1.Method);
            Assert.AreEqual(HttpMethod.Post, request2.Method);

        }

        [TestMethod]
        public void SetUrl() {

            IHttpRequest request = HttpRequest
                .New()
                .SetUrl("http://omgbacon.dk");

            Assert.AreEqual("http://omgbacon.dk", request.Url);

        }

        [TestMethod]
        public void SetQueryString() {

            IHttpQueryString query = new HttpQueryString {
                {"hello", "there" }
            };

            IHttpRequest request = HttpRequest
                .New()
                .SetQueryString(query);

            Assert.AreEqual("hello=there", request.QueryString.ToString());

        }

        [TestMethod]
        public void SetQueryStringNull() {

            // PREMISE:
            // The extension method allows null values, but the "QueryString" property doesn't. Nullable reference
            // types are mostly just suggestions, so if passed a null value, the property will set it's value to a new
            // "HttpQueryString" instance.

            IHttpRequest request1 = HttpRequest.New().SetQueryString(null);
            IHttpRequest request2 = HttpRequest.Post("/hello-there", default(IHttpQueryString));

            Assert.IsNotNull(request1.QueryString);
            Assert.IsNotNull(request2.QueryString);

        }

        [TestMethod]
        public void SetPostData() {

            IHttpPostData data = new HttpPostData {
                {"hello", "there" }
            };

            IHttpRequest request = HttpRequest
                .New()
                .SetPostData(data);

            Assert.AreEqual("hello=there", request.PostData.ToString());

        }

        [TestMethod]
        public void SetPostDataNull() {

            // PREMISE:
            // The extension method allows null values, but the "PostData" property doesn't. Nullable reference types
            // are mostly just suggestions, so if passed a null value, the property will set it's value to a new
            // "HttpPostData" instance.

            IHttpRequest request1 = HttpRequest.New().SetPostData(null);
            IHttpRequest request2 = HttpRequest.Post("/hello-there", default(IHttpPostData));

            Assert.IsNotNull(request1.PostData);
            Assert.IsNotNull(request2.PostData);

        }

        [TestMethod]
        public void SetBody() {

            IHttpRequest request = HttpRequest
                .New()
                .SetBody("Hello There");

            Assert.AreEqual("Hello There", request.Body);

        }

        [TestMethod]
        public void SetBodyToken() {

            JToken token = new JObject {
                {"hello", "there" }
            };

            IHttpRequest request = HttpRequest
                .New()
                .SetBody(token);

            Assert.AreEqual("{\"hello\":\"there\"}", request.Body);

        }

        [TestMethod]
        public void SetBodyTokenFormatting() {

            JToken token = new JObject {
                {"hello", "there" }
            };

            IHttpRequest request = HttpRequest
                .New()
                .SetBody(token, Formatting.Indented);

            Assert.AreEqual("{\r\n  \"hello\": \"there\"\r\n}", request.Body);

        }

        [TestMethod]
        public void SetAcceptHeader() {

            IHttpRequest request1 = HttpRequest.New().SetAcceptHeader("application/json");
            IHttpRequest request2 = HttpRequest.New().SetAcceptHeader(default(string));

            Assert.AreEqual("application/json", request1.Accept);
            Assert.IsNull(request2.Accept);

        }

        [TestMethod]
        public void SetAcceptHeaderCollection() {

            IHttpRequest request1 = HttpRequest
                .New()
                .SetAcceptHeader(new[] { "application/json", "text/xml" });

            IHttpRequest request2 = HttpRequest
                .New()
                .SetAcceptHeader(default(string[]));

            Assert.AreEqual("application/json,text/xml", request1.Accept);
            Assert.IsNull(request2.Accept);

        }

        [TestMethod]
        public void SetAuthorizationHeader() {

            IHttpRequest request1 = HttpRequest
                .New()
                .SetAuthorizationHeader("Bearer 1234");

            IHttpRequest request2 = HttpRequest
                .New()
                .SetAuthorizationHeader(null);

            Assert.AreEqual("Bearer 1234", request1.Authorization);

            // Ideally the header value should be null because we set it to null, but the indexer of the underlying
            // "WebHeaderCollection" returns an empty string if the header doesn't exist or was previosuly set to null.
            Assert.AreEqual(string.Empty, request2.Authorization);

        }

        [TestMethod]
        public void SetContentType() {

            IHttpRequest request1 = HttpRequest.New().SetContentType("application/json");
            IHttpRequest request2 = HttpRequest.New().SetContentType(null);

            Assert.AreEqual("application/json", request1.ContentType);
            Assert.IsNull(request2.ContentType);

        }

        [TestMethod]
        public void SetUserAgent() {

            IHttpRequest request1 = HttpRequest.New().SetUserAgent("Hello There");
            IHttpRequest request2 = HttpRequest.New().SetUserAgent(null);

            Assert.AreEqual("Hello There", request1.UserAgent);
            Assert.IsNull(request2.UserAgent);

        }

    }

}