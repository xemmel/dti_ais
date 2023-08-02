### $app and $secret must be set
Clear-Host;

$scope = "https://management.azure.com";

$tenantId = (Get-MgContext).TenantId;
$clientId = $app.AppId;
$clientSecret = $secret.SecretText;
$scopes = "$($scope)/.default";


$url = "https://login.microsoftonline.com/$($tenantId)/oauth2/v2.0/token";

$body = "grant_type=client_credentials";
$body += "&client_id=$($clientId)";
$body += "&client_secret=$($clientSecret)";
$body += "&scope=$($scopes)";



$response = $null;
$response = Invoke-WebRequest `
    -Method Post `
    -Uri $url `
    -Body $body
;
$token = $response.Content |
        ConvertFrom-Json |
        Select-Object -ExpandProperty access_token
    ;
$token | Set-Clipboard;
$token;