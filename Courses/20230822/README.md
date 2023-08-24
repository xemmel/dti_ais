

## Notepad notes

```
- Compute (With or without "software")
- Storage
- Networking



Storage Account:
      - Containers/Blobs (default)
      - Tables
      - Queues
      - Files


West Europe
LRS (Local) -> (1 datacenter, 3 disks)
GRS (geo) -> 1 datacenter, 3 disks   -> Replicated 1 disk North Europe
ZRS (Zone) -> 3 datacenter, 1 disk in each)
GZRS (GeoZone) -> 3 datacenter, 1 disk in each -> -> Replicated 1 disk North Europe


ALL AZURE RESOURCES
     public internet (https://management.azure.com/......)

      Control/Management Plane/layer  ->   (Creating, Updating, View properties, Deleting)   ARM Rest Api
---------------------------------------------
      (Data/Application Plane/layer)

Do we want internet access?


(Do we even want security)?
   Which kind of security
      - "Password" (Differ pr. Resource Type)
      - AAD (Entra) Security     :-)

az account get-access-token --resource https://management.azure.com/ 


LOGIC APP


Compose = Constant
Variables = Variables



Defintion Language (JSON)

triggers: {
"manual" : {}
}


actions: {
	"action1" : {
		"inputs" : {},
		"type" : "Compose|Response|ApiConnection",
		"runAfter" : {}	
}

}


runAfter: The first action(s) in the scope has "runAfter: {}"


runAfter: Action2 runs after Action1:

"action2" : {
	"runAfter" : {
		"action1" : [ "Succeeded" ]
	}
}



All Special syntax in Logic App starts with @

Action that needs something from a previous action:

outputs('actionName')
body('actionName')


outputs('actionName')['body'] == body('actionName')

Action that needs something from the trigger:

triggerOutputs()
triggerBody()


If the whole statement is "Special syntax"

"@outputs('fff')"

If "Special Syntax" needs to be concatinated with a string:

"This is @{outputs('ff')} and this is more"


@triggerBody()['address']['postNumber']
@triggerBody()['address']?['postNumber']?['fff']


 "schema": {
                        "additionalProperties": false,
                        "properties": {
                            "age": {
                                "type": "integer"
                            },
                            "name": {
                                "type": "string"
                            }
                        },
                        "required": [
                            "name",
                            "age"
                        ],









```