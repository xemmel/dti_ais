```powershell

$rgName = "dgi-armdemo-**init**-rg"

az group create --name $rgName --location westeurope

$env = "Test";

az deployment group create --resource-group $rgName --template-file .\Template\storageaccount.json --parameters .\Parameters\$env\storageaccount.json

```