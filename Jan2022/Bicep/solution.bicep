targetScope = 'resourceGroup'

param appName string
param env string


// Log Analytics
var logAnalyticsName = 'log-${appName}-${env}'
module logana 'LogAnalytics.bicep' = {
  name: 'logana'
  params: {
    logAnalyticsName: logAnalyticsName
  }
}

//Logic App
var logicAppName = 'logic-${appName}'

module logicapp 'logicapp.bicep' = {
  name: 'logicapp'
  dependsOn: [
    logana
  ]
  params: {
    logicAppName: logicAppName
    logAnalyticsId: logana.outputs.id
  }
}
