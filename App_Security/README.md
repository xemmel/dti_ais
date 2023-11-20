## Walkthrough

### Create API App Registration

- Create *AAD* App Registration
- Get the *ClientId* and *TenantId*
- Click *Expose an API*
- *Application ID URI* -> **Set**
- Keep the suggested name or choose *https://[tenantname]/[webapiname]
- Get the name set before. This is the API's *audience*
- *Save*

### Make yourself owner of the API App
- Goto *Owners* (when standing inside the APP)
- Click **+ Add Owners** and add yourself
  


### Create Web App Registration
- Get *ClientId* and *TenantId* and *Secret*


### Get Token as Web App towards API (audience)

```powershell

Clear-Host;
$clientId = "..."; ## Web App ClientId
$clientSecret = "..."; ## Web App
$tenantId = "...";
$audience = "..."; ## Web API audience

$scopes = "$($audience)/.default";


$url = "https://login.microsoftonline.com/$($tenantId)/oauth2/v2.0/token";

$body = "";

$body += "client_id=$($clientId)";
$body += "&client_secret=$($clientSecret)";
$body += "&grant_type=client_credentials";
$body += "&scope=$($scopes)";


$response = $null;
$response = Invoke-WebRequest `
            -method Post `
            -Uri $url `
            -Body $body;
$response.Content;

$token = $response.Content | ConvertFrom-Json | Select-Object -ExpandProperty access_token;
$token | Set-Clipboard;


```

- use jwt.ms to examine the token

### Add App Role

- In the *API App Registration* goto Manage->App Roles
- Add a Role *Reader*

### Assign App Role to Web App

- In the *Web App App Registration* goto Manage->API Permissions
- Click *+ Add a permission*
- Choose *My APIs*
- Choose your *API*
- Choose *Application Permissions*
- Choose the *Reader* Role

### Get a token with the reader role

- Run the **Powershell** script from before to get an access token
- It might take a minute or two before the role appears



  
  ## Web Api

### Create Project

```powershell

dotnet new webapi -o secureapi
cd secureapi
dotnet add package Microsoft.Identity.Web

```

### Add Code

```csharp

using Microsoft.Identity.Web;

builder
    .Services
    .AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);
    
  

app.UseAuthentication();
app.UseAuthorization();


//Controllers
[ApiController]
[Authorize]
[Route("[controller]")]


[HttpGet(Name = "GetWeatherForecast")]
[Authorize(Roles = "writer")]


```

> appsettings.json

Audience ONLY needed if not using MS' suggested value

```json

  "AllowedHosts": "*",
  "AzureAd" : {
    "ClientId" : "..",
    "TenantId" : "..",
    "Instance": "https://login.microsoftonline.com/",
    "Audience" : ".."
  }

```
### Test

/weatherforecast
