
az login --use-device-code;


$rgName = "rg-ffffffffff";
$location = "westeurope";

az group create --name $rgName --location $location;


az deployment group create `
    --resource-group $rgName `
    --template-file .\Templates\infrastructure.bicep `
    --parameters appName=the204apptekno `
    --parameters env=test