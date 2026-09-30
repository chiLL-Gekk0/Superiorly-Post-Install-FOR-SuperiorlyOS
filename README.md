# Superiorly Post-Install

Free and open-source Windows post-install helper (MIT). Browsers, tools, tweaks,
telemetry switches and vendor debloat cards — everything runs locally on your PC
from a plaintext JSON catalog (`Data/actions.json`) you can read and audit.

## Build

Requires .NET 8 SDK to build. End users just run the installer
(Inno Setup is only needed to build it).

```powershell
dotnet build Superiorly.PostInstall/Superiorly.PostInstall.csproj   # fast check
.\dist.build.ps1                                                     # publish + installer
```

The installer packages the publish output straight into
`Superiorly.PostInstall-Setup-<CalVer>.exe` (CalVer `yyyy.M.d.HHmm`, UTC).
Tools ship with the installer or download on demand from their official vendors
(NSudo also tries GitHub releases first); all downloads are SHA256-checked.

## Notes

- The app runs **elevated** (admin manifest): it writes policies, services and
  scheduled tasks. Every command is visible in `Data/actions.json` — audit it.
- Third-party tools are either bundled under their own licenses or downloaded
  from their official vendors at click time. See `THIRD-PARTY-NOTICES.md`.
- Releases live at `github.com/chiLL-Gekk0/Superiorly-Post-Install-FOR-SuperiorlyOS`; the updater
  checks `releases/latest` for `Superiorly.PostInstall-Setup-*.exe`.

## License

MIT — see `LICENSE`.
