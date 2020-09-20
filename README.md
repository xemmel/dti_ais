# AIS COURSE
## Morten la Cour



## Table of Content
1. [Prequisites](#prequisites)
2. [Logic Apps](#logic-apps)






## Prequisites

### Azure Keys
```
Student Pass Code	Validity Date
QF6QP9DYKZ0KKHJ7NR	16-12-2020
QKD5SYT91S07C3BJMQ	16-12-2020
QTLKG7194K9HK2C4MN	16-12-2020
``` 

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


