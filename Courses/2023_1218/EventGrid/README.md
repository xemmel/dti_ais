- Existing Storage Account
  - Container: upload

```powershell

az login --use-device-code

az account show

az storage blob upload --container-name **upload2** --file **c:\temp\order.txt** *--account-name **dgidemo012024** --overwrite

```

- Create New Logic App / **Consumption** (Http Trigger) (Stay as POST)   
- Or Requestbin (manual validation)

- Storage Account
  - Events
    - New Subscription
    - Type: WebHook -> Paste URL

- Upload file -> RB/Logic app run


