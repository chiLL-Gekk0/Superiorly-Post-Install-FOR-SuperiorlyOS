# Superiorly Post-Install

Free and open-source Windows post-install helper (MIT). Browsers, tools, tweaks,
telemetry switches and vendor debloat cards — everything runs locally on your PC
from a plaintext JSON catalog (`data/actions.json`) you can read and audit.

## Build

Requires .NET 8 SDK and Inno Setup 6 (for the installer only).
Clone with submodules: `git clone --recursive <url>` (or `git submodule update --init` in an existing clone) — `Superiorly.PostInstall/Assets/Bundle` (tools, NIP profiles, AMD utils) lives in its own repo.

```powershell
dotnet build Superiorly.PostInstall/Superiorly.PostInstall.csproj   # fast check
.\dist.build.ps1                                                     # publish + installer
```

The installer packages the publish output plus the bundled `Assets/Bundle/Tools/` and
`Assets/Bundle/Nvidia Profiles/` folders straight into
`Superiorly.PostInstall-Setup-<CalVer>.exe` (CalVer `yyyy.M.d.HHmm`, UTC).

## Notes

- The app runs **elevated** (admin manifest): it writes policies, services and
  scheduled tasks. Every command is visible in `data/actions.json` — audit it.
- Third-party tools are either bundled under their own licenses or downloaded
  from their official vendors at click time. See `THIRD-PARTY-NOTICES.md`.
- Releases live at `github.com/chiLL-Gekk0/Superiorly-Post-Install-FOR-SuperiorlyOS`; the updater
  checks `releases/latest` for `Superiorly.PostInstall-Setup-*.exe`.

## License

MIT — see `LICENSE`.
