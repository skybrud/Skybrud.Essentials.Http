using Skybrud.Essentials.Strings;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Skybrud.Essentials.Http.Collections;

/// <summary>
/// Static class with various extension methods for <see cref="IHttpQueryString"/>.
/// </summary>
public static class HttpQueryStringExtensions {

    /// <summary>
    /// Attempts to get the boolean value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the boolean value if successful; otherwise, <c>false</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetBoolean(this IHttpQueryString? query, string key, out bool result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return StringUtils.TryParseBoolean(query?[key], out result);
    }

    /// <summary>
    /// Attempts to get the integer value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetInt32(this IHttpQueryString? query, string key, out int result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return int.TryParse(query?[key], NumberStyles.Any, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Attempts to get the long value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the long value if successful; otherwise, <c>0</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetInt64(this IHttpQueryString? query, string key, out long result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return long.TryParse(query?[key], NumberStyles.Any, CultureInfo.InvariantCulture, out result);

    }

    /// <summary>
    /// Attempts to get the float value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the float value if successful; otherwise, <c>0</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetFloat(this IHttpQueryString? query, string key, out float result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return float.TryParse(query?[key], NumberStyles.Any, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Attempts to get the float value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the float value if successful; otherwise, <c>0</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetSingle(this IHttpQueryString? query, string key, out float result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return float.TryParse(query?[key], NumberStyles.Any, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Attempts to get the double value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the double value if successful; otherwise, <c>0</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetDouble(this IHttpQueryString? query, string key, out double result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        return double.TryParse(query?[key], NumberStyles.Any, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Attempts to get the string value from the item in <paramref name="query"/> matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="key">The key of the item.</param>
    /// <param name="result">When this method returns, contains the string value if successful; otherwise, <c>null</c>.</param>
    /// <returns>Whether the method was successful.</returns>
    public static bool TryGetString(this IHttpQueryString? query, string key, [NotNullWhen(true)] out string? result) {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
        result = query?[key];
        return result != null;
    }

}