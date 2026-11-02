# Project record / Registro del proyecto

Saved baseline: **Bedroom v14**, 2 November 2026. Based on upstream CleanFrame 0.7.0, commit `845f332`. This label records the adaptation; the inherited manifest version is not a separate published release.

Versión de referencia: **Dormitorio v14**, 2 de noviembre de 2026. Basada en CleanFrame 0.7.0, commit `845f332`. La etiqueta identifica esta adaptación; la versión heredada del manifiesto no constituye una publicación nueva.

## Target / Destino

- Samsung TQ48S93DAEXXC · S93D OLED 48 inches / pulgadas.
- Tizen 9, ARMv7; firmware T-PTMDDEUC-0090-2130.0.
- Spanish interface / Interfaz en español.
- No TV IP address, serial number, DUID, private app identity or credentials are required in this record. / No se incluyen IP, número de serie, DUID, identidad privada ni credenciales.

## Implementation map / Mapa para modificar

| Area / Área | Files / Archivos |
| --- | --- |
| UI, navigation, preferences / Interfaz, navegación, preferencias | `app/main.js`, `app/style.css`, `app/index.html` |
| Tizen calls, installed apps, HDMI, tuning / API de TV, apps, HDMI, canales | `app/device.js` |
| Runtime assets / Recursos del televisor | `app/assets/` |
| Background catalogue and provenance / Catálogo y procedencia | `app/assets/wallpapers/catalog.js`, `SOURCES.json` |
| Selected design masters and prompts / Originales seleccionados y descripciones | `design/backgrounds/` |
| Brand sources / Fuentes de marcas | `app/assets/icons/ADDITIONAL-SOURCES.json`, `THIRD_PARTY_NOTICES.md` |
| Current browser regression checks / Pruebas actuales de navegador | `scripts/bedroom-tests/` |

## Evidence and limits / Evidencia y límites

The owner confirmed live TV opening, channel tuning from the left list, Samsung quick settings, and general operation. Browser checks cover preferences, HDMI name/icon editing, ordering, focus, geometry and the 22-background gallery. Preview screenshots use simulated TV APIs; they do not prove physical-TV behavior. The final six series backgrounds and optional Live TV card were installed; a separate final physical verification of every new option was not recorded.

El propietario confirmó la apertura de TDT, el cambio de canal desde la lista izquierda, los ajustes rápidos de Samsung y el funcionamiento general. Las pruebas de navegador cubren preferencias, editor de nombres/iconos HDMI, ordenación, foco, geometría y los 22 fondos. Las capturas usan API simuladas y no prueban por sí mismas el funcionamiento físico. Los seis últimos fondos de series y el acceso opcional a TV en directo se instalaron; no quedó registrada una comprobación física final de cada opción nueva.

Pending limitations: reliable fixed startup after warm standby; live synchronization of Samsung HDMI aliases; Samsung store opening needs owner verification. / Limitaciones pendientes: arranque fijo tras espera, sincronización en tiempo real de nombres HDMI de Samsung y verificación de la apertura de la tienda.

## Private recovery / Recuperación privada

Git intentionally excludes `.local/`, `dist/`, certificates, passwords and recovery state. The existing installation's stable identity, certificates and original native Home baseline remain local. Do not overwrite them when making future updates. Original TV recovery backups and unused design drafts also remain outside this repository.

Git excluye `.local/`, `dist/`, certificados, contraseñas y recuperación. La identidad estable, los certificados y los valores originales de Inicio permanecen en el equipo del propietario. No los sobrescribas al actualizar. Las copias de recuperación y los borradores gráficos descartados también quedan fuera del repositorio.

## Archive validation / Validación del archivo

On 2 November 2026, ESLint, widget/resource validation, all 22 simulated device-adapter tests, the current bedroom browser regression suite (Edge), public-source scanning and the unsigned public-font export passed. The browser checks use mocked Tizen APIs. Native Windows cannot run the inherited POSIX tooling tests; the Linux GitHub workflow includes them. Hosted workflow results must be checked separately after pushing.

El 2 de noviembre de 2026 pasaron ESLint, validación de recursos, los 22 tests del adaptador simulado, las pruebas actuales de navegador en Edge, el escaneo de publicación y la exportación sin firmar con fuentes públicas. Windows no puede ejecutar directamente los tests POSIX heredados; están incluidos en el flujo Linux de GitHub. Su resultado remoto debe comprobarse después de subir.
