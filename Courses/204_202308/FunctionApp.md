```powershell

## Create new Function App project (.csproj) (Isolated)

func init myinprocessfunctions --worker-runtime dotnetIsolated --target-framework net7.0

## Create new Function App project (.csproj) (In-process (soon to be deprecated))

func init myinprocessfunctions --worker-runtime dotnet

cd my....

### Create new Function

func new --name MyFunction [--template HttpTrigger]


## Run function app

func start
```


### Create Storage Queue Trigger

```csharp

        [Function("thefirstqueuetrigger")]
        public void Run([QueueTrigger("invoices", Connection = "externalStorageAccount")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }

```

> local.settings.json

```json
 "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "externalStorageAccount" : "......"
    }

```


### Output to Storage queue

```csharp
        [Function("thefirstqueuetrigger")]
        [QueueOutput("invoice2", Connection = "externalStorageAccount")]
        public string Run([QueueTrigger("invoices", Connection = "externalStorageAccount")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
           
            string output = $"I have processed: {myQueueItem}";
            return output;
        }


```

[Queue Trigger Doc](#https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue?tabs=in-process%2Cextensionv5%2Cextensionv3&pivots=programming-language-csharp)