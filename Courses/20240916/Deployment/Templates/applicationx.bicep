param appName string
param env string
param location string = resourceGroup().location


//Create Log Analytics workspace
var workspaceName = 'log-${appName}-${env}'
module workspace 'Common/LogAnalyticWorkspace.bicep' = {
  name: 'workspace'
  params: {
    location: location
    workspaceName: workspaceName
  }
}

//Create application Insight
var appInsightName = 'appi-${appName}-${env}'
module appInsight 'Common/applicationInsight.bicep' = {
  name: 'appInsight'
  params: {
    location: location
    appInsightName: appInsightName
    workspaceId: workspace.outputs.id
  }
}
