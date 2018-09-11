using System.IO;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Essentials.Http {
    
    /// <summary>
    /// Class representing a string HTTP POST value.
    /// </summary>
    public class HttpPostValue : IHttpPostValue {

        #region Properties

        /// <summary>
        /// Gets the name/key of the value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new HTTP POST value from the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name/key of the value.</param>
        /// <param name="value">The value.</param>
        public HttpPostValue(string name, string value) {
            Name = name;
            Value = value;
        }

        #endregion

        /// <summary>
        /// Writes the value to the specified <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream the value should be written to.</param>
        /// <param name="boundary">The multipart boundary.</param>
        /// <param name="newLine">The characters used to indicate a new line.</param>
        /// <param name="isLast">Whether the value is the last in the request body.</param>
        public void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast) {

            HttpPostData.Write(stream, "--" + boundary + newLine);
            HttpPostData.Write(stream, "Content-Disposition: form-data; name=\"" + Name + "\"" + newLine);
            HttpPostData.Write(stream, newLine);

            HttpPostData.Write(stream, Value);

            HttpPostData.Write(stream, newLine);
            HttpPostData.Write(stream, "--" + boundary + (isLast ? "--" : "") + newLine);

        }

        /// <summary>
        /// Gets a string representation of the value.
        /// </summary>
        /// <returns>The value as a string.</returns>
        public override string ToString() {
            return Value;
        }

    }

}