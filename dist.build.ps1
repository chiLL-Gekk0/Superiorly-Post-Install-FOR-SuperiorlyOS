<# publish + installer, single x86 binary; catalog is plaintext json; -fast skips r2r and restore for inner loop #>
param(
    [switch]$Fast
)
$ErrorActionPreference = "Stop"
$root = $PSScriptRoot
$proj = "$root/Superiorly.PostInstall/Superiorly.PostInstall.csproj"
$pub = "$root/Superiorly.PostInstall/bin/Release/net8.0-windows/win-x86/publish"

# pin calver once, reticking mid-run drifts version
$CalVer = (Get-Date).ToUniversalTime().ToString("yyyy.M.d.HHmm")
$useR2R = (-not $Fast)
Write-Output "CalVer=$CalVer R2R=$useR2R"

# kill running app with retry, single sleep is racy
foreach ($i in 1..5) {
    $p = Get-Process -Name "Superiorly.PostInstall" -ErrorAction SilentlyContinue
    if (-not $p) { break }
    $p | Stop-Process -Force -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 2
}
if (Get-Process -Name "Superiorly.PostInstall" -ErrorAction SilentlyContinue) { throw "app still running, aborting" }

# skip restore when assets are fresh; r2r flag required at restore
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

# publish with pinned version, command line wins over target
& dotnet publish $proj -c Release -r win-x86 --nologo -v q @restoreArgs @r2rArgs /p:CalVer=$CalVer /p:Version=$CalVer /p:AssemblyVersion=$CalVer /p:FileVersion=$CalVer /p:InformationalVersion=$CalVer
if ($LASTEXITCODE -ne 0) { throw "publish failed" }

# reread version from publish output, single source of truth
$pubVer = (Get-Item -LiteralPath "$pub/Superiorly Post-Install.exe").VersionInfo.FileVersion
if ([string]::IsNullOrEmpty($pubVer)) { throw "no version stamped" }
$CalVer = $pubVer
Write-Output "OK version=$pubVer"

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
