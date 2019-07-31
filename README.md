# Skybrud.Essentials.Http [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/v/Skybrud.Essentials.Http.svg)](https://www.nuget.org/packages/Skybrud.Essentials) [![NuGet](https://img.shields.io/nuget/dt/Skybrud.Essentials.Http.svg)](https://www.nuget.org/packages/Skybrud.Essentials)

### Installation

To install the Skybrud.Essentials.Http, simply pick one of the methods below:

1. [**NuGet Package**][NuGetPackage]  
   Install this NuGet package in your Visual Studio project. Makes updating easy.
2. [**ZIP file**][GitHubRelease]  
   Grab a ZIP file of the latest release; unzip and move both `Skybrud.Essentials.dll` and `Skybrud.Essentials.Http.dll` matching your target framework to the bin directory of your project.



### Dependencies

- [**Skybrud.Essentials**](https://github.com/skybrud/Skybrud.Essentials)<br />A package with logic for handling various common tasks in .NET.

  - [**Json.NET**](https://github.com/jamesnk/newtonsoft.json)<br />Used for searializing/deserializing JSON.



### Found a bug? Have a question?

* Please feel free to [**create an issue**][Issues], and I will get back to you ;)



### Changelog

The [**releases page**][GitHubReleases] lists the relevant changes from each release.


### Usage

## HttpUtils class

### Making a GET request

Basic request with a URL:

```csharp
IHttpResponse response = HttpUtils.Requests.Get("http://example.org/");
```

Same request, but with a query string:

```csharp
IHttpResponse response = HttpUtils.Requests.Get("http://example.org/", new HttpQueryString {
    {"query", "string"}
});
```

### Making a POST request

Make a POST request with URL encoded body:

```csharp
IHttpResponse response = HttpUtils.Requests.Post("http://example.org/", new HttpPostData {
    {"hello", "world"}
});
```

Make a POST request with a JSON body:

```csharp
IHttpResponse response = HttpUtils.Requests.Post("http://example.org/", new JObject {
    {"hello", "world"}
});
```

## HttpRequest class

### Making a GET request

Basic request with a URL:

```csharp
IHttpRequest request = new HttpRequest {
    Method = HttpMethod.Get,
    Url = "http://example.org/"
};

IHttpResponse response = request.GetResponse();
```

Same request, but with a query string:

```csharp
IHttpRequest request = new HttpRequest {
    Method = HttpMethod.Get,
    Url = "http://example.org/",
    QueryString = new HttpQueryString {
        {"query", "string"}
    }
};

IHttpResponse response = request.GetResponse();
```

### Making a POST request

Make a POST request with URL encoded body:

```csharp
IHttpRequest request = new HttpRequest {
    Method = HttpMethod.Post,
    Url = "http://example.org/",
    PostData = new HttpPostData {
        {"hello", "world"}
    }
};

IHttpResponse response = request.GetResponse();
```

Make a POST request with a JSON body:

```csharp
IHttpRequest request = new HttpRequest {
    Method = HttpMethod.Post,
    Url = "http://example.org/",
    Body = new JObject {
        {"hello", "world"}
    }.ToString()
};

IHttpResponse response = request.GetResponse();
```

Make an authenticated GET request:

```csharp
IHttpRequest request = new HttpRequest {
    Method = HttpMethod.Get,
    Url = "http://example.org/",
    Authorization = "Bearer 123"
};

IHttpResponse response = request.GetResponse();
```





   
[NuGetPackage]: https://www.nuget.org/packages/Skybrud.Essentials.Http
[GitHubRelease]: https://github.com/skybrud/Skybrud.Essentials.Http/releases/latest
[GitHubReleases]: https://github.com/skybrud/Skybrud.Essentials.Http/releases
[Changelog]: https://github.com/skybrud/Skybrud.Essentials.Http/releases
[Issues]: https://github.com/skybrud/Skybrud.Essentials.Http/issues
