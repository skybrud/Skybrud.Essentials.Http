﻿using System.Collections.Generic;
using System.IO;

namespace Skybrud.Essentials.Http.Collections {

    /// <summary>
    /// Interface describing the request body of a HTTP POST request.
    /// </summary>
    public interface IHttpPostData : IEnumerable<KeyValuePair<string, string>> {

        #region Properties

        /// <summary>
        /// Gets whether the request should be posted as multipart data.
        /// </summary>
        bool IsMultipart { get; }

        /// <summary>
        /// Gets the amount of POST data entries.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets an array of the keys of all POST data entiries.
        /// </summary>
        string[] Keys { get; }

        /// <summary>
        /// Gets values of all POST data entiries.
        /// </summary>
        Dictionary<string, IHttpPostValue>.ValueCollection Values { get; }

        /// <summary>
        /// Gets or sets the string value of the item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <returns>The <see cref="string"/> value of the item, or <c>null</c> if not found.</returns>
        string? this[string key] { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the POST data contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><c>true</c> if the POST data contains an entry with the specified <paramref name="key"/>,
        /// otherwise <c>false</c>.</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Add(string key, string value);

        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Add(string key, object value);

        /// <summary>
        /// Adds a file entry with the specified <paramref name="key"/> and <paramref name="path"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        void AddFile(string key, string path);

        /// <summary>
        /// Adds a file entry with the specified <paramref name="key"/>, <paramref name="path"/>,
        /// <paramref name="contentType"/> and <paramref name="filename"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The filename of the file.</param>
        void AddFile(string key, string path, string contentType, string filename);

        /// <summary>
        /// Sets the value of the entry with specified <paramref name="key"/>. If an entry with <paramref name="key"/>
        /// already exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Set(string key, string value);

        /// <summary>
        /// Sets the value of the entry with specified <paramref name="key"/>. If an entry with <paramref name="key"/>
        /// already exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Set(string key, object value);

        /// <summary>
        /// Removes the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        void Remove(string key);

        /// <summary>
        /// Gets whether the value with the specified key is an instance of <see cref="HttpPostFileValue"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the item with the specified <paramref name="key"/> is an instance of
        /// <see cref="HttpPostFileValue"/>, otherwise <c>false</c>.</returns>
        bool IsFile(string key);

        /// <summary>
        /// Writes the multipart POST data to the specified <c>stream</c>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="boundary">The multipart boundary.</param>
        void WriteMultipartFormData(Stream stream, string boundary);

        #endregion

    }

}