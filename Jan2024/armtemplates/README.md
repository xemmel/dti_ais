$rgName = "solar-armdemo-init-rg"


az group create --name $rgName --location westeurope

az deployment group create --resource-group $rgName --template-file .\Templates\storageaccount.json


## Use Parameter Files

$env = "Test";

### In parameter files change storage names initials


az deployment group create --resource-group $rgName --template-file .\Templates\storageaccount.json  --parameters .\Parameters\$env\storageaccount.json 

(--what-if)



### Bicep
az deployment group create --resource-group $rgName --template-file .\BicepTemplates\storageAccount.bicep --parameters .\Parameters\Prod\storageAccount.bicepparam

