## Exercise


1. Create a new Function App in the Portal (new Resource Group, new StorageAccount, new AppInsight) (should happen automatically)

2. Create a new Function (Http Trigger)
3. Get the Trigger URL -> Functions -> Function -> Get Function Url
4. Call the Function (Invoke-webrequest URL)

5. In the Function App Storage Account (The Storage Account in the same resource group as the FunctionApp) Create two new queues (input and output)

6. Create a new Function use the "Azure Queue storage trigger"   queue Name = input   name = process

7. Publish a message to the input message queue and verify that the message is "picked up" by the function