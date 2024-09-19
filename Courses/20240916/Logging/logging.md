### Get Requests

AppRequests
| where Name == 'Calculator'
| project TimeGenerated,Success,DurationMs,OperationId
| order by TimeGenerated desc


### Get errors only (Alert)

AppRequests
| where TimeGenerated > ago(15m)
| where Name == 'Calculator'
| where Success == false


### Show success-rate

AppRequests
| where TimeGenerated > ago(1h)
| where Name == 'Calculator'
| summarize count() by tostring(Success)
| render piechart 

### Show time-intervals

AppRequests
| where TimeGenerated > ago(1h)
| where Name == 'Calculator'
| summarize count() by bin(TimeGenerated,1m), tostring(Success)
| render barchart 

### Show specific log value in piechart

AppTraces
| extend prop__number_ = tostring(Properties.prop__number)
| where prop__number_ != ''
| summarize count() by prop__number_
| render piechart 