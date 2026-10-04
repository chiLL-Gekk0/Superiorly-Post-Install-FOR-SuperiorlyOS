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

## Third-party tools

The installer bundles these free tools so their cards work offline; each card
links its vendor. Full hashes and terms in `THIRD-PARTY-NOTICES.md`.

| Tool | Author | License |
|---|---|---|
| NSudo 8.2 | M2-Team and Contributors | MIT — https://github.com/M2TeamArchived/NSudo |
| NVIDIA Profile Inspector | Orbmu2k (2016) | MIT — https://github.com/Orbmu2k/nvidiaProfileInspector |
| PresentMon 1.7.0, OxyPlot | Intel Corporation, Philip Forester | MIT — https://github.com/intel/presentmon |
| Radeon Software Slimmer 1.12.0 | GSDragoon | GPL-3.0 — https://github.com/GSDragoon/RadeonSoftwareSlimmer |
| FilterKeys Setter | GeekHack | EULA — https://filterkeyssetter.com/eula/ |
| MoreClockTool, MorePowerTool | Hellm via igor'sLAB | Freeware, redistribution restricted — https://www.igorslab.de |
| RadeonMod | Guru3D | Freeware — https://www.guru3d.com |
| Display Driver Uninstaller | Wagnardsoft | Freeware, distribution via wagnardsoft.com only — https://www.wagnardsoft.com |
| Performance Measurement Tool | Vladimir Antonov (community archive) | Freeware |
| Custom Resolution Utility (not bundled) | ToastyX | Open source — https://www.monitortests.com/forum/Thread-Custom-Resolution-Utility-CRU |

## Notes

- The app runs **elevated** (admin manifest): it writes policies, services and
  scheduled tasks. Every command is visible in `Data/actions.json` — audit it.
- Third-party tools are either bundled under their own licenses or downloaded
  from their official vendors at click time. See `THIRD-PARTY-NOTICES.md`.
- Releases live at `github.com/chiLL-Gekk0/Superiorly-Post-Install-FOR-SuperiorlyOS`; the updater
  checks `releases/latest` for `Superiorly.PostInstall-Setup-*.exe`.

## License

MIT — see `LICENSE`.
