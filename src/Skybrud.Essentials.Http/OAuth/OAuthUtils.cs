using System;
using Skybrud.Essentials.Time.UnixTime;

namespace Skybrud.Essentials.Http.OAuth {

    /// <summary>
    /// Static class with utility methods for the OAuth implementation.
    /// </summary>
    public static class OAuthUtils {

        /// <summary>
        /// Generates a nonce (random value) used for creating the OAuth authorization header.
        /// </summary>
        /// <returns>A random value to be used for creating the OAuth authorization header.</returns>
        public static string GenerateNonce() {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// Returns the current Unix timestamp as a string.
        /// </summary>
        /// <returns>The current Unix timestamp as a string.</returns>
        public static string GetTimestamp() {
            return ((int) UnixTimeUtils.CurrentSeconds).ToString();
        }

    }

}