targetScope = 'resourceGroup'

param logAnalyticsName string
param location string = resourceGroup().location




resource loganalytics 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: logAnalyticsName
  location: location
}

output id string = loganalytics.id
output customerId string = loganalytics.properties.customerId
