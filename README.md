# AIS COURSE
## Morten la Cour
### lacour@gmail.com


## Table of Content
1. [Prequisites](#prequisites)
2. [Logic Apps](#logic-apps)
3. [Azure Functions](#logic-apps)
4. [Service Bus](#logic-apps)
5. [Relay](#logic-apps)
6. [Event Grid](#event-grid)
7. [API Management](#logic-apps)
8. [Deployment](#deployment)
9. [Security](#security)
10. [Data Factory](#data-factory)
11. [Pricing](#pricing)
12. [Final Project](#final-project)
13. [Kubernetes](#kubernetes)
14. [KeyVault Reference](#keyvault-reference)

## API Walkthrough

URl: http://postnumbers.westeurope.azurecontainer.io/Service.asmx

payload

```xml

<Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
	<Body>
		<GetCity xmlns="http://tempuri.org/">
    		<postnumber>8000</postnumber>
    	</GetCity>
	</Body>
</Envelope>

```

## Exam study

https://docs.microsoft.com/en-us/azure/api-management/api-management-access-restriction-policies#ValidateJWT

https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core




## Prequisites

### NUGET
C:\Users\Admin\AppData\Roaming\NuGet
NuGet.Config
```xml

<?xml version="1.0" encoding="utf-8"?>
<configuration>
 <packageSources>
   <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
 </packageSources>
</configuration>

```
### Wifi

```
TEKNOLOGISK-GUEST
51648729
```

### Azure Keys
```
Student Pass Code	Validity Date


 

Voucher Code

Q6R35UDZPWCIIO60TB

QBRGPJ3P12MO1U082C

QYYGS7REQ4D386XHNQ

QELUTUGYLW1SO6PV0M



``` 

### Install Chocolatey

> In Powershell (Administrator)

```powershell

Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

```
> Powershell might need to be reopened

### Install Powershell Core
```powershell

choco install powershell-core -y

```


### Install everything

```powershell

choco install az.powershell -y
choco install azure-cli -y
choco install azure-functions-core-tools-3 -y
choco install vscode -y
choco install postman -y
choco install notepadplusplus -y

```

### Update all

```powershell
## Check, run in "old" powershell if powershell-core needs update
choco upgrade all --noop

choco upgrade all -y
```

### Install Powershell AZ

```powershell
choco install az.powershell -y

```

### Install Azure Cli

```powershell

choco install azure-cli -y

```

### Install Azure Functions CLI

```powershell
choco install azure-functions-core-tools-3 -y
```

### Install Visual Studio Code

```powershell
choco install vscode -y
```


### Install Postman

```powershell
choco install postman -y
```

### Install Nodepad++

```powershell

choco install notepadplusplus -y 

```

### Service Bus Explorer

```
https://github.com/paolosalvatori/ServiceBusExplorer/releases

```


### Logon to Azure in Powershell

```powershell
Connect-AzAccount
```

```powershell
Select-AzSubscription -SubscriptionId .......
```

```powershell
Select-AzContext [Tab for all available logins]

```


[Back to top](#table-of-content)


## Logic Apps

1 Trigger x Actions

### An action
```json
{
	"inputs" : {}, //""
	"type" : "",
	"runAfter : { "ActionName" : [ "Succeeded" ] } //First action : {}
}
 ```

### Logic App Action Language

this is @{logic app language} bla bla -> Code only inside {} 

@outputs('action')
> Get the raw output of Action
@outputs('name of action') -> Action must be a previous step

> Get the body of the json
@body('actionName') === @outputs('actionName')['body']

> The the content (headers/payload) of the trigger
@triggerOutputs()
@triggerBody() === @triggerOutputs()['body']


[Back to top](#table-of-content)

### Response

```json
"Response": {
                "inputs": {
                    "body": "nnnnn",
                    "statusCode": 200
                },
                "runAfter": {},
                "type": "Response"
            }
```

## Deployment


### Storage Account Deployment


```powershell

Clear-Host;
$rgName = "dtiarm";

New-AzResourceGroup -Name $rgName -Location "westeurope";

New-AzResourceGroupDeployment -ResourceGroupName $rgName `
    -Mode Incremental -TemplateFile .\create_storage_account.json `
    -TemplateParameterFile .\parameter2.json;





```


> template

```json

{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "storageName": { "type": "string", "maxLength": 24 },
        "sku" : { "type" : "string", "defaultValue": "Standard_LRS"},
        "location" : { "type" : "string", "defaultValue": "[resourceGroup().location]"}
    },
    "variables": {},
    "resources": [
        {
            "type": "Microsoft.Storage/storageAccounts",
            "apiVersion": "2021-04-01",
            "name": "[parameters('storageName')]",
            "location": "westeurope",
            "sku": {
                "name": "[parameters('sku')]",
                "tier": "Standard"
            },
            "kind": "StorageV2",
            "properties": {
                "accessTier": "Hot"
            }
        }
    ]
}

```


> Parameters

```json

{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
      "storageName": {
        "value": "dtifirststorage"
      }
    }
  }
```
[Back to top](#table-of-content)


```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "workflowName" : { "type" : "string" },
        "responseText" : { "type" : "string" },
        "location" : { "type" : "string", "defaultValue": "[resourceGroup().location]" }
    },
    "resources": [
        {
            "type": "Microsoft.Logic/workflows",
            "apiVersion": "2017-07-01",
            "name" : "[parameters('workflowName')]",
            "location": "[parameters('location')]",
            "properties" : {
                "definition": {
                    "$schema": "https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#",
                    "contentVersion": "1.0.0.0",
                    "triggers" : {
                        "manual": {
                            "inputs": {
                                "method": "Get",
                                "schema": {}
                            },
                            "kind": "Http",
                            "type": "Request"
                        }
                    },
                    "actions" : {
                        "ComposeIt" : {
                            "inputs" : "[parameters('responseText')]",
                            "type" : "Compose",
                            "runAfter" : {}
                        },
                        "Reponse" : {
                            "inputs" : { "statusCode" : 200, "body" : "@outputs('ComposeIt')" },
                            "type" : "Response",
                            "runAfter" : { "ComposeIt" : [ "Succeeded" ] }
                        }
                    }
                }
            }

        }
]
  }

```
### Deploy Arm Template from Powershell

```powershell

New-AzResourceGroupDeployment -ResourceGroupName [resourceGroupName] -TemplateFile C:\teaching\dti_ais\armtemplate.json -Verbose      

```

### Arm template parameter file

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "nameOfParameter" : { "value" : "Morten1" }
       
     }
  }
```

[Back to top](#table-of-content)

## Api Management

### Sequence

```
outbound Operation before base,
Outbound Api before base,
Outbound Product before base,
Outbound Service before base,
Outbound Service after base,
Outbound Product after base,
Outbound Api after base,
outbound Operation after base

```

http://lacourpostnumber.westeurope.azurecontainer.io/Service.asmx

```xml

<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetCity xmlns="http://tempuri.org/">
      <postnumber>9000</postnumber>
    </GetCity>
  </soap:Body>
</soap:Envelope>

```

## Event Grid

- Create Event Grid Topic
- Get Url
- Get Key
  - Set header "aeg-sas-key: key"

- call endpoint with the following json

```json

[
    { 
        "id" : "1234",
        "subject" : "fileEvents",
        "eventType" : "fileCreated",
        "eventTime" : "2010-01-01",
        "data" : {
            "receiverId" : "DS",
            "customerId" : "3344",
            "correlationId" : "4343-434343-43-4343"
        }
     }
]

```

- Create LA HTTP Trigger
- Create subscription with LA endpoint url as webhook
- (Experiment with filters on the subscriptions)

[Back to top](#table-of-content)
## Api Management

### CORS

> Place under policy (All API's)
```xml

<inbound>
        <cors>
            <allowed-origins>
                <origin>*</origin>
            </allowed-origins>
            <allowed-methods>
                <method>GET</method>
                <method>POST</method>
                <method>PUT</method>
                <method>DELETE</method>
                <method>HEAD</method>
                <method>OPTIONS</method>
                <method>PATCH</method>
                <method>TRACE</method>
            </allowed-methods>
            <allowed-headers>
                <header>*</header>
            </allowed-headers>
            <expose-headers>
                <header>*</header>
            </expose-headers>
        </cors>
    </inbound>


```

[Back to top](#table-of-content)

## Pricing

```
https://azure.microsoft.com/en-us/pricing/calculator/

```

[Back to top](#table-of-content)


## Final Project


```xml
<Order xmlns="http://dti.dk">
<Id>17</Id>
<Item>765</Item>
<Qty>17</Qty>
</Order>

```


### Extract Blob Path and name from subject

```json
 "Compose": {
                "inputs": "@{split(triggerBody()['subject'],'/')[4]}/@{split(triggerBody()['subject'],'/')[6]}",
                "runAfter": {},
                "type": "Compose"
            }

```

## Split On

```json

                "kind": "Http",
                "splitOn" : "@triggerBody()",
                "type": "Request"

                
```

## Function Transform XML


```csharp

#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Xsl;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, string myInputBlob)
{
 

    string xml = await new StreamReader(req.Body).ReadToEndAsync();
    string xslt = myInputBlob;

    string responseMessage = TransformXML(xml: xml, xsl: xslt);

            return new OkObjectResult(responseMessage);
}

        public static string TransformXML(string xml, string xsl, bool Text = false)
        {
            StringReader sr_xml;
            StringReader sr_xsl;
            sr_xml = new StringReader(xml);
            sr_xsl = new StringReader(xsl);
            XslCompiledTransform trans = new XslCompiledTransform();

            XmlReaderSettings readerSettings = new XmlReaderSettings();

            readerSettings.DtdProcessing = DtdProcessing.Ignore;

            XmlReader xml_reader = XmlReader.Create(sr_xml, readerSettings);
            XmlReader xsl_reader = XmlReader.Create(sr_xsl, readerSettings);
            XsltSettings set = new XsltSettings();
            set.EnableScript = true;
            set.EnableDocumentFunction = true;
            trans.Load(xsl_reader, set, new XmlUrlResolver());
            StringWriter sw = new StringWriter();
            XmlWriter xw = XmlWriter.Create(sw, trans.OutputSettings);
            trans.Transform(xml_reader, xw);
            return sw.ToString();
        }


```


```json

{
  "bindings": [
    {
      "authLevel": "function",
      "name": "req",
      "type": "httpTrigger",
      "direction": "in",
      "methods": [
        "get",
        "post"
      ]
    },
    {
      "name": "myInputBlob",
      "type": "blob",
      "path": "xslt/CustomerOrder_to_InternalOrder.xslt",
      "connection": "AzureWebJobsStorage",
      "direction": "in"
    },
    {
      "name": "$return",
      "type": "http",
      "direction": "out"
    }
  ]
}

```



### XSLT file

Storage: create container named **xslt**

CustomerOrder_to_InternalOrder.xslt


```xml

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:source="http://dti.dk" exclude-result-prefixes="source" xmlns:target="http://internal">

<xsl:template match="source:Order">
   <target:CompanyOrder>
<OrderId>
<xsl:value-of select="source:Id" />
</OrderId>
<ItemNo>
<xsl:value-of select="source:Item" />
</ItemNo>
<Quantity>
<xsl:value-of select="source:Qty" />
</Quantity>
</target:CompanyOrder>
</xsl:template>

</xsl:stylesheet>

```


[Back to top](#table-of-content)


## Kubernetes


```yaml

apiVersion: apps/v1
kind: Deployment
metadata:
  name: sqlserver-deployment
spec:
  selector:
    matchLabels:
      app: sqlserver
  replicas: 2
  template:
    metadata:
      labels:
        app: sqlserver
    spec:
      containers:
      - name: sqlserver
        image: mcr.microsoft.com/mssql/server:2019-latest
        imagePullPolicy: Never
        ports:
        - containerPort: 1433
        env:
        - name: MSSQL_PID
          value: "Express"
        - name: ACCEPT_EULA
          value: "Y"
        - name: SA_PASSWORD
          value: "Hyllew001"
---
apiVersion: v1
kind: Service
metadata:
  name: sqlserver-front
spec:
  type: LoadBalancer
  ports:
  - port: 8821
    targetPort: 1433
  selector:
    app: sqlserver

```

```

kubectl apply -f .\kuber_real_website.yaml

kubectl delete -f .\kuber_real_website.yaml

kubectl get all

kubectl config get-contexts
kubectl config use-context docker-desktop

## Connect to Azure Kuber

az aks get-credentials --resource-group kube2204 --name kube220401

```

[Back to top](#table-of-content)

## KeyVault Reference

```powershell

## KEY VAULT REFERENCE IN FUNCTION APP

$rgName = "vault20402";

az group create -n $rgName -l westeurope;

az monitor log-analytics workspace create -g $rgName -n "loga-$rgName";

 $logaId = az monitor log-analytics workspace show -g $rgName -n "loga-$rgName" | ConvertFrom-Json | Select-Object -ExpandProperty id
 
 az monitor app-insights component create -a "app-$rgName" -l westeurope -g $rgName --workspace $logaId;
 
 az storage account create -g $rgName -n "store$($rgName)";
 
 az keyvault create -l westeurope -n "kv-$rgName" -g $rgName --no-wait
 az keyvault create -l westeurope -n "kv-vault20401" -g $rgName

 
az functionapp create -g $rgName --consumption-plan-location westeurope `
    --runtime dotnet-isolated --runtime-version 5.0 --functions-version 3 `
         --name "funcapp-$rgName" --storage-account "store$($rgName)" `
         --app-insights "app-$rgName"
		 
		 az functionapp create -g $rgName --consumption-plan-location westeurope `
    --runtime dotnet --runtime-version 3.1 --functions-version 3 `
         --name "funcapp-$rgName" --storage-account "store$($rgName)" `
         --app-insights "app-$rgName" --no-wait
		 
## No identity

az functionapp identity show -g $rgName -n "funcapp-$rgName"

az functionapp identity assign -g $rgName -n "funcapp-$rgName"

$principalId = az functionapp identity show -g $rgName -n "funcapp-$rgName" | ConvertFrom-Json | Select-Object -ExpandProperty principalId


## Add Secret

az keyvault secret set --name "vaultsecret" --vault-name "kv1-$rgName"  --value "Private Secret2"


Add Security Policty to Vault

az keyvault set-policy -n "kv1-$rgName" --secret-permissions get --object-id $principalId

$appSetting = "mortensecret=@Microsoft.KeyVault(SecretUri=https://kv1-$rgName.vault.azure.net/secrets/MortenSecret/)";
az functionapp config appsettings set -g $rgName -n "funcapp-$rgName" --settings "'" + $appSetting + "'"


az functionapp config appsettings set -g $rgName -n "funcapp-$rgName" --settings '"

mortensecret=@Microsoft.KeyVault(SecretUri=https://kv1-vault20401.vault.azure.net/secrets/mortensecret)"'

#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
            string responseMessage = System.Environment.GetEnvironmentVariable("mortensecret");
            return new OkObjectResult(responseMessage);
}



az group delete -n $rgName --yes --no-wait

```

[Back to top](#table-of-content)
