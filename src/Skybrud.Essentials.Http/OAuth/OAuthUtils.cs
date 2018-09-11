using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Http.OAuth {

    /// <summary>
    /// Static class with utility methods for the OAuth implementation.
    /// </summary>
    public static class OAuthUtils {

        /// <summary>
        /// Generates a nonce (random value) used for creating the authorization header.
        /// </summary>
        /// <returns>A random value to be used for creating the authorization header.</returns>
        public static string GenerateNonce() {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// Returns the current UNIX timestamp as a string.
        /// </summary>
        /// <returns>The current Unix timestamp as a string.</returns>
        public static string GetTimestamp() {
            return TimeUtils.GetCurrentUnixTimestamp().ToString();
        }

    }

}