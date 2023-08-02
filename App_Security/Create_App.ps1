## Connect via MG

```powershell

connect-MgGraph;

```

### Create App Registration (and SP)

```powershell

$appName = "dtiaisapp"

$app = New-MgApplication -DisplayName $appName;
$sp = New-MgServicePrincipal -DisplayName $appName -AppId $app.AppId;

#### Create secret

### Add a Secret
$passwordCred = @{
    displayName = 'appsecret'
    endDateTime = (Get-Date).AddMonths(3)
 }
 
 $secret = Add-MgApplicationPassword `
    -applicationId $app.Id `
    -PasswordCredential $passwordCred
;

$app = Get-MgApplication -ApplicationId $app.Id;

```


### Cleanup

```powershell

Remove-MgServicePrincipal -ServicePrincipalId $sp.Id;
Remove-MgApplication -ApplicationId $app.Id;


```