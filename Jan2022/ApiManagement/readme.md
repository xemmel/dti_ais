## Api Management


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


### Call: 

https://[apiServiceName].azure-api.net/zipcodes/getcity/7200

header: api-key [key]