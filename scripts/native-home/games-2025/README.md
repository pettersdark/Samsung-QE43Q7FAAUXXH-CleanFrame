# S85F 2025 source templates / Plantillas S85F 2025

These are sanitized versions of the one-shot .NET 6 helpers used on TQ55S85FAUXXC firmware T-PTMFDEUC-0090-1301.0. They are not an installer. `YourGames1.CleanFrame` and `YourGames1` are placeholders: adapt them to your own SDK-generated identity before building. Do not widen the firmware, 32-bit or SDK-user UID 901 guards.

Versiones sin datos personales de las herramientas .NET 6 utilizadas en esta TV/firmware. No son un instalador. Los identificadores anteriores son ejemplos y deben sustituirse por la identidad propia del SDK. Conserva las protecciones de firmware, 32 bits y usuario SDK 901.

GamesHomeControl queries/saves the current Home operation and changes only that operation. GamesStartupControl uses a separate snapshot taken after Home was configured. It assigns home_appid and enables autostart; this firmware then populates startup_appid and booting_appid_backup itself. The Samsung first-screen value is preserved. An initial attempt to force all startup strings immediately was rejected by the helper because the firmware updates the backup asynchronously; the final implementation waits for settings to settle and observes the derived fields.

GamesHomeControl consulta Inicio y modifica solamente su destino. GamesStartupControl usa una copia separada posterior a configurar Inicio. Cambia home_appid y activa autostart; el firmware actualiza los otros campos de arranque. Se conserva la primera pantalla de Samsung. La implementación final espera a que se estabilicen los valores para comprobarlos.

Actions: `query`, `verify-baseline SNAPSHOT`, `apply-home SNAPSHOT` (Home helper) or `apply SNAPSHOT` (startup helper), and `restore SNAPSHOT`. Query output must be validated and stored as an immutable private baseline before any apply. The startup snapshot must record Home already pointing at your own app. Restore startup first, then Home if reverting both. Each apply requires separate owner authorization and physical confirmation.

Acciones: consulta, verificación del original, aplicación y restauración. Guarda y valida una copia privada inmutable antes de aplicar. El original de arranque debe tener Inicio apuntando ya a tu app. Restaura primero arranque y después Inicio. Cada aplicación requiere autorización del propietario y comprobación física.

Compile the chosen project with an appropriate Microsoft .NET SDK. The result is a framework-dependent .NET 6 assembly using libraries already present on the target TV. The private device transport, compiled output and recovery snapshots are deliberately excluded. Do not assume standard SDB shell access or attempt to disable security policy or obtain root. The source alone does not establish a supported transport path for another TV.

Compila con el SDK .NET adecuado. El resultado depende de .NET 6 y las bibliotecas existentes en la TV. Transporte privado, compilados y originales de recuperación se excluyen. No se presupone acceso shell estándar ni se requiere root o desactivar políticas de seguridad. El código no garantiza un transporte válido para otras TVs.
