## Service Bus Queue vs Storage Account Queue

Service Bus
- more expensive
- "at least once delivery" 
- Queue Size -> 1-4 GB
- Message Size -> 256KB (100 MB Premium)
- EnqueueTime (should not appear before 20 min.)
- Sessions
- Duplicate Detection
- Partitions (high load)  !!!! (For very high volumes look into Azure Event Hub)


Storage Account
- cheaper
- "at most once delivery"
- Queue Size -> TB
- Message Size -> 75KB



### Service Bus Structure

- Service Bus Namespace (Azure Resource)
   - Queue
   - Queue
   - Topics
   - Topics

- Edition
   - Basic!! (Non-prod) (no topics)
   - Standard (10$)
   - Premium (700$)