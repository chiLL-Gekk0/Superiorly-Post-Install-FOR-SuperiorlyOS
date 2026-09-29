param()
$ErrorActionPreference = "Stop"
$root = $PSScriptRoot
$proj = "$root/Superiorly.PostInstall/Superiorly.PostInstall.csproj"
$pub = "$root/Superiorly.PostInstall/bin/Release/net8.0-windows/win-x86/publish"

dotnet publish $proj -c Release -r win-x86 --nologo -v q /p:Version=$((Get-Date).ToUniversalTime().ToString("yyyy.M.d.HHmm"))
if ($LASTEXITCODE -ne 0) { throw "publish failed" }
Write-Output "verify: publish OK"
