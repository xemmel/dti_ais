Clear-Host;
$apiAppSpId = "cba31fc4-3eed-405b-82df-046b923b8086";
$roleId = "089cf761-1d51-4e61-9f31-c4f7a1e9ebd9";
$appSpId = "0caf9c7d-966a-409e-a806-d386c18d07bb";

New-MgServicePrincipalAppRoleAssignment `
    -ServicePrincipalId $appSpId `
	-PrincipalId $appSpId `
	-AppRoleId $roleId `
	-ResourceId $apiAppSpId
;