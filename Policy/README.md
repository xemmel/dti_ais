### Policies

#### Create Resource Group

$rg = New-AzResourceGroup -Name "rg-policy-test" -Location westeurope

#### Get Policy Defintion

$policy = Get-AzPolicyDefinition | 
	Where-Object {$_.Properties.DisplayName -eq 'Allowed Locations'}
;

#### Assignment Policy to RG

New-AzPolicyAssignment `
	-Name "allowedonrg" `
	-DisplayName "Allowed On Rg" `
	-PolicyDefinition $policy `
	-Scope $rg.ResourceId `
	-PolicyParameterObject @{"listOfAllowedLocations" = @("westeurope","northeurope")}
;

#### Check that you cannot create 

az storage account create -g $rg.ResourceGroupName -n fdf34343439 -l eastus;

az storage account create -g $rg.ResourceGroupName -n fdf343434394 -l eastus;

New-AzStorageAccount -ResourceGroupName $rg.ResourceGroupName `
	-Name stlockdown44332 `
	-SkuName Standard_LRS `
	-Location eastus
;


#### Remove RG

$rg | Remove-AzResourceGroup -Force -AsJob;