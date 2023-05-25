## Create Resource Group (...broker)

## Storage Account (...msgbox)
   Containers (Private):
   - customer1order
   - msgbox

### Upload an xml file to customer1order container

### Create new Function App
   HttpTrigger (Transform) 

### Create Logic App (Customer1_Order_Receive)
  - Timer Trigger
  - Azure Blob Storage Action (List Blobs)
  - Foreach blob
  - Compose (FileName) -> item/blobName
  - Get Content
  - Call Function (Transform -> Content as input)
  - Create new blob (msgbox container) -> Output Function
    - blobName: 
     "queries": {
                                "folderPath": "/msgbox",
                                "name": "@{guid()}.xml"
                            }
    - Delete blob from container (customer1order)
  
  lacour@gmail.com
  mlc@integration-it.com

  
  
   
 