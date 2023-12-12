## Create dotnet console project

dotnet new console -o solarrelay

cd into project

dotnet add package Microsoft.Azure.Relay


Azure Portal

Relay
  Shared Access Policies
  + ADD
  Name: Listener    Listen checkbox

  Name / Primary Key

Relay Name
HybridConnection Name
UserName: Listener
Key

vs code 

code .

Copy Paste Program.cs -> Program.cs
Create Copy/Paste RequestModel.cs into project (same level as Program.cs)

Replace 4 ### 

dotnet run
  -> Online

Portal -> Hybrid Connections -> 1 listener

Postman

Body:   JSON

{
    "method" : "themethod",
    "command" : "listfiles"
}
