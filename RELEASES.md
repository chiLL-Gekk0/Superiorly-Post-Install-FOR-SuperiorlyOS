# Releases — política (Superiorly PostInstall)

1. **Nunca reemplazar ni sobrescribir un release publicado.** Si hay que corregir algo, se publica uno nuevo. Lo publicado queda intacto.
2. **Cada release nuevo se diferencia por tag CalVer**: `yyyy.M.d.HHmm` (año, mes, día, hora, minuto, UTC). El tag sale automático del pipeline (`dist.build.ps1`); **nada de versiones hardcodeadas**.
3. **Nunca crear un release si el usuario no lo pide.** Sin excepciones.
4. El asset es `Superiorly.PostInstall-Setup-<CalVer>.exe`; el updater lo localiza por ese prefijo.
