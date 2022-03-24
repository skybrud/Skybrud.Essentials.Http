using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Http.Collections;

namespace UnitTestProject1 {

    [TestClass]
    public class HttpQueryStringTests {

        [TestMethod]
        public new void ToString() {

            HttpQueryString query = new HttpQueryString {
                {"rød", "grød" }
            };

            string str = query.ToString();

            Assert.AreEqual("r%c3%b8d=gr%c3%b8d", str);

        }

        [TestMethod]
        public void ParseQueryString() {

            string str = "a=r%c3%b8d&b=gr%c3%b8d";

            HttpQueryString query = HttpQueryString.Parse(str);

            Assert.AreEqual("rød", query["a"]);
            Assert.AreEqual("grød", query["b"]);

        }

        [TestMethod]
        public void Clone() {

            HttpQueryString query = new HttpQueryString {
                {"rød", "grød" }
            };

            HttpQueryString copy = query.Clone();

            Assert.AreEqual(1, copy.Count);

            copy.Add("hello", "world");

            Assert.AreEqual("grød", query["rød"]);
            Assert.AreEqual("grød", copy["rød"]);

            Assert.AreEqual(null, query["hello"]);
            Assert.AreEqual("world", copy["hello"]);

        }

        [TestMethod]
        public void Remove() {

            HttpQueryString query = new HttpQueryString {
                {"rød", "grød" }
            };

            Assert.AreEqual(1, query.Count);
            Assert.AreEqual("grød", query["rød"]);

            query.Remove("rød");

            Assert.AreEqual(0, query.Count);
            Assert.AreEqual(null, query["rød"]);

        }

    }

}