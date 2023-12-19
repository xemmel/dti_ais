-----------------

Create new Function App
  - New Resource Group
  - Unique Name
  - Code
  - .NET
  - 6 (LTS)
  - Review + Create
  - Create

In newly created Function App
  - Overview -> Functions -> Create in Portal
  - Http Trigger -> Scroll down to give it proper name
  
Inside Http Trigger
  - Code + Test
  - Switch to *Filesystem Logs*
  - Insert following code or simular
  
```csharp

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    
    string responseMessage = "Hello from Function App";

            return new OkObjectResult(responseMessage);
}

```

  - **Get function URL**
  - Test in *Postman*
