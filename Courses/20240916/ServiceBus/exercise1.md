- Create a Service Bus Namespace with a new Resource Group
- STANDARD!!!!

- Create

- Inside the newly created SB Namespace
  - Entities/Queues
  - + Queue
     - Give the queue a name
     - Create
     - Inside the queue
        - Service Bus explorer
          - Send a couple of messages
          - Back to overview
          - Verify "Message Count"
          
          - Service Bus Explorer
             - Peek mode change to "Receive Mode"
             - Receive Messages
             - Receive And Deleted selected
             - Receive (one message at a time)
          - Overview -> Verify that the message count has been decreased
- Topics
   - Inside the SB Namespace
      - Entities/Topics
        - + Topic
        - name
        - Create
      - Inside the topic
        - + subscription   (subscription1)
         - Service Bus explorer
           - Send a message
        - In overview verify that subscription1 now have a message (1=1)
      - Create another subscription (dk)
      - Inside the subscription, scroll down to "Filter"
      - Add filter (country = 'DK')

      - submit another message
      - verify that the new subscription DO NOT get a message
      - submit another message (Key: country, Type: string, Value: DK)
      - verify that the new subscription DO get a message



    