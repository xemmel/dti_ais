    log.LogInformation("C# HTTP trigger function processed a request.");
    string numberString = req.Query["number"];
    log.LogInformation($"The number entered is {numberString}");
    int number = int.Parse(numberString);
    string responseMessage = $"The number: {number} squared is {number * number}";
            return new OkObjectResult(responseMessage);