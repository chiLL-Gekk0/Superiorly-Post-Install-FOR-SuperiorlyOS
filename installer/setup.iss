; x86-only binary, machine-wide install
; built by dist.build.ps1 with iscc /dmyappversion /ddistdir /doutdir
; keep appid stable, changing it orphans uninstall entries
#ifndef MyAppName
  #define MyAppName "Superiorly Post-Install"
#endif
#ifndef MyAppVersion
  #define MyAppVersion "0.0.0.0"
#endif
#ifndef DistDir
  #define DistDir "."
#endif
#ifndef OutDir
  #define OutDir "."
#endif

[Setup]
AppId={{4A5338EE-5D1B-48DA-9217-D2CC0BF6A77C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={autopf}\Superiorly Post-Install
DefaultGroupName=Superiorly Post-Install
PrivilegesRequired=admin
; 32-bit setup covers x86 and x64, arm out of scope
OutputDir={#OutDir}
OutputBaseFilename=Superiorly.PostInstall-Setup-{#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
Compression=lzma2
SolidCompression=yes
CloseApplications=yes
UninstallDisplayName={#MyAppName}
; no bundled runtime, dotnet preinstalled

[Files]
Source: "{#DistDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\Superiorly Post-Install"; Filename: "{app}\Superiorly Post-Install.exe"
Name: "{autodesktop}\Superiorly Post-Install"; Filename: "{app}\Superiorly Post-Install.exe"

[InstallDelete]
Type: files; Name: "{app}\Superiorly.PostInstall.exe"
Type: files; Name: "{app}\Superiorly.PostInstall.dll"
; folders older builds shipped next to the exe. Deleting them on install, not only on
; uninstall, matters because the catalog loader prefers a loose Data\actions.json over the
; embedded copy, so a stale one would keep driving the app after an in-place upgrade.
; Specific paths only, never an {app}\* wildcard. The per-user tool store is left alone.
Type: filesandordirs; Name: "{app}\Nvidia Profiles"
Type: filesandordirs; Name: "{app}\AMD Tweaks"
Type: filesandordirs; Name: "{app}\Tools"
Type: filesandordirs; Name: "{app}\DDU"
Type: filesandordirs; Name: "{app}\Data"

[Run]
Filename: "{app}\Superiorly Post-Install.exe"; Description: "Launch Superiorly Post-Install"; Flags: nowait postinstall

; legacy folders from builds that shipped tools or profiles next to the exe, plus the
; per-user tool store; specific paths only, never an {app}\* wildcard, which would take user files too
[UninstallDelete]
Type: filesandordirs; Name: "{app}\Nvidia Profiles"
Type: filesandordirs; Name: "{app}\AMD Tweaks"
Type: filesandordirs; Name: "{app}\Tools"
Type: filesandordirs; Name: "{app}\DDU"
Type: filesandordirs; Name: "{app}\Data"
Type: filesandordirs; Name: "{localappdata}\Superiorly"
