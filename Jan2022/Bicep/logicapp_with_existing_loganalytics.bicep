targetScope = 'resourceGroup'

param logicAppName string
param location string = resourceGroup().location

param logAnalyticsName string
param logAnalticsResourceGroup string = ''

resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2021-06-01' existing = {
  name: logAnalyticsName
}

resource logicapp 'Microsoft.Logic/workflows@2019-05-01' = {
  name: logicAppName
  location: location
  properties: {
    definition: {
      '$schema' : 'https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#'
      contentVersion: '1.0.0.0'
      actions: {
        GetRequest: {
          inputs: '@triggerBody()'
          type: 'Compose'
          runAfter: {}
        }
      }
      triggers: {
        http: {
          inputs: {
            schema: {}
          }
          type: 'Request'
          kind: 'Http'
        }
      }
    }
  }
}


//Logic App Diagnostic Settings
resource diagnosticSettings 'Microsoft.Logic/workflows/providers/diagnosticSettings@2021-05-01-preview' = {
  name: '${logicAppName}/Microsoft.Insights/diag'
  dependsOn: [ 
    logicapp 
  ]
  properties: {
    workspaceId: logAnalytics.id
    logs: [
      {
        category: 'WorkflowRuntime'
        enabled: true
      }
    ]
    metrics: [
      {
        category: 'AllMetrics'
        enabled: true
      }
    ]
  }
}
