### Upload a blob using Azure CLI

```powershell

az storage blob upload `
    --account-name aismlc `
    --container-name myprivatecontainer `
    --file c:\temp\test3.txt `
    --overwrite
;


```