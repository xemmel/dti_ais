targetScope = 'resourceGroup'

param laName string
param location string


resource workspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: laName
  location: location
}


output workspaceId string = workspace.id
