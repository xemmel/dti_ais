targetScope = 'resourceGroup'

param workspaceName string
param location string


resource workspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: workspaceName
  location: location
}


output id string = workspace.id
