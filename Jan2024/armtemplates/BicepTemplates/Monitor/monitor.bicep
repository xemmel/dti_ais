targetScope = 'resourceGroup'

param appName string
param env string
param location string = resourceGroup().location


//Create LA Workspace
var workspaceName = '${appName}-${env}-log'
module workspace 'LogAnalyticsWorkspace.bicep' = {
  name: 'workspace'
  params: {
    location: location
    workspaceName: workspaceName
  }
}

//Create Application Insight
var insightName = '${appName}-${env}-appi'
var workid = workspace.outputs.id
module appInsight 'ApplicationInsight.bicep' = {
  dependsOn: [
    workspace
  ]
  name: 'appInsight'
  params: {
    appInsightName: insightName 
    location: location
    workspaceId: workid
  }
}


