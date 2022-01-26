1. Create a new queue in Service Bus
2. Submit a message to the queue

3. Create a new Logic App
4. Enable Managed Identity on the Logic App (Identity)

5. Select the "receive from service bus queue" trigger. 
5.5 Select new Connection
6. Select Managed Identity
7. Give it a name and write "sb://[hosturl for the servicebus] in the connection

8. Try to select a queue (you can't access it and will get an "unauthorized")

9. Goto the Service Bus Namespace and choose (IAM)
10. Select Role Assignments -> +Add -> Add Role Assignment
11. Choose "Azure Service Bus Data Receiver"
12. Next
13. Managed Identity
14. Select Members
15. Choose your logic app
16. Choose Select
17. "Review + Assign"

18. Now try to assess the queues in the Logic App Again, everything should work now



