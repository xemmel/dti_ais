# AIS COURSE
## Morten la Cour
### lacour@gmail.com
### mlc@integration-it.com

## Table of Content
1. [Prequisites](#prequisites)
2. [Logic Apps](#logic-apps)
3. [Azure Functions](#azure-functions)
4. [Service Bus](#service-bus)
5. [Relay](#lrelay)
6. [Event Grid](#event-grid)
7. [API Management](#api-management)
8. [Deployment](#deployment)
9. [Deployment2](#deployment-2)
10. [Security](#security)
11. [Data Factory](#data-factory)
12. [Pricing](#pricing)
13. [Final Project](#final-project)
14. [Kubernetes](#kubernetes)
15. [KeyVault Reference](#keyvault-reference)
16. [Powershell commands](#powershell-commands)
17. [Links](#links)
18. [Kusto](#kusto)
19. [Redis](#redis)

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
94936269
```

### Azure Keys

Student Pass Code	Validity Date


| Student                  | Pass               | 
|:------------------------:| ------------------:|
| Hans-Henrik Basse        | QYMCXB57EWNVKV8BQS |
| Henrik Bøgelund Sørensen | QC3Z4CCIJKBF9ZOLH3 |
| John Tiab                | Q5ULUMVXPPS65GDV7X |
| Morteza Yamini           | QTG8XK0IJ1EHLI8499 |
| Morten la Cour           | QCF99YDTJGDHLPGL00 |

[Microsoft Azure Pass Start](https://www.microsoftazurepass.com)

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
choco install azure-functions-core-tools -y
choco install vscode -y
choco install postman -y
choco install notepadplusplus -y
choco install git -y
choco install dotnet-sdk -y

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

### Register Nuget.org

```powershell
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

[Back to top](#table-of-content)

## Deployment 2

```json

{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "storageName" : { "type" : "string" },
        "location" : {"type" : "string","defaultValue": "[resourceGroup().location]" },
        "sku" : { "type" : "string", "defaultValue": "Standard_GRS" }
    },
    "variables": {},
    "resources": [
        {
            "type": "Microsoft.Storage/storageAccounts",
            "apiVersion": "2021-09-01",
            "name": "[parameters('storageName')]",
            "location": "[parameters('location')]",
            "sku": {
                "name": "[parameters('sku')]"
            },
            "kind": "StorageV2"
        }
    ]
}

```

```json

{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "storageName" : { "value": "thestupidstoragetest" },
        "sku" : { "value" : "Standard_LRS" }
    }
}

```


```powershell 
az deployment group create --resource-group $rgName --template-file .\Templates\storageAccount.json --parameters .\Parameters\Prod\storageAccount.json
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

### Cli Deployment

```powershell

## Login az
az login --use-device-code



### Deploy arm template with parameter file (change names and folder location if needed)

az deployment group create --resource-group ais2022 --template-file .\storageAccount.json --parameters .\parameters\prod\storageAccount.json



```

#### Arm template

```json

{
	"$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
	"contentVersion": "1.0.0.0",
	"parameters" : {
		"accountName" : { "type" : "string" },
		"skuName" : { "type" : "string", "defaultValue" : "Standard_LRS"},
		"skuTier" : { "type" : "string", "defaultValue" : "Standard"},
		"kind" : 	{ "type": "string", "defaultValue" : "StorageV2" },
		"location" : { "type" : "string", "defaultValue" : "[resourceGroup().location]"}
	},
	"resources": [
		{
			"type": "Microsoft.Storage/storageAccounts",
			"apiVersion": "2021-06-01",
			"name": "[parameters('accountName')]",
			"location": "[parameters('location')]",
			"sku": {
                "name": "[parameters('skuName')]",
                "tier": "[parameters('skuTier')]"
            },
			"kind": "[parameters('kind')]"
		}
	]
}

```

#### parameter file

```json

{
	"$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
	"contentVersion": "1.0.0.0",
	"parameters": {
		"accountName": {
			"value": "mystooooragprod"
		},
		"skuName": {
			"value": "Standard_GRS"
		},
		"skuTier": {
			"value": "Standard"
		}
	}
}

``` 


### Bicep


#### Install bicep az

```powershell
az bicep install

## Confirm install
az bicep version


```

#### A simple sample

```json

targetScope = 'resourceGroup'

param accountName string
param location string = resourceGroup().location

param skuName string = 'Standard_LRS'
param kind string = 'StorageV2'

resource account 'Microsoft.Storage/storageAccounts@2021-06-01' = {
  name: accountName
  location: location
  sku: {
    name: skuName
  }
  kind: kind
}

```

#### Deploy

```powershell

az deployment group create --resource-group ais2022 --template-file .\storageAccount.bicep --parameters .\parameters\prod\storageAccount.json

```` 

#### Log Analytics and Logic App bicep samples


> solution.bicep
```
targetScope = 'resourceGroup'

param appName string
param env string


// Log Analytics
var logAnalyticsName = 'log-${appName}-${env}'
module logana 'LogAnalytics.bicep' = {
  name: 'logana'
  params: {
    logAnalyticsName: logAnalyticsName
  }
}

//Logic App
var logicAppName = 'myloganalyticflow'

module logicapp 'logicapp.bicep' = {
  name: 'logicapp'
  params: {
    logicAppName: logicAppName
    logAnalyticsId: logana.outputs.id
  }
}


```

> Log Analytics

```

targetScope = 'resourceGroup'

param logAnalyticsName string
param location string = resourceGroup().location




resource loganalytics 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: logAnalyticsName
  location: location
}

output id string = loganalytics.id
output customerId string = loganalytics.properties.customerId



```


> Logic App

```

targetScope = 'resourceGroup'

param logicAppName string
param location string = resourceGroup().location

param logAnalyticsId string

resource logicapp 'Microsoft.Logic/workflows@2019-05-01' = {
  name: logicAppName
  location: location
  properties: {
    definition: {
      '$schema' : 'https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#'
      contentVersion: '1.0.0.0'
      actions: {
        GetRequest: {
          inputs: '@triggerBody()'
          type: 'Compose'
          runAfter: {}
        }
      }
      triggers: {
        http: {
          inputs: {
            schema: {}
          }
          type: 'Request'
          kind: 'Http'
        }
      }
    }
  }
}


//Logic App Diagnostic Settings
resource diagnosticSettings 'Microsoft.Logic/workflows/providers/diagnosticSettings@2021-05-01-preview' = {
  name: '${logicAppName}/Microsoft.Insights/diag'
  dependsOn: [ 
    logicapp 
  ]
  properties: {
    workspaceId: logAnalyticsId
    logs: [
      {
        category: 'WorkflowRuntime'
        enabled: true
      }
    ]
    metrics: [
      {
        category: 'AllMetrics'
        enabled: true
      }
    ]
  }
}


```
[Back to top](#table-of-content)

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
    "id" : "123456",
    "subject" : "morten.txt",
    "eventType" : "FileCreated",
    "eventTime" : "2021-10-13",
    "data" : {
        "orderSize" : 18,
        "orderId" : "127",
        "customer" : "AVK"
    }
},
    {
    "id" : "123456",
    "subject" : "morten.txt",
    "eventType" : "FileCreated",
    "eventTime" : "2021-10-13",
    "data" : {
        "orderSize" : 180,
        "orderId" : "127",
        "customer" : "AVK"
    }
}
]

```

- Create Two Logic Apps
(Code may need to have names and path's changed)

```powershell

Clear-Host;
$rgName = "dtiais2021";

# New-AzResourceGroup -Name $rgName -Location "westeurope";

$result = New-AzResourceGroupDeployment -ResourceGroupName $rgName `
    -Mode Incremental -TemplateFile .\eventgrid_logic_app.json `
    -TemplateParameterFile .\Parameters\Test\eventgrid_logicapp_small_orders.json;


# $result;



```


> Retrieve Logic App URL after deployment

```powershell

$result.Outputs["logicAppUrl"].Value
$result.Outputs["logicAppUrl"].Value | Set-Clipboard 

```

> Parameters
Create both small and large Logic App, so two param files will be needed

```json

{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
      "logicapp_name": {
        "value": "Process_Large_Orders"
      }
    }
  }

```

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "logicapp_name": { "type": "string" }
    },
    "variables": {
        "logicappVersion" : "2017-07-01"
    },
    "resources": [
        {
            "type": "Microsoft.Logic/workflows",
            "apiVersion": "[variables('logicappVersion')]",
            "name": "[parameters('logicapp_name')]",
            "location": "westeurope",
            "properties": {
                "state": "Enabled",
                "definition": {
                    "$schema": "https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#",
                    "contentVersion": "1.0.0.0",
                    "parameters": {},
                    "triggers": {
                        "manual": {
                            "type": "Request",
                            "splitOn" : "@triggerBody()",
                            "kind": "Http",
                            "inputs": {
                                "schema": {},
                                "method" : "POST"
                            }
                        }
                    },
                    "actions": {
                        "Compose": {
                            "runAfter": {},
                            "type": "Compose",
                            "inputs": "trtr"
                        }
                    },
                    "outputs": {

                     }
                },
                "parameters": {}
            }
        }
    ],
    "outputs": {
        "logicAppUrl": {
            "type": "string",
            "value": "[listCallbackURL(concat(resourceId('Microsoft.Logic/workflows/', parameters('logicapp_name')), '/triggers/manual'), '2017-07-01').value]"
         }
    }
}

```

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

## Powershell Commands

```powershell

$url = "https://prod-132.westeurope.logic.azure.com:443/workflows/0d2338d7a97d4ba2ae77e48f58066c38/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=XC_bl4p91RyrfWyuB8zfszYPWkqo8u_0jPPtkfy7x4U";
Invoke-WebRequest $url -Method Post -body "{ ""location"" : ""copenhagen"" }" -Headers @{ "Content-Type" = "application/json" }

```

[Back to top](#table-of-content)

## Links

[Logic app Expressions](https://docs.microsoft.com/en-us/azure/logic-apps/workflow-definition-language-functions-reference)


[Back to top](#table-of-content)

## Kusto

### All Requests

```

AppRequests
| where TimeGenerated > ago(2h)
| where Success == false
| project TimeGenerated, Name, Success, DurationMs, PerformanceBucket, OperationId
| order by TimeGenerated desc

```

### Traces

```
AppTraces
| where OperationId  == 'operationid'
| project TimeGenerated, Message, SeverityLevel
| order by TimeGenerated asc

```

### Exceptions

```

AppExceptions
| where OperationId  == 'operationid'
| project TimeGenerated, OuterMessage, InnermostMessage
| order by TimeGenerated asc

```


### Success (Piechart)

```

AppRequests
| where TimeGenerated > ago(2h)
| summarize count() by tostring(Success)
| render piechart 

```

### Executions by time (and success)

```

AppRequests
| where TimeGenerated > ago(2h)
| summarize count() by bin(TimeGenerated, 5m), tostring(Success)
| render barchart 


```

[Back to top](#table-of-content)



## Redis

```powershell

dotnet add package StackExchange.Redis

```

```csharp

// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

string connectionString = "tekno.redis.cache.windows.net:6380,password=........=,ssl=True,abortConnect=False";

using var cache = ConnectionMultiplexer.Connect(connectionString);
IDatabase db = cache.GetDatabase();

//Ping pong
var result = await db.ExecuteAsync("ping");

System.Console.WriteLine(result);

//Cache the value
string value = "secret!!";

await db.StringSetAsync("thetype:id",value);

//Retrieve the value
var thefinalResult = await db.StringGetAsync("thetype:id");

System.Console.WriteLine($"The cached value was: {thefinalResult}");

```

[Back to top](#table-of-content)


