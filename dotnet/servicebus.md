```csharp
// See https://aka.ms/new-console-template for more information
//dotnet new console -o rrrrrrrr
using Azure.Identity;
//using Azure.Identity;
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");


//var credentials = new AzureCliCredential();
var credentials = new DefaultAzureCredential();

var client = new ServiceBusClient(fullyQualifiedNamespace: "the204sb.servicebus.windows.net",credential: credentials);

var sender = client.CreateSender("myfirsttopic");

var message = new ServiceBusMessage("Hello from .NET");
message.ApplicationProperties.Add("region","SJ");
message.ApplicationProperties.Add("qty",int.Parse(args[0]));


await sender.SendMessageAsync(message);
System.Console.WriteLine("Message sent!");


```

```xml

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Azure.Identity" Version="1.8.0" />
    <PackageReference Include="Azure.Messaging.ServiceBus" Version="7.11.1" />
  </ItemGroup>

</Project>


```