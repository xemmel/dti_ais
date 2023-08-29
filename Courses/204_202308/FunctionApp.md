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