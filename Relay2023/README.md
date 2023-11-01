### Get token

```powershell
az account get-access-token --resource https://relay.azure.net/ | ConvertFrom-Json | Select-Object -ExpandProperty accessToken | Set-Clipboard



```


dotnet new console -o programname