targetScope = 'resourceGroup'

param appName string
param environment string
param location string = resourceGroup().location


//Create LAW (Monitor)
var monitorName = '${appName}-${environment}-log'
resource monitor 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: monitorName
  location: location
}


//Create AppInsight

var wid = monitor.id
var appInsightName = '${appName}-${environment}-appi'
var kind = 'web'

resource appInsight 'Microsoft.Insights/components@2020-02-02' = {
  dependsOn: [
    monitor
  ]
  name: appInsightName
  location: location
  kind: kind
  properties: {
    WorkspaceResourceId: wid
    Application_Type: kind
  }
}
