mkdir C:\SAIG.PS.WorkingDirectory\SAIG.PS.QVAS




powershell -Command "& {Import-Module .\psake.psm1; Invoke-psake .\default.ps1 IntegrationTest }"

pause