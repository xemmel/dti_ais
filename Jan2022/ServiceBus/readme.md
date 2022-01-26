1. Create a topic

2. Create a subscription (everything)

3. Submit a message to the topic

4. verify that the subscription holds a message

5. Create a new subscription (customer17) add a new filter (customerId = 'IBM')

6. submit a message again in the topic (no properties)

7. Verify that the everything sub. got a message and that customer17 did not

8. Submit a message (properties: customerId  IBM)
9. Verify that both subscriptions got a message now
