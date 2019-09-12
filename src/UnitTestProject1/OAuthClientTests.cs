using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth;

namespace UnitTestProject1 {

    [TestClass]
    public class OAuthClientTests {

        [TestMethod]
        public void GenerateSignature() {

            // These are not real tokens, but randomly generated GUIDs
            const string a = "45b998c8-3ee3-4cb0-86c8-ef4ef81e52fe";
            const string b = "afee51a6-6aca-49a2-9d3e-084b4d372a97";
            const string c = "401fdd6d-4708-4174-ad2e-29c6ea054ec6";
            const string d = "3642df43-fc23-469e-9d5b-4bee66b5fc4b";

            const string timestamp = "1568285417";
            const string nonce = "a random value";

            OAuthClient client = new OAuthClient {
                ConsumerKey = a,
                ConsumerSecret = b,
                Token = c,
                TokenSecret = d,
                AutoReset = false,
                Nonce = nonce,
                Timestamp = timestamp
            };

            HttpQueryString query = new HttpQueryString {
                {"hello", "world"}
            };

            HttpPostData post = new HttpPostData {
                {"alpha", "bravo" }
            };

            string signature = client.GenerateSignature(HttpMethod.Post, "https://example.org/", query, post);
            Assert.AreEqual("hcmLTxgZgsZuTh9ywU68PFGZLL0=", signature);

            string header = client.GenerateHeaderString(signature);

            Assert.AreEqual("OAuth realm=\"\",oauth_consumer_key=\"45b998c8-3ee3-4cb0-86c8-ef4ef81e52fe\",oauth_nonce=\"a%20random%20value\",oauth_signature=\"hcmLTxgZgsZuTh9ywU68PFGZLL0%3D\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"1568285417\",oauth_token=\"401fdd6d-4708-4174-ad2e-29c6ea054ec6\",oauth_version=\"1.0\"", header);

        }

    }

}