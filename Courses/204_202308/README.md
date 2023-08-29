
### Create New Console Project

```powershell

dotnet new console -o theprojectname

cd theprojectname

##Inside the project folder
dotnet add package Azure.Identity

dotnet add package Azure.Storage.Blobs

### Open VS Code

code .

```


```csharp

using Azure.Storage.Blobs;

var credentials = new Azure.Identity.DefaultAzureCredential();

string accountName = "[youraccountname]";



var client = new BlobServiceClient(
        serviceUri: new Uri($"https://{accountName}.blob.core.windows.net"),
        credential: credentials);

await foreach(var container in client.GetBlobContainersAsync())
{
    System.Console.WriteLine(container.Name);
}

```