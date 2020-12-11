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

            IHttpRequest request = HttpRequest
                .New()
                .SetAcceptHeader("application/json");

            Assert.AreEqual("application/json", request.Accept);

        }

        [TestMethod]
        public void SetAcceptHeaderCollection() {

            IHttpRequest request = HttpRequest
                .New()
                .SetAcceptHeader(new []{ "application/json", "text/xml" });

            Assert.AreEqual("application/json,text/xml", request.Accept);

        }

        [TestMethod]
        public void SetAuthorizationHeader() {

            IHttpRequest request = HttpRequest
                .New()
                .SetAuthorizationHeader("Bearer 1234");

            Assert.AreEqual("Bearer 1234", request.Authorization);

        }

        [TestMethod]
        public void SetContentType() {

            IHttpRequest request = HttpRequest
                .New()
                .SetContentType("application/json");

            Assert.AreEqual("application/json", request.ContentType);

        }

        [TestMethod]
        public void SetUserAgent() {

            IHttpRequest request = HttpRequest
                .New()
                .SetUserAgent("Hello There");

            Assert.AreEqual("Hello There", request.UserAgent);

        }

    }

}