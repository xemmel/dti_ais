targetScope = 'resourceGroup'

param storageAccountName string
param sku string = 'Standard_LRS'
param location string = resourceGroup().location


var kind = 'StorageV2'


resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: sku
  }
  kind: kind
}

