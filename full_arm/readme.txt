$rgName = "rg-yourrgname";

az group create --name $rgName --location westeurope;

az deployment group create --resource-group $rgName --template-file .\Templates\storageAccount.json --parameters .\Parameters\Test\storageaccount.json


git clone https://github.com/xemmel/dti_ais.git