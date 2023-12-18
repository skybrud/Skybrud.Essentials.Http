using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Http.Collections {

    /// <summary>
    /// Class representing a basic HTTP query string.
    /// </summary>
    public class HttpQueryString : IHttpQueryString {

        #region Private fields

        private readonly Dictionary<string, string> _values;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of key/value pairs contained in the internal dictionary instance.
        /// </summary>
        public int Count => _values.Count;

        /// <summary>
        /// Gets whether the internal dictionary is empty.
        /// </summary>
        public bool IsEmpty => _values.Count == 0;

        /// <summary>
        /// Gets an array of the keys of all items in the query string.
        /// </summary>
        public string[] Keys => _values.Keys.ToArray();

        /// <summary>
        /// Gets an array of all items in the query string.
        /// </summary>
        public KeyValuePair<string, string>[] Items => _values.ToArray();

        /// <summary>
        /// Gets the value of the item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the item to match.</param>
        /// <returns>The <see cref="string"/> value of the item, or <c>null</c> if not found.</returns>
        public string? this[string key] {
            get => GetString(key);
            set => Set(key, value);
        }

        /// <summary>
        /// Gets whether this implementation of <see cref="IHttpQueryString"/> supports duplicate keys.
        /// </summary>
        public bool SupportsDuplicateKeys => false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance without any entries.
        /// </summary>
        public HttpQueryString() {
            _values = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dictionary"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary the query string should be based.</param>
        public HttpQueryString(Dictionary<string, string>? dictionary) {
            _values = dictionary ?? new Dictionary<string, string>();
        }

#if NAME_VALUE_COLLECTION

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection the query string should be based.</param>
        public HttpQueryString(NameValueCollection? collection) {
            _values = new Dictionary<string, string>();
            if (collection == null) return;
            foreach (string key in collection.AllKeys) {
                _values.Add(key, collection[key]);
            }
        }

#endif

        #endregion

        #region Methods

        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object? value) {

            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            // Abort if "value" is null
            if (value == null) return;

            // Convert the value to a culture invariant string and add it to the dictionary
            _values.Add(key, string.Format(CultureInfo.InvariantCulture, "{0}", value));

        }

        /// <summary>
        /// Sets the <paramref name="value"/> of an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, object? value) {

            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            // Specifying a null value should result in the item being removed
            if (value == null) {
                _values.Remove(key);
                return;
            }

            // Convert the value to a culture invariant string and set it in the dictionary
            _values[key] = string.Format(CultureInfo.InvariantCulture, "{0}", value);

        }

        /// <summary>
        /// Removes the value with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns><c>true</c> if the element is successfully found and removed; otherwise, <c>false</c>. This method returns <c>false</c> if <paramref name="key"/> is not found.</returns>
        public bool Remove(string key) {
            return _values.Remove(key);
        }

        /// <summary>
        /// Creates a copy of the <see cref="HttpQueryString"/>.
        /// </summary>
        /// <returns>A copy of the <see cref="HttpQueryString"/>.</returns>
        public HttpQueryString Clone() {
            return new HttpQueryString(new Dictionary<string, string>(_values));
        }

        /// <summary>
        /// Creates a copy of the <see cref="IHttpQueryString"/>.
        /// </summary>
        /// <returns>A copy of the <see cref="IHttpQueryString"/>.</returns>
        IHttpQueryString IHttpQueryString.Clone() {
            return Clone();
        }

        /// <summary>
        /// Gets a string representation of the query string.
        /// </summary>
        /// <returns>The query string as an URL encoded string.</returns>
        public override string ToString() {
            return string.Join("&", from pair in _values select StringUtils.UrlEncode(pair.Key) + "=" + StringUtils.UrlEncode(pair.Value));
        }

        /// <summary>
        /// Return whether the query string contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><c>true</c> if the query string contains the specified <paramref name="key"/>, otherwise
        /// <c>false</c>.</returns>
        public bool ContainsKey(string key) {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _values.ContainsKey(key);
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.String"/> value of the entry, or <c>null</c> if not found.</returns>
        public string? GetString(string key) {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _values.TryGetValue(key, out string? value) ? value : null;
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int32"/> value of the entry, or <c>0</c> if not found.</returns>
        public int GetInt32(string key) {
            return GetValue<int>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int64"/> value of the entry, or <c>0</c> if not found.</returns>
        public long GetInt64(string key) {
            return GetValue<long>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Boolean"/> value of the entry, or <c>0</c> if not found.</returns>
        public bool GetBoolean(string key) {
            return GetValue<bool>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Double"/> value of the entry, or <c>0</c> if not found.</returns>
        public double GetDouble(string key) {
            return GetValue<double>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Single"/> value of the entry, or <c>0</c> if not found.</returns>
        public float GetFloat(string key) {
            return GetValue<float>(key);
        }

        /// <summary>
        /// Gets the <typeparamref name="T"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <typeparamref name="T"/> value of the entry, or the default value of <typeparamref name="T"/> if not found.</returns>
        private T? GetValue<T>(string key) {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (!_values.TryGetValue(key, out string? value)) return default;
            return string.IsNullOrWhiteSpace(value) ? default : (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return _values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified query string into an instance of <see cref="HttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <returns>An instance of <see cref="HttpQueryString"/>.</returns>
        [Obsolete("Use the 'Parse' method instead.")]
        public static HttpQueryString ParseQueryString(string str) {
            return Parse(str, true);
        }

        /// <summary>
        /// Parses the specified query string into an instance of <see cref="HttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <param name="urlencoded">Whether the query string is URL encoded</param>
        /// <returns>An instance of <see cref="HttpQueryString"/> representing the parsed query string.</returns>
        /// <see>
        ///     <cref>https://referencesource.microsoft.com/#System.Web/HttpValueCollection.cs,222f9a1bfd1f9a98,references</cref>
        /// </see>
        [Obsolete("Use the 'Parse' method instead.")]
        public static HttpQueryString ParseQueryString(string str, bool urlencoded) {
            return Parse(str, urlencoded);
        }


        /// <summary>
        /// Parses the specified query string into an instance of <see cref="HttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <returns>An instance of <see cref="HttpQueryString"/>.</returns>
        public static HttpQueryString Parse(string str) {
            return Parse(str, true);
        }

        /// <summary>
        /// Parses the specified query string into an instance of <see cref="HttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <param name="urlencoded">Whether the query string is URL encoded</param>
        /// <returns>An instance of <see cref="HttpQueryString"/> representing the parsed query string.</returns>
        /// <see>
        ///     <cref>https://referencesource.microsoft.com/#System.Web/HttpValueCollection.cs,222f9a1bfd1f9a98,references</cref>
        /// </see>
        public static HttpQueryString Parse(string str, bool urlencoded) {

            // Return an empty instance if "str" is NULL or empty
            if (string.IsNullOrWhiteSpace(str)) return new HttpQueryString();

            Dictionary<string, string> values = new();

            int length = str.Length;

            int i = 0;

            while (i < length) {

                int si = i;
                int ti = -1;

                while (i < length) {
                    char ch = str[i];

                    if (ch == '=') {
                        if (ti < 0)
                            ti = i;
                    } else if (ch == '&') {
                        break;
                    }

                    i++;
                }

                // extract the name / value pair
                string? name = null;
                string value;

                if (ti >= 0) {
                    name = str.Substring(si, ti - si);
                    value = str.Substring(ti + 1, i - ti - 1);
                } else {
                    value = str.Substring(si, i - si);
                }

                // TODO: Should we throw an exception if the key already exists? (I think Add might do it for us)

                // add name / value pair to the collection
                if (urlencoded) {
                    values.Add(StringUtils.UrlDecode(name) ?? string.Empty, StringUtils.UrlDecode(value));
                } else {
                    values.Add(name ?? string.Empty, value);
                }

                // trailing '&'
                if (i == length - 1 && str[i] == '&') {
                    values.Add(string.Empty, string.Empty);
                }

                i++;

            }

            return new HttpQueryString(values);

        }


        /// <summary>
        /// Converts the specified string representation of a query string to its <see cref="HttpQueryString"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing a query string to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="HttpQueryString"/> value equivalent
        /// to query string contained in <paramref name="str"/>, if the conversion succeeded, or <c>null</c> if the
        /// conversion failed. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public bool TryParse(string str, out HttpQueryString? result) {
            try {
                result = Parse(str);
                return true;
            } catch {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Converts the specified string representation of a query string to its <see cref="HttpQueryString"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing a query string to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="HttpQueryString"/> value equivalent
        /// to query string contained in <paramref name="str"/>, if the conversion succeeded, or <c>null</c> if the
        /// conversion failed. This parameter is passed uninitialized.</param>
        /// <param name="urlencoded">Whether the query string is URL encoded</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public bool TryParse(string str, bool urlencoded, out HttpQueryString? result) {
            try {
                result = Parse(str, urlencoded);
                return true;
            } catch {
                result = null;
                return false;
            }
        }

        #endregion

        #region Operator overloading

#if NET_FRAMEWORK

        /// <summary>
        /// Initializes a new query string based on the specified <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The instance of <see cref="NameValueCollection"/> the query string should be based on.</param>
        /// <returns>An instance of <see cref="HttpQueryString"/> based on the specified <paramref name="collection"/>.</returns>
        public static implicit operator HttpQueryString(NameValueCollection? collection) {
            return new HttpQueryString(collection);
        }

#endif

        #endregion

    }

}