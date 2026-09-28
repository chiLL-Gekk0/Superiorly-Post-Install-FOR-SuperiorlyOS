<# dist.build.ps1 — publish + Inno Setup installer (single x86 binary, MIT open source).
   Catalog ships as plaintext JSON (no encryption, no seal). Usage:
   .\dist.build.ps1 [-Fast]
   -Fast       inner loop: R2R off, conditional restore, prebuilt tools (~2-4x faster) #>
param(
    [switch]$Fast
)
$ErrorActionPreference = "Stop"
$root = $PSScriptRoot
$proj = "$root/Superiorly.PostInstall/Superiorly.PostInstall.csproj"
$pub = "$root/Superiorly.PostInstall/bin/Release/net8.0-windows/win-x86/publish"

# 0. Pin CalVer once (csproj CalVerVersion would tick mid-run -> version drift).
$CalVer = (Get-Date).ToUniversalTime().ToString("yyyy.M.d.HHmm")
$useR2R = (-not $Fast)
Write-Output "CalVer=$CalVer R2R=$useR2R"

# 0b. Bundle submodule must be checked out (Content/CopyAmdTools need the files).
if (-not (Test-Path -LiteralPath "$root/Superiorly.PostInstall/Assets/Bundle/Tools/NSudo_8.2_All_Components.zip")) { throw "bundle assets missing: run git submodule update --init" }
# 1. Preflight: kill running app with retry (fixed Sleep 3 in publish.ps1 is racy).
foreach ($i in 1..5) {
    $p = Get-Process -Name "Superiorly.PostInstall" -ErrorAction SilentlyContinue
    if (-not $p) { break }
    $p | Stop-Process -Force -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 2
}
if (Get-Process -Name "Superiorly.PostInstall" -ErrorAction SilentlyContinue) { throw "app still running, aborting" }

# 2. Conditional restore (project.assets.json newer than inputs -> skip). R2R needs the flag at restore (NETSDK1094).
$assets = "$root/Superiorly.PostInstall/obj/project.assets.json"
$stale = $true
if ((Test-Path -LiteralPath $assets) -and (Test-Path -LiteralPath $proj)) {
    $a = (Get-Item -LiteralPath $assets).LastWriteTimeUtc
    $newest = Get-ChildItem -LiteralPath "$root/Superiorly.PostInstall" -Filter "*.csproj" -Recurse | ForEach-Object { $_.LastWriteTimeUtc } | Sort-Object -Descending | Select-Object -First 1
    $raw = Get-Content -LiteralPath $assets -Raw
    $stale = ($newest -gt $a) -or ($raw -notmatch "net8\.0-windows/win-x86")
}
if ($stale) {
    $rr = @()
    if ($useR2R) { $rr += "/p:PublishReadyToRun=true" }
    & dotnet restore $proj @rr --nologo -v q
    if ($LASTEXITCODE -ne 0) { throw "restore failed" }
}
$restoreArgs = @()
if (-not $stale) { $restoreArgs += "--no-restore" }
$r2rArgs = @()
if ($useR2R) { $r2rArgs += "/p:PublishReadyToRun=true" }

# 3. Publish with pinned version (global /p: wins over CalVerVersion target).
& dotnet publish $proj -c Release -r win-x86 --nologo -v q @restoreArgs @r2rArgs /p:CalVer=$CalVer /p:Version=$CalVer /p:AssemblyVersion=$CalVer /p:FileVersion=$CalVer /p:InformationalVersion=$CalVer
if ($LASTEXITCODE -ne 0) { throw "publish failed" }

# 4. Version stamp (publish output is the single source of truth; no dist/ copy anymore).
$pubVer = (Get-Item -LiteralPath "$pub/Superiorly Post-Install.exe").VersionInfo.FileVersion
if ([string]::IsNullOrEmpty($pubVer)) { throw "no version stamped" }
$CalVer = $pubVer
Write-Output "OK version=$pubVer"

# 5. Installer (Inno Setup; packages $pub straight into the Setup exe).
$iscc = $null
foreach ($hive in @("HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", "HKLM:\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall")) {
    $k = Get-ChildItem -LiteralPath $hive -ErrorAction SilentlyContinue | ForEach-Object { Get-ItemProperty $_.PSPath -ErrorAction SilentlyContinue } | Where-Object { $_.DisplayName -match "^Inno Setup version 6" } | Select-Object -First 1
    if ($k -and $k.InstallLocation) { $c = Join-Path $k.InstallLocation "ISCC.exe"; if (Test-Path -LiteralPath $c) { $iscc = $c; break } }
}
if (-not $iscc) { throw "Inno Setup 6 not installed (iscc.exe missing)" }
    $outDir = $root
    if (-not (Test-Path -LiteralPath $outDir)) { New-Item -ItemType Directory -Path $outDir | Out-Null }
& $iscc "/DMyAppVersion=$CalVer" "/DDistDir=$pub" "/DOutDir=$outDir" "$root/installer/setup.iss"
if ($LASTEXITCODE -ne 0) { throw "iscc failed" }
$setup = Join-Path $outDir "Superiorly.PostInstall-Setup-$CalVer.exe"
if (-not (Test-Path -LiteralPath $setup)) { throw "installer output missing" }
$sha = (Get-FileHash -LiteralPath $setup -Algorithm SHA256).Hash.ToLowerInvariant()
$size = (Get-Item -LiteralPath $setup).Length
Write-Output "installer: $setup"
Write-Output "installer-sha256: $sha"
Write-Output "installer-size: $size"
