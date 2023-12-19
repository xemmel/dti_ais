## Table of Content
- [Table of Content](#table-of-content)
  - [First Http Trigger](#first-http-trigger)
  - [Storage Queue Trigger](#storage-queue-trigger)
  - [C# Function](#c-function)


### First Http Trigger

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
  - Try *function key** in header instead of *query string*
    - x-functions-key: key

 
[Back to top](#table-of-content)

### Storage Queue Trigger

- Create new external *storage account*
- in the *storage account* create new queue
- Copy the name of the **storage account** and the **queue**
- in the *function app* create new function *Azure Queue Storage Trigger*
- Scroll down
- In *Queue Name* insert the queue name from before
- Under *Storage account connection* click **New** choose your storage account
- Click *Create*

- Goto the newly created function under *Code + Test*
- Change log to *Filesystem Logs*
  
- Back in the storage account go into the queue
- Notice that you might not have access to the *data plane* and therefore gets an error **You do not have per...**
  - Goto *Access Control (IAM)
  - Click *+ ADD* -> *Add Role Assignment*
  - Choose role *Storage Queue Data Message Sender*
  - Alt: Enable *Storage account key access* on the *storage account overview*

- Click: *+ Add message* and submit a message
- Go back to the queue function and check *Filesystem logs* within a minute a message should appear and the message should be gone from the queue



[Back to top](#table-of-content)


### C# Function

- Create new Function App (.csproj)

```powershell

func init dgifunctions --worker-runtime dotnet-isolated --target-framework net8.0

cd dgifunctions

func new -n MyHttpTrigger (-t HttpTrigger)

### Open favorite editor

func start


```

Postman -> URL



[Back to top](#table-of-content)
