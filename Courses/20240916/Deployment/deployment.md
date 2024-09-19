### Management Plane

- One REST endpoint (https://management.azure.com/)
- Always JSON
- Multi tenant

- https://management.azure.com/{subscriptionId}      HEADER: token (tenantId)
   - Portal
   - Azure CLI /Powershell
   - Rest HTTP
   - C# SDK (Management Azure)



   ### Raw HTTP Calls (Create Storage Account)

   PUT https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}?api-version=2023-05-01


{
  "sku": {
    "name": "Premium_LRS"
  },
  "kind": "BlockBlobStorage",
  "location": "eastus",
  "properties": {
    "isHnsEnabled": true,
    "isNfsV3Enabled": true,
    "enableExtendedGroups": true,
    "supportsHttpsTrafficOnly": false,
    "networkAcls": {
      "bypass": "AzureServices",
      "defaultAction": "Allow",
      "ipRules": [],
      "virtualNetworkRules": [
        {
          "id": "/subscriptions/{subscription-id}/resourceGroups/res9101/providers/Microsoft.Network/virtualNetworks/net123/subnets/subnet12"
        }
      ]
    }
  }
}



### Deploy Storage Account ARM Template

```powershell

\Courses\20240916\Deployment>

$rgName = "rg-ais-init-deployment"

az group create --name $rgName --location germanywestcentral;

az deployment group create --resource-group $rgName --template-file .\Templates\storageaccount.json


```

### Deploy bicep

```powershell

az deployment group create --resource-group $rgName --template-file .\Templates\genericStorageAccount.bicep

```

### Deploy to env. using Param files

```powershell
$env = "Prod";
$rgName = "rg-ais-init-deploy-${env}";

az group create --name $rgName --location germanywestcentral;

az deployment group create --resource-group $rgName --template-file .\Templates\genericStorageAccount.bicep --parameters ".\Parameters\${env}\storageAccount.json"

```

### exercise

```powershell

git clone https://github.com/xemmel/dti_ais.git

cd .\Courses\20240916\Deployment\




```

Use *Deploy to env. using Param files* try with both **Test** and **Prod**




### Deploy monitoring (workspace, app insight)

```powershell

$rgName = "rg-ais-mlc-deploy-appx-test"

az group create --name $rgName --location germanywestcentral





```

### remove resource groups 

```powershell

az group list -o json | ConvertFrom-Json | Out-GridView -PassThru | ForEach-Object {az group delete --name $_.name --yes --no-wait}

```