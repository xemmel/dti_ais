targetScope = 'resourceGroup'

param appName string
param env string
param location string = resourceGroup().location

//Log Analytics Workspace
var laName = 'log-${appName}-${env}'

resource workspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: laName
  location: location
}

//Application Insight
var aiName = 'appi-${appName}-${env}'
var aiKind = 'web'
resource ai 'Microsoft.Insights/components@2020-02-02' = {
  name: aiName
  location: location
  kind: aiKind
  properties: {
    Application_Type: aiKind
    WorkspaceResourceId: workspace.id
  }
}

