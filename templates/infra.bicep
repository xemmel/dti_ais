targetScope = 'resourceGroup'

param appName string
param env string
param location string = resourceGroup().location

//Log Analytics Workspace
var laName = 'log-${appName}-${env}'

module workspace 'laWorkspace.bicep' = {
  name: 'workspace'
  params: {
    laName: laName
    location: location
  }
}

//Application Insight
var aiName = 'appi-${appName}-${env}'
var aiKind = 'web'
resource ai 'Microsoft.Insights/components@2020-02-02' = {
  name: aiName
  dependsOn:[ workspace ]
  location: location
  kind: aiKind
  properties: {
    Application_Type: aiKind
    WorkspaceResourceId: workspace.outputs.workspaceId
  }
}

