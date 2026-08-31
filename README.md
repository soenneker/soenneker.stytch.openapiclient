[![](https://img.shields.io/nuget/v/soenneker.stytch.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stytch.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stytch.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.stytch.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.stytch.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.stytch.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.stytch.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.stytch.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Stytch.OpenApiClient

A Kiota-generated .NET client for Stytch's consumer and B2B authentication API endpoints.

## Installation

```bash
dotnet add package Soenneker.Stytch.OpenApiClient
```

## Usage

```csharp
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Stytch.OpenApiClient;
using Soenneker.Stytch.OpenApiClient.Models;

string credentials = Convert.ToBase64String(
    Encoding.UTF8.GetBytes($"{projectId}:{secret}"));

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Basic", credentials);

var authentication = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient)
{
    BaseUrl = "https://test.stytch.com"
};

var stytch = new StytchOpenApiClient(adapter);

ApiUserV1GetResponse? response = await stytch.V1.Users["user-test-..."].GetAsync(
    cancellationToken: cancellationToken);
```

Use `https://test.stytch.com` with test credentials and `https://api.stytch.com` with live credentials. Keep the `HttpClient`, request adapter, and `StytchOpenApiClient` for reuse instead of constructing them per request.

The generated API follows Stytch's OpenAPI operation and schema names. Regeneration can add or rename generated types as the upstream schema changes.
