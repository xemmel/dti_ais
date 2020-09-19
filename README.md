# AIS COURSE
## Morten la Cour



## Table of Content
1. [Prequisites](#prequisites)
2. [Logic Apps](#logic-apps)






## Prequisites

### Install Chocolatey

> In Powershell
```powershell

Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

```
> Powershell might need to be reopened

### Install Powershell AZ

```powershell
choco install az.powershell -y

```

### Logon to Azure in Powershell

```powershell
Connect-AzAccount
```

[Back to top](#table-of-content)


## Logic Apps



[Back to top](#table-of-content)