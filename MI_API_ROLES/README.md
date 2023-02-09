### Role to Managed Identity
#### Install

```powershell

install-module Microsoft.Graph -Force

```

### Get the API Application and SP

```powershell

$objectId = "3d4fd337-51ee-4195-bd24-1761efb90ea1";
$apiApp = Get-MgApplication -ApplicationId $objectId;
$apiApp;

$apiSP = Get-Mgserviceprincipal -All `
	-Filter "AppId eq '$($apiApp.AppId)'";

$apiApp;
$apiSP;

```

### Get the API Roles

```powershell

$apiApp.AppRoles;

### Get the API Role Id

$apiRoleId = $apiApp.AppRoles | 
	Out-GridView -PassThru | 
	Select-Object -ExpandProperty Id
;

```
### Get the Managed Identity Id (SP)

```powershell

$displayName = "win11";
$spId = Get-Mgserviceprincipal -All -Filter "DisplayName eq '$displayName'" | Select-Object -ExpandProperty Id
$spId;

```

### Get the MI (SP) API Roles
Get-MgServicePrincipalAppRoleAssignment -ServicePrincipalId $spId


### Set the API Role on the MI (SP)!!

New-MgServicePrincipalAppRoleAssignment -ServicePrincipalId $spId `
	-PrincipalId $spId `
	-AppRoleId $apiRoleId `
	-ResourceId $apiSp.Id
;
