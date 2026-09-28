; Superiorly PostInstall — Inno Setup script (x86-only binary, machine-wide install).
; Built by dist.build.ps1 -Installer (iscc /DMyAppVersion=<CalVer> /DDistDir=<dist> /DOutDir=<out>).
; AppId is IMMUTABLE — changing it orphans Add/Remove entries and the uninstall log.
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
; ponytail: 32-bit setup default (x86compatible) covers x86+x64; ARM out of scope.
OutputDir={#OutDir}
OutputBaseFilename=Superiorly.PostInstall-Setup-{#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
Compression=lzma2
SolidCompression=yes
CloseApplications=yes
UninstallDisplayName={#MyAppName}
; ponytail: no bundled .NET (preinstalled per requirements).

[Files]
Source: "{#DistDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\Superiorly Post-Install"; Filename: "{app}\Superiorly Post-Install.exe"
Name: "{autodesktop}\Superiorly Post-Install"; Filename: "{app}\Superiorly Post-Install.exe"

[InstallDelete]
Type: files; Name: "{app}\Superiorly.PostInstall.exe"
Type: files; Name: "{app}\Superiorly.PostInstall.dll"

[Run]
Filename: "{app}\Superiorly Post-Install.exe"; Description: "Launch Superiorly Post-Install"; Flags: nowait postinstall
