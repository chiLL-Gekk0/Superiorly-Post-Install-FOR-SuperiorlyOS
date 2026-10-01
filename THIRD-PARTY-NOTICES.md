# Third-party notices

Every tool below ships inside the installer and this repository, under
`Superiorly.PostInstall/Assets/Bundle/`. That folder is the app root: the loose
files land next to `Superiorly Post-Install.exe`, and the three zip-backed tools
expand into `Tools/<tool>/` the first time their card runs. `.nip` profiles ship
as embedded resources.

## Redistributed under a permissive license

- **NSudo 8.2** (`NSudo_8.2_All_Components.zip`, 11,237,653 bytes,
  sha256 `346e38030cc9eeef…`) — MIT, (c) M2-Team and Contributors. The vendor
  archive ships its own `License.txt`.
  https://github.com/M2TeamArchived/NSudo
- **NVIDIA Profile Inspector** (`nvidiaProfileInspector.exe`, 1,043,968 bytes,
  sha256 `071f38bfeec4fab0…`) — MIT, (c) 2016 Orbmu2k.
  https://github.com/Orbmu2k/nvidiaProfileInspector
- **Intel PresentMon 1.7.0** and **OxyPlot**, both inside
  `PerformanceMeasurementTool_Danske101.zip` (495,369 bytes,
  sha256 `4cdf39efe1ddf26f…`) — MIT, (c) Intel Corporation and (c) Philip
  Forester. https://github.com/intel/presentmon ·
  https://github.com/oxyplot/oxyplot
- **Radeon Software Slimmer 1.12.0** (`AMD Tweaks/RadeonSoftwareSlimmer/`) —
  GPL-3.0, (c) GSDragoon. Taken verbatim from the official GitHub release
  (`RadeonSoftwareSlimmer_1.12.0_net48.zip`, sha256
  `e4f1737ca779e38bda1b776f0e5560069e54ba533a90cb4efdc48a020a3e51d4`).
  Corresponding source is published with every release.
  https://github.com/GSDragoon/RadeonSoftwareSlimmer/releases/tag/1.12.0
- **`.nip` profiles** (`Bundle/NIP/`, embedded resources) — authored for this
  project, MIT like the rest of the repo.

## Redistributed without a redistribution grant

These vendors publish free binaries but do not grant redistribution rights. They
are included at the repository owner's decision so the app works without any
download; the original publisher and its terms are listed for provenance.

- **FilterKeys Setter** (`FilterKeysSetter.exe`, 167,936 bytes,
  sha256 `08594a3e6ddf07d2…`) — GeekHack. Its EULA lists "redistribute" among
  the prohibited actions. https://filterkeyssetter.com/eula/
- **MoreClockTool** (`MoreClockTool.exe`, 4,151,808 bytes,
  sha256 `e53ea20304d03822…`) and **MorePowerTool** (`MorePowerTool.exe`,
  4,961,792 bytes, sha256 `8f0ed1d0f52d0d75…`) — Hellm via igor'sLAB, which
  prohibits digital redistribution and asks that only the product page be
  linked. https://www.igorslab.de
- **RadeonMod** (`RadeonMod.exe`, 1,238,135 bytes, sha256 `59e5664417cc7822…`) —
  Guru3D freeware, password-protected archive, no redistribution terms
  published. https://www.guru3d.com
- **Display Driver Uninstaller** (`DDU_v18.1.5.3_Portable.zip`, 1,188,830 bytes,
  sha256 `fd4d43b0cae7f41d…`) — Wagnardsoft, which permits distribution only
  through wagnardsoft.com. https://www.wagnardsoft.com
- **Performance Measurement Tool** — Vladimir Antonov, obtained as the community
  archive `PerformanceMeasurementTool_Danske101.zip`; no redistribution terms
  published.

MoreClockTool and MorePowerTool need AMD Adrenalin (they talk to ADLX), so the
card explains that requirement before launching instead of letting the tool
crash on unsupported hardware.

## Not bundled

- **Custom Resolution Utility (CRU)** — ToastyX, open source, fetched at click
  time. https://www.monitortests.com/forum/Thread-Custom-Resolution-Utility-CRU

## Branding

- UI brand icons (`Assets/Logos/*.png`) remain the property of their owners and
  are used nominatively to identify each vendor.

## NuGet dependencies (restored at build, not shipped as source)

- **CommunityToolkit.Mvvm 8.4.0** — MIT.
  https://github.com/CommunityToolkit/dotnet
- **Microsoft.Extensions.DependencyInjection 8.0.1** — MIT.
  https://github.com/dotnet/runtime
