# Third-party notices

Every tool below ships inside the installer and the repository, under
`Superiorly.PostInstall/Assets/Bundle/`, laid out to mirror the installed paths
so the app's own probes resolve it. `.nip` profiles ship as embedded resources.

## Redistributed under a permissive license

- **NSudo 8.2** (`Tools/nsudo/`) — MIT, (c) M2-Team and Contributors.
  Vendor archive ships its own `License.txt`, reproduced in place.
  https://github.com/M2TeamArchived/NSudo
- **NVIDIA Profile Inspector** (`Tools/npi/nvidiaProfileInspector.exe`) — MIT,
  (c) 2016 Orbmu2k. https://github.com/Orbmu2k/nvidiaProfileInspector
- **Intel PresentMon 1.7.0** (`Tools/pmt/PresentMon/`) — MIT,
  (c) Intel Corporation. https://github.com/intel/presentmon
- **OxyPlot** (`Tools/pmt/OxyPlot*.dll`) — MIT, (c) Philip Forester / oxyplot.
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

These vendors publish free binaries but do not grant redistribution rights.
They are included at the repository owner's decision so the app works without
any download; the original publisher and its terms are listed for provenance.

- **FilterKeys Setter** (`Tools/fks/FilterKeysSetter.exe`, 167,936 bytes,
  sha256 `08594a3eddff07d2…`) — GeekHack. Its EULA lists "redistribute" among
  the prohibited actions. https://filterkeyssetter.com/eula/
- **MoreClockTool** (`Tools/mct/MoreClockTool.exe`, 4,151,808 bytes,
  sha256 `e53ea20304d03822…`) — Hellm via igor'sLAB, which prohibits digital
  redistribution and asks that only the product page be linked.
  https://www.igorslab.de
- **MorePowerTool** (`Tools/mpt/MorePowerTool.exe`, 4,961,792 bytes,
  sha256 `8f0ed1d0f52d0d75…`) — Hellm via igor'sLAB, same terms.
  https://www.igorslab.de
- **RadeonMod** (`Tools/rm/RadeonMod.exe`, 1,238,135 bytes,
  sha256 `59e5664417cc7822…`) — Guru3D freeware, password-protected archive,
  no redistribution terms published. https://www.guru3d.com
- **Performance Measurement Tool** (`Tools/pmt/`) — Vladimir Antonov, obtained
  as the community archive `PerformanceMeasurementTool_Danske101.zip`; no
  redistribution terms published.

These five require AMD Adrenalin or simply fail on unsupported hardware; the
app explains the requirement before launching rather than letting the tool
crash.

## Installed from the vendor, never bundled

- **Display Driver Uninstaller** — Wagnardsoft permits distribution only
  through wagnardsoft.com. The card installs it with
  `winget install --id Wagnardsoft.DisplayDriverUninstaller`, whose manifest
  resolves to the vendor and pins the hash. A copy dropped into `Tools\ddu` is
  detected too. https://www.wagnardsoft.com
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
