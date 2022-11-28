targetScope = 'resourceGroup'

param storageAccountName string
param location string = 'westeurope'
param sku string

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_GRS'
  }
  kind: 'StorageV2'
}


