# AzureSamples

Messaging:
Queue App:
1. Add connection string
2. Add below package
    dotnet add package WindowsAzure.Storage
    
Service Bus - All projects:
1. Add connectionstring
2. Add below package
 dotnet add package Microsoft.Azure.ServiceBus

Relay: --> All projects
1. Add connectionstring
2. Add below package
dotnet add package Microsoft.Azure.Relay

Sender: Cloud application which needs to communicate to onpremise application
listener: Onpremise service which is modified with Azure Relay listener
