targetScope = 'resourceGroup'

param appName string
param location string = resourceGroup().location
param env string

//Log Analytics Workspace

//Name: log-[appName]-[Env]
var workspaceName = 'log-${appName}-${env}'
module workspace 'logAnalyticsWorkspace.bicep' = {
  name: 'workspace'
  params: {
    location: location
    workspaceName: workspaceName
  }
}


//App Insight
var appInsightname = 'appi-${appName}-${env}'
module appInsight 'appInsight.bicep' = {
  name: 'appInsight'
  params: {
    appInsightName: appInsightname
    location: location
    workspaceId: workspace.outputs.id
  }
}
