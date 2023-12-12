$rgName = "solar-armdemo-init-rg"


az group create --name $rgName --location westeurope

az deployment group create --resource-group $rgName --template-file .\Templates\storageaccount.json