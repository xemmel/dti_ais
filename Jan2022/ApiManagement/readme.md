## Api Management

## Table of Content

1. [CLI Command](#cli-commands)
2. [SOAP To Rest walkthrough](#soap-to-rest-walkthrough)
3. [Create with AZ Powershell](#create-with-az-powershell)


### CLI Commands

### List Api Management Services

```powershell

az apim list -o jsonc --query "[].{name:name,baseUrl: gatewayUrl,admin:publisherName,email:publisherEmail,resourceGroup:resourceGroup}"

```

#### List Apis in Service

```powershell
$apiRg = "apim";
$apiServiceName = "apistore";

az apim api list --resource-group $apiRg --service-name $apiServiceName -o jsonc --query "[].{name:name,path:path,backend:serviceUrl,keyName: subscriptionKeyParameterNames.header}"

```

#### List operations

```powershell
 az apim api operation list --resource-group $apiRg --service-name $apiServiceName --api-id $apiId --query "[].{name:name,method:method,url:urlTemplate}" -o jsonc

```

[Back to top](#table-of-content)

### SOAP To Rest walkthrough

Soap service:
  - url: https://postnumbers.azurewebsites.net/Service.asmx
  - Content-Type: application/xml (might be text/xml in old *SOAP Services*)

  - Body:

```xml

<Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
	<Body>
		<GetCity xmlns="http://tempuri.org/">
    		<postnumber>8000</postnumber>
    	</GetCity>
	</Body>
</Envelope>

```

### Create API

```powershell
$apiId = "...";
$apiDisplayName = "ZipCodes";
$apiRg = "...";
$apiServiceName = "....";
$apiPath = $apiId
$subKeyName = "api-key";
$backend = "https://postnumbers.azurewebsites.net/Service.asmx";

az apim api create --resource-group $apiRg --service-name $apiServiceName --api-id $apiId `
    --display-name $apiDisplayName `
    --path $apiPath --service-url $backend  `
    --subscription-key-header-name $subKeyName --subscription-key-query-param-name $subKeyName `
    --subscription-required true;

```

### Create GetCity Operation

```powershell

$apiId = "zipcodes";
$apiRg = "....";
$apiServiceName = "....";
$operationName = "getcity";
$displayName = "GetCity";
$method = "GET";
$path = "/getcity/{zipcode}";

az apim api operation create --api-id $apiId --display-name $displayName `
    --method $method --resource-group $apiRg --service-name $apiServiceName `
    --url-template $path `
    --template-parameters name=zipcode type=paramType required="true"

```


#### Add Policies

> All Operations

```xml

<policies>
    <inbound>
        <base />
        <set-method>POST</set-method>
        <set-header name="Content-Type" exists-action="override">
            <value>application/xml</value>
        </set-header>
        <rewrite-uri template="?a=b" copy-unmatched-params="false" />
    </inbound>
    <backend>
        <base />
    </backend>
    <outbound>
        <base />
        <xml-to-json kind="javascript-friendly" apply="content-type-xml" consider-accept-header="true" />
    </outbound>
    <on-error>
        <base />
    </on-error>
</policies>


```

> GetCity Operation

```xml

<policies>
    <inbound>
        <base />
        <set-body template="liquid">
			<Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
				<Body>
					<GetCity xmlns="http://tempuri.org/">
						<postnumber>{{context.Request.MatchedParameters["zipcode"]}}</postnumber>
					</GetCity>
				</Body>
			</Envelope>
		</set-body>
    </inbound>
    <backend>
        <base />
    </backend>
    <outbound>
        <base />
    </outbound>
    <on-error>
        <base />
    </on-error>
</policies>

```


### Call

https://[apiServiceName].azure-api.net/zipcodes/getcity/7200

header: api-key [key]

[Back to top](#table-of-content)


## Create with AZ Powershell

### Create Api Management Service

```powershell
$apiMServiceName = "claralapi"
$rgName = "rg-$($apiMServiceName)";

$rg = New-AzResourceGroup -Name $rgName -Location "westeurope"

$apiMService = New-AzApiManagement -ResourceGroupName $rgName -Name $apiMServiceName `
    -Sku Consumption -Location $rg.Location -Organization myorg -AdminEmail "it@it.dk";

$apiContext = New-AzApiManagementContext -ResourceId $apiMService.Id;

```

### Create Api

```powershell

$apiName = "zipcodes";
$apiPostFix = "zipcodes";
$apiKeyName = "api-key";
$serviceUrl = "https://postnumbers.azurewebsites.net/Service.asmx";

$api = $apiContext | New-AzApiManagementApi -Name $apiName `
    -Path $apiPostFix -SubscriptionKeyHeaderName $apiKeyName -ServiceUrl $serviceUrl `
    -Protocols https;

```

### Create Operation

```powershell

$method = "GET";
$operationName = "getcity";
$urlTemplate = "/getcity/{zipcode}";

$zipcode = New-Object -TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter;
$zipcode.Name = "zipcode";
$zipcode.Type = 'string'

$operation = New-AzApiManagementOperation -Context $apiContext -ApiId $api.ApiId `
    -Name $operationName  -Method $method -UrlTemplate $urlTemplate `
    -TemplateParameters @($zipcode);

```

### Set Api Policies

```powershell

$policy = @"
<policies>
    <inbound>
        <base />
        <set-method>POST</set-method>
        <set-header name="Content-Type" exists-action="override">
            <value>application/xml</value>
        </set-header>
        <rewrite-uri template="?a=b" copy-unmatched-params="false" />
    </inbound>
    <backend>
        <base />
    </backend>
    <outbound>
        <base />
        <xml-to-json kind="javascript-friendly" apply="content-type-xml" consider-accept-header="true" />
    </outbound>
    <on-error>
        <base />
    </on-error>
</policies>
"@

Set-AzApiManagementPolicy -Context $apiContext -ApiId $api.ApiId -Policy $policy;

```

### Set Operation Policy

```powershell

$policy = @"

<policies>
    <inbound>
        <base />
        <set-body template="liquid">
			<Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
				<Body>
					<GetCity xmlns="http://tempuri.org/">
						<postnumber>{{context.Request.MatchedParameters["zipcode"]}}</postnumber>
					</GetCity>
				</Body>
			</Envelope>
		</set-body>
    </inbound>
    <backend>
        <base />
    </backend>
    <outbound>
        <base />
    </outbound>
    <on-error>
        <base />
    </on-error>
</policies>

"@

Set-AzApiManagementPolicy -Context $apiContext -ApiId $api.ApiId `
    -OperationId $operation.OperationId -Policy $policy;

```

### Get Key

```powershell
$key = $apiContext |
  Get-AzApiManagementSubscription |
  Get-AzApiManagementSubscriptionKey -Context $apiContext |
    Select-Object -ExpandProperty PrimaryKey;

```

### Get URL

```powershell

$url = "$($apiMService.RuntimeUrl)/$($api.Path)$($operation.UrlTemplate)";
$url;

```


### Call

```powershell

$finalUrl = $url.Replace("{zipcode}",6000);

Invoke-WebRequest -Uri $finalUrl -Method Get -Headers @{$apiKeyName = $key} |
    select-object -expandProperty Content;


```

### Clean up

```powershell
$rg | Remove-AzResourceGroup -Force

```

[Back to top](#table-of-content)
