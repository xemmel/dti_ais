# AIS COURSE
## Morten la Cour
### lacour@gmail.com


## Table of Content
1. [Prequisites](#prequisites)
2. [Logic Apps](#logic-apps)
3. [Azure Functions](#logic-apps)
4. [Service Bus](#logic-apps)
5. [Relay](#logic-apps)
6. [Event Grid](#logic-apps)
7. [API Management](#logic-apps)
8. [Deployment](#logic-apps)
9. [Security](#logic-apps)
10. [Data Factory](#data-factory)
11. [Pricing](#pricing)









## Prequisites

### Wifi

```
TEKNOLOGISK-GUEST
51648729
```

### Azure Keys
```
Student Pass Code	Validity Date

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



```json

{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "apiProfile": "",
  "parameters": { 
		"logicAppName" : {
			"type" : "string"
		},
		"message": {
			"type" : "string",
			"defaultValue" : "The deployer had nothing to say"
		},
		"location" : {
			"type": "string",
			"defaultValue" : "[resourceGroup().location]"
		}
  },
  "variables": { 
		"apiVersion" : "2019-05-01"
  },
  "functions": [  ],
  "resources": [ 
	{
			"type" : "Microsoft.Logic/workflows",
			"name" : "[parameters('logicAppName')]",
			"apiVersion" : "[variables('apiVersion')]",
			"location" : "[parameters('location')]",
			"properties" : {
				"definition" : {
					"$schema" : "https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#",
					"contentVersion" : "1.0.0.0",
					"actions" : {
						"SetResponseCompose" : {
							"inputs" : "[parameters('message')]",
							"type" : "Compose",
							"runAfter" : {}
						},
						"Response" : {
							"inputs" : {
								"statusCode" : 200,
								"body" : "@outputs('SetResponseCompose')"
							},
							"type": "Response",
							"kind" : "Http",
							"runAfter" : {
								"SetResponseCompose" : [ "Succeeded" ]
							}
						}
					},
					"triggers" : {
						            "manual": {
					"inputs": {
                    "method": "GET",
                    "schema": {}
					},
						"kind": "Http",
						"type": "Request"
					}
					}
				}
			}
	}
  ],
  "outputs": {
   "logicAppUrl": {
      "type": "string",
      "value": "[listCallbackURL(concat(resourceId('Microsoft.Logic/workflows/', parameters('logicAppName')), '/triggers/manual'), '2019-05-01').value]"
   }
}
}

```
### Deploy Arm Template from Powershell

```powershell

New-AzResourceGroupDeployment -ResourceGroupName [resourceGroupName] -TemplateFile C:\teaching\dti_ais\armtemplate.json -Verbose      

```

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

