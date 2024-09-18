## Azure Powershell / Azure CLI

```powershell

## Powershell

Get-AzResourceGroup

## CLI

az group list -o table


```


### Create Resource Group

```powershell
$rgName = "rg-ais-init-scripttest";

az group create --name $rgName --location germanywestcentral;

```

### Create Storage Account

```powershell

az storage account create --name stuniquename --resource-group $rgName




```