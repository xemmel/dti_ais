targetScope = 'resourceGroup'


param appName string
param environment string
param location string = resourceGroup().location



module monitor 'monitor.bicep' = {
  name: 'monitor'
  params: {
    appName: appName
    environment: environment
    location: location
  }
}
