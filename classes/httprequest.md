# HttpRequest

In .NET we have the `HttpWebRequest` class, but using it is not super user friendly. So in this package, the <code type="Skybrud.Essentials.Http.HttpRequest, Skybrud.Essentials.Http">HttpRequest</code> class wraps the `HttpWebRequest` class, while hopefully also making it easier to use.

To make a simple GET request, your code could look something like as shown below:

```csharp
// Initialize the request for a GET request
var request = new HttpRequest
{
    Url = "http://example.org/"
};

// Send the request and get the response
var response = request.GetResponse();
```

You can also specify the HTTP method along with a number of other options. Notice the `PostData` property with a collection of POST parameters:

```csharp
// Initialize the request for a POST request
var request = new HttpRequest
{
    Method = HttpMethod.Post,
    Url = "http://example.org/",
    UserAgent = "MyClient",
    Authorization = "Basic dXNlcjpwYXNz",
    PostData = new HttpPostData {
        {"hello", "world" }
    }
};

// Send the request and get the response
var response = request.GetResponse();
```

or alternatively, you can specify the body directly (eg. with raw JSON as shown below):

```csharp
// Initialize the request for a POST request
var request = new HttpRequest
{
    Method = HttpMethod.Post,
    Url = "http://example.org/",
    UserAgent = "MyClient",
    Authorization = "Basic dXNlcjpwYXNz",
    Body = "{\"hello\":\"world\"}"
};

// Send the request and get the response
var response = request.GetResponse();
```

You can see the <code type="Skybrud.Essentials.Http.HttpRequest, Skybrud.Essentials.Http">HttpRequest</code> class for a list of all properties. 

## GetResponse

In .NET, the <code method="System.Net.HttpWebRequest.GetResponse">GetResponse</code> method will trigger an exception for HTTP protocol errors (eg. if the server responds with a 404 or 500 status code). The corresponding <code method="Skybrud.Essentials.Http.HttpRequest.GetResponse, Skybrud.Essentials.Http">GetResponse</code> method will catch any exceptions thrown for HTTP protocol errors. Instead you can validate a request something like this:

```csharp
public void ValidateRequest(IHttpRequest request) {
    if (response.StatusCode == HttpStatusCode.OK) return;
    if (response.StatusCode == HttpStatusCode.Created) return;
    throw new Exception("Oh noes");
}
```

Notice that the <code method="Skybrud.Essentials.Http.HttpRequest.GetResponse, Skybrud.Essentials.Http">GetResponse</code> method may still throw exceptions for errors at a lower level - eg. if the host of the specified URL is unreachable.
