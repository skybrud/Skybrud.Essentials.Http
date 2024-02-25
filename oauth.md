---
icon: fa fa-shield-halved
---

# OAuth

To get started with OAuth and understanding what OAuth is, the following intro from the [Wikipedia article on OAuth](https://en.wikipedia.org/wiki/OAuth) explains it quite well:

> OAuth is an open standard for access delegation, commonly used as a way for Internet users to grant websites or applications access to their information on other websites but without giving them the passwords. This mechanism is used by companies such as Amazon, Google, Facebook, Microsoft and Twitter to permit the users to share information about their accounts with third party applications or websites.

From a developers point of view, it's worth mentioning that there are two different versions of OAuth currently in use - OAuth 1.0a and OAuth 2.0. The two work in very different ways, and OAuth 2.0 shouldn't necessarily be seen as the successor of OAuth 1.0a.

Comparing the two, OAuth 1.0a can be seen more as a protocol, whereas OAuth 2.0 is a specification (which you could argue is more open for interpretation). OAuth 1.0a involves a great deal of security - explained in short terms, it uses hashing and signatures to prevent man in the middle attacks. OAuth 2.0 on the other hand solely relies on the security of TLS (HTTPS).

## OAuth 1.0a

<div class="alert alert-info">
OAuth 1.0 was the first version of protocol, but due to a security flaw, it was succeeded by OAuth 1.0a (hence the <em>a</em> in the name).
</div>

In this package, you can use the <code type="Skybrud.Essentials.Http.OAuth.OAuthClient, Skybrud.Essentials.Http">OAuthClient</code> class to communicate with an OAuth 1.0a service provider. In order to do so, you can to populate the `RequestTokenUrl`, `AuthorizeUrl` and `AccessTokenUrl` properties (you should be able to find these in the API documentation of the service provider). For instance with Twitter, one could implement a very simple `TwitterOAuthClient` class as below:

```csharp
public class TwitterOAuthClient : OAuthClient
{

    public TwitterOAuthClient()
    {
        RequestTokenUrl = "https://api.twitter.com/oauth/request_token";
        AuthorizeUrl = "https://api.twitter.com/oauth/authorize";
        AccessTokenUrl = "https://api.twitter.com/oauth/access_token";
    }

    public TwitterOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this()
    {
        ConsumerKey = consumerKey;
        ConsumerSecret = consumerSecret;
        Token = token;
        TokenSecret = tokenSecret;
    }
    
}
```

In OAuth 1.0a terminology, your app is called a *consumer*. Most service providers enables you to access public resources without a user context, in which case you you'll only have to specify the `ConsumerKey` and `ConsumerSecret` properties of the client. Other resources may require user authorization, in which case you'll only have to specify the `Token` and `TokenSecret` properties. 

## OAuth 2.0

OAuth 2.0 supports a number of different flows for authentication, but the most widely used flow is still the web flow. Assuming you have a website where you wish to let your users log in using an external service provider (eg. Facebook or Google), you'll set up an authorization page on your website. When users go to this page, they will be redirected to an authorization page on the website of the service provider, where the users then can either grant or deny your app access. In either case, the user will then we redirected back to your own authorization page.

When being granted access by a user, you'll receive an access token to their account. This access token will then you access the resources on the services providers website taht the user granted you access to.



In this package, you can use the <code type="Skybrud.Essentials.Http.Client.HttpClient, Skybrud.Essentials.Http"></code> class to work with OAuth 2.0 service providers. As the steps for authorization differs a bit from each service proider, it doesn't help you with the authorization flow out of the box. But if you've already received an access token from the service provider, you can extend the class similar to the example shown below:

```csharp
public class MyHttpClient : HttpClient
{

    public string AccessToken { get; set; }

    protected override void PrepareHttpRequest(IHttpRequest request)
    {

        if (string.IsNullOrWhiteSpace(AccessToken) == false)
            request.Headers.Authorization = "Bearer " + AccessToken;

    }

}
```

In this example, the `MyHttpClient` class extends the <code type="Skybrud.Essentials.Http.Client.HttpClient, Skybrud.Essentials.Http">HttpClient</code> class, so it inherits all it's methods as well. In the <code type="Skybrud.Essentials.Http.Client.HttpClient, Skybrud.Essentials.Http">HttpClient</code> class, all requests are run through the `PrepareHttpRequest` prior to making the request, so we can modify the request a bit - eg. set the `Authorization` header with the access token.
