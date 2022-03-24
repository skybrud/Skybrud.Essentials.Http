using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Http.Collections;
using System;
using System.Globalization;

// ReSharper disable ExpressionIsAlwaysNull

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

        [TestMethod]
        public void TryGetBoolean_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetBoolean("key1", out bool result1);
            bool status2 = query.TryGetBoolean("key2", out bool result2);
            bool status3 = query.TryGetBoolean("key3", out bool result3);

            Assert.IsFalse(status1);
            Assert.IsFalse(result1);

            Assert.IsFalse(status2);
            Assert.IsFalse(result2);

            Assert.IsFalse(status3);
            Assert.IsFalse(result3);

        }

        [TestMethod]
        public void TryGetBoolean_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "true" },
                {"key2", "false" }
            };

            bool status1 = query.TryGetBoolean("key1", out bool result1);
            bool status2 = query.TryGetBoolean("key2", out bool result2);
            bool status3 = query.TryGetBoolean("key3", out bool result3);

            Assert.IsTrue(status1);
            Assert.IsTrue(result1);

            Assert.IsTrue(status2);
            Assert.IsFalse(result2);

            Assert.IsFalse(status3);
            Assert.IsFalse(result3);

        }

        [TestMethod]
        public void TryGetInt32_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetInt32("key1", out int result1);
            bool status2 = query.TryGetInt32("key2", out int result2);
            bool status3 = query.TryGetInt32("key3", out int result3);

            Assert.IsFalse(status1);
            Assert.AreEqual(0, result1);

            Assert.IsFalse(status2);
            Assert.AreEqual(0, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetInt32_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "1234" },
                {"key2", "-1234" }
            };

            bool status1 = query.TryGetInt32("key1", out int result1);
            bool status2 = query.TryGetInt32("key2", out int result2);
            bool status3 = query.TryGetInt32("key3", out int result3);

            Assert.IsTrue(status1);
            Assert.AreEqual(1234, result1);

            Assert.IsTrue(status2);
            Assert.AreEqual(-1234, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetInt64_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetInt64("key1", out long result1);
            bool status2 = query.TryGetInt64("key2", out long result2);
            bool status3 = query.TryGetInt64("key3", out long result3);

            Assert.IsFalse(status1);
            Assert.AreEqual(0, result1);

            Assert.IsFalse(status2);
            Assert.AreEqual(0, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetInt64_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "1234" },
                {"key2", "-1234" }
            };

            bool status1 = query.TryGetInt64("key1", out long result1);
            bool status2 = query.TryGetInt64("key2", out long result2);
            bool status3 = query.TryGetInt64("key3", out long result3);

            Assert.IsTrue(status1, "#1 status");
            Assert.AreEqual(1234, result1, "#1 result");

            Assert.IsTrue(status2, "#2 status");
            Assert.AreEqual(-1234, result2, "#2 result");

            Assert.IsFalse(status3, "#3 status");
            Assert.AreEqual(0, result3, "#3 result");

        }
        
        [TestMethod]
        public void TryGetFloat_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetFloat("key1", out float result1);
            bool status2 = query.TryGetFloat("key2", out float result2);
            bool status3 = query.TryGetFloat("key3", out float result3);

            Assert.IsFalse(status1);
            Assert.AreEqual(0, result1);

            Assert.IsFalse(status2);
            Assert.AreEqual(0, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetFloat_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "3.14" },
                {"key2", "123.456" }
            };

            bool status1 = query.TryGetFloat("key1", out float result1);
            bool status2 = query.TryGetFloat("key2", out float result2);
            bool status3 = query.TryGetFloat("key3", out float result3);

            Assert.IsTrue(status1);
            Assert.AreEqual("3.1400", result1.ToString("F4", CultureInfo.InvariantCulture));

            Assert.IsTrue(status2);
            Assert.AreEqual("123.4560", result2.ToString("F4", CultureInfo.InvariantCulture));

            Assert.IsFalse(status3);
            Assert.AreEqual("0.0000", result3.ToString("F4", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void TryGetSingle_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetSingle("key1", out float result1);
            bool status2 = query.TryGetSingle("key2", out float result2);
            bool status3 = query.TryGetSingle("key3", out float result3);

            Assert.IsFalse(status1);
            Assert.AreEqual(0, result1);

            Assert.IsFalse(status2);
            Assert.AreEqual(0, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetSingle_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "3.14" },
                {"key2", "123.456" }
            };

            bool status1 = query.TryGetSingle("key1", out float result1);
            bool status2 = query.TryGetSingle("key2", out float result2);
            bool status3 = query.TryGetSingle("key3", out float result3);

            Assert.IsTrue(status1);
            Assert.AreEqual("3.1400", result1.ToString("F4", CultureInfo.InvariantCulture));

            Assert.IsTrue(status2);
            Assert.AreEqual("123.4560", result2.ToString("F4", CultureInfo.InvariantCulture));

            Assert.IsFalse(status3);
            Assert.AreEqual("0.0000", result3.ToString("F4", CultureInfo.InvariantCulture));

        }

        [TestMethod]
        public void TryGetDouble_1() {

            HttpQueryString query = null;

            bool status1 = query.TryGetDouble("key1", out double result1);
            bool status2 = query.TryGetDouble("key2", out double result2);
            bool status3 = query.TryGetDouble("key3", out double result3);

            Assert.IsFalse(status1);
            Assert.AreEqual(0, result1);

            Assert.IsFalse(status2);
            Assert.AreEqual(0, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetDouble_2() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "3.14" },
                {"key2", "123.456" }
            };

            bool status1 = query.TryGetDouble("key1", out double result1);
            bool status2 = query.TryGetDouble("key2", out double result2);
            bool status3 = query.TryGetDouble("key3", out double result3);

            Assert.IsTrue(status1);
            Assert.AreEqual(3.14, result1);

            Assert.IsTrue(status2);
            Assert.AreEqual(123.456, result2);

            Assert.IsFalse(status3);
            Assert.AreEqual(0, result3);

        }

        [TestMethod]
        public void TryGetString() {

            HttpQueryString query = new HttpQueryString {
                {"key1", "" },
                {"key2", "hello" },
                {"key3", "hej" },
                {"key4", null }
            };

            bool status1 = query.TryGetString("key1", out string result1);
            bool status2 = query.TryGetString("key2", out string result2);
            bool status3 = query.TryGetString("key3", out string result3);
            bool status4 = query.TryGetString("key4", out string result4);
            bool status5 = query.TryGetString("key5", out string result5);

            Assert.IsTrue(status1, "#1 status");
            Assert.AreEqual("", result1, "#1 result");

            Assert.IsTrue(status2, "#2 status");
            Assert.AreEqual("hello", result2, "#2 result");

            Assert.IsTrue(status3, "#3 status");
            Assert.AreEqual("hej", result3, "#3 result");

            Assert.IsFalse(status4, "#4 status");
            Assert.AreEqual(null, result4, "#4 result");

            Assert.IsFalse(status5, "#5 status");
            Assert.AreEqual(null, result5, "#5 result");

        }

    }

}