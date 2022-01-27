
### Logic App

```json

"actions": {
            "GetRequest": {
                "inputs": "@triggerBody()",
                "runAfter": {},
                "trackedProperties": {
                    "country": "Denmark"
                },
                "type": "Compose"
            }
        }

```


### Tracked Properties Query

```
AzureDiagnostics
| where TimeGenerated  > ago(7d)
| where status_s == 'Succeeded'
| where Resource  == 'GETREQUEST'
| project TimeGenerated, resource_workflowName_s,Resource, trackedProperties_country_s
| order by TimeGenerated desc


```