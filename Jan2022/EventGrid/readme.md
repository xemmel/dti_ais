
1. Create an Event Grid Topic
2. Get the Topic Key (Access Key -> Key1)
3. Submit an Event through Postman

[{
    "subject" : "fileCreated",
    "eventType" : "file",
    "id" : "1234565",
    "eventTime" : "2022-01-27",
}
]

Header: aeg-sas-key   [Topic Key]


4. Verify that you get a 200 OK

5. Create a new logic app with Http Trigger
6. Get the Http Trigger URL

7. Create a new subscription inside the Event Grid Topic and choose WebHook and use the logic app URL

8. Submit another event from Postman and verify that the logic app ran

