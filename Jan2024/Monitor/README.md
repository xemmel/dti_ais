    log.LogInformation("C# HTTP trigger function processed a request.");
    string numberString = req.Query["number"];
    log.LogInformation($"The number entered is {numberString}");
    int number = int.Parse(numberString);
    string responseMessage = $"The number: {number} squared is {number * number}";
            return new OkObjectResult(responseMessage);



    
AppRequests
| where TimeGenerated > ago(1h)
| project TimeGenerated, Name, Success
| order by TimeGenerated desc



AppRequests
| where Name == 'Calculator'
| summarize count() by tostring(Success)
| render piechart 


AppRequests
| where Name == 'Calculator'
| summarize count() by bin(TimeGenerated,2m), tostring(Success)
| render barchart




AppTraces
| where OperationId == '66d8abd1f688072ab98b475f6b1d5b4b'


AppExceptions
| where OperationId == '66d8abd1f688072ab98b475f6b1d5b4b'

