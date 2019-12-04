namespace Skybrud.Essentials.Http.Options {

    /// <summary>
    /// Options for a request.
    /// </summary>
    public interface IHttpRequestOptions {

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        IHttpRequest GetRequest();

    }

}