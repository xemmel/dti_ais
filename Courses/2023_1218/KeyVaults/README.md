- Create KeyVault
  - Give yourself "Key Vault Administrator" Role
  - Create new secret "ftppassword"
- Create Function App
- Create new Function (Http Trigger)

```csharp

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

        string password = Environment.GetEnvironmentVariable("theftppassword");
//OPEN FTP CONNECTION
            return new OkObjectResult($"The password is: {password}");
}

```

- Call Function in Postman (expected empty string)
- In Function App
  - Under *Configuration* insert a *app Setting* 
    - theftppassword: @Microsoft.KeyVault(VaultName=dgidemo01;SecretName=ftppassword)
  
- Enable *System Managed Identity* on the Function App
- In Key Vault
  - Give the function app this role: Key Vault Secrets User (either on KV level or the actual secret)

- Wait and watch the green arrow in Function App/Configuration
- Call again in postman
  