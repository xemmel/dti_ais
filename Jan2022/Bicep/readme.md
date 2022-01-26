## Deployment

```powershell

$rgName = 'whateveryouwant';

## create the resource group
az group create -n $rgName -l "westeurope";

## Deploy LogA AND a LogicApp
az deployment group create --resource-group  `
	--template-file solution.bicep `
	--parameters appName=wednesday --parameters env=stage

## Deploy a lonely Logic App and connect to an existing LogA

az deployment group create --resource-group rg-donaldduck `
--template-file logicapp_with_existing_loganalytics.bicep `
--parameters logicAppName=anotherlogicapp `
--parameters logAnalyticsName=log-wednesday-stage

## Clean up
az group delete -n $rgName --yes --no-wait


```