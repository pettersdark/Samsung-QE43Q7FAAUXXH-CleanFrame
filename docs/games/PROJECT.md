# Games-TV project record / Registro de TV Juegos

Baseline / Versión: **games-v1.0**, 2 November / noviembre 2026.

Samsung **TQ55S85FAUXXC**, S85F OLED 55-inch / 55 pulgadas (2025), Tizen 9.0 ARMv7 / 32-bit, firmware **T-PTMFDEUC-0090-1301.0**. Based on pettersdark's S93D bedroom adaptation `5f5d1b7`, itself based on nthnclrk/CleanFrame 0.7.0 `845f332`. Source and attribution history are retained. The inherited manifest version is not the adaptation's release label.

## Physically confirmed / Confirmado en la TV

- Application installed, launched, and reported working by the owner. / Aplicación instalada, abierta y confirmada por el propietario.
- Physical Home opens TV Juegos. / El botón de la casa abre TV Juegos.
- After the requested test of switching to Netflix/YouTube, powering off, waiting and powering on, the owner reported that our launcher appeared. The specific external app and elapsed wait were not separately recorded. / Tras la prueba solicitada desde Netflix/YouTube, apagado, espera y encendido, el propietario confirmó que apareció nuestro menú. No se registraron por separado la app externa concreta ni la duración de espera.
- Native settings readback points Home and the startup app fields to the owner's TV Juegos identity, with autostart enabled. Samsung's first-screen value was preserved. / La lectura de ajustes confirma nuestra identidad en Inicio y los campos de arranque, con inicio automático activo; se conservó el valor de primera pantalla de Samsung.
- Exact-value restore and reapply were tested independently for Home and startup. / Se probaron restauración exacta y reaplicación de Inicio y arranque por separado.

This is evidence for this TV and firmware, not a guarantee for all cold boots, standby states, third-party app behavior or firmware updates. Individual HDMI, live channel tuning and quick-settings tests remain pending on this S85F; the bedroom TV's confirmations do not establish those results here.

La evidencia corresponde a esta TV y firmware. No garantiza todos los arranques en frío, estados de espera, apps externas ni futuras actualizaciones. Las pruebas individuales de HDMI, cambio de canal y ajustes rápidos siguen pendientes en esta S85F; las comprobaciones del dormitorio no sustituyen estas pruebas.

## Changes from the bedroom build / Cambios respecto al dormitorio

The interface, 22 backgrounds, controls and artwork are reused. The application has its own SDK-generated identity, TV_Juegos certificate profile and local recovery records. Its display name is TV Juegos. No bedroom HDMI aliases or saved installed-app inventory are injected; this TV discovers its own apps. The bedroom installation and repository were preserved.

Se reutilizan interfaz, 22 fondos, controles e imágenes. La aplicación tiene identidad propia del SDK, perfil TV_Juegos y recuperación local independiente. El nombre visible es TV Juegos. No incorpora nombres HDMI ni inventario de apps del dormitorio; consulta sus propias aplicaciones. La instalación y el repositorio del dormitorio se conservan.

## Maintenance map / Mapa de mantenimiento

| Area / Área | Files / Archivos |
| --- | --- |
| Interface, navigation and preferences / Interfaz, navegación y preferencias | `app/main.js`, `app/style.css`, `app/index.html` |
| Tizen app discovery, HDMI and TV channels / API, HDMI y canales | `app/device.js` |
| Wallpapers and provenance / Fondos y procedencia | `app/assets/wallpapers/`, `design/backgrounds/` |
| Native source templates / Plantillas nativas | `scripts/native-home/games-2025/` |
| Inherited UI regression checks / Pruebas de interfaz heredadas | `scripts/bedroom-tests/` |

Browser screenshots are the shared interface preview, with simulated APIs and Spanish labels, described in both languages. They are not photographs of this S85F. UI browser tests retain their bedroom folder name because the UI is shared; device integration needs separate physical checks.

Las capturas muestran la interfaz compartida en navegador, con API simuladas y textos en español, explicados en ambos idiomas. No son fotografías de esta S85F. Las pruebas conservan el nombre de carpeta bedroom porque la interfaz es común; la integración requiere pruebas físicas propias.

## Private setup and recovery / Configuración y recuperación privadas

No IP, serial number, DUID, account secrets, certificate passwords, personal app IDs or signed packages belong in Git. The existing owner's setup and compiled native helper remain in ignored `.local/games/` in the original local project; recovery backups also exist outside Git. A source clone does not replace those backups.

IP, número de serie, DUID, secretos de cuenta, contraseñas, identidad personal y paquetes firmados quedan fuera de Git. La configuración existente y las herramientas compiladas permanecen en `.local/games/`, excluida de Git en el proyecto local original; las copias de recuperación también están fuera. Clonar el código no sustituye esas copias.

To remove native integration, restore the startup snapshot first and then the original Home snapshot using the private tools for this exact TV/firmware. Preserve the original snapshots; never overwrite them with the applied state. Restore before uninstalling the app or changing its identity.

Para retirar la integración nativa, restaura primero el estado de arranque y después el Inicio original con las herramientas privadas de esta TV/firmware. Conserva los originales y no los sustituyas por los valores aplicados. Restaura antes de desinstalar la app o cambiar su identidad.

## Archive validation / Validación del archivo

On 2 November 2026, ESLint, resource/identity checks, 22 simulated adapter tests, all six retained browser regression scripts in Edge, public-source scanning and unsigned public-font export passed in this separate checkout. Both sanitized native C# templates compiled successfully. These local checks do not replace the physical-TV results recorded above; hosted GitHub checks run separately after publication.

El 2 de noviembre de 2026 pasaron ESLint, recursos/identidad, 22 tests del adaptador, las seis pruebas de navegador en Edge, el escaneo público y la exportación sin firmar en esta copia separada. Las dos plantillas C# compilaron. Las comprobaciones locales no sustituyen las pruebas físicas anteriores; GitHub ejecuta su validación después de subir.

## Channel activation update / Actualización de selección de canales · 2026-11-02

Pressing OK or clicking a channel now tunes it and opens the native full-screen TV viewer after successful tuning. Moving remote focus retains preview tuning; hover never opens full-screen. The separate full-screen button remains available. Failed tuning stays in the list, and stale/cancelled requests cannot trigger a later handoff. The owner confirmed the update after installation on both TVs and authorized publication.

Pulsar OK o hacer clic en un canal lo sintoniza y abre el visor a pantalla completa tras confirmar la sintonización. Mover el foco conserva la vista previa; pasar el puntero no abre pantalla completa. Se conserva el botón independiente. Los errores dejan la lista abierta y las peticiones canceladas o sustituidas no abren el visor después. El propietario confirmó el funcionamiento tras instalar en ambas TVs y autorizó la publicación.

Validation: ES5 lint, resource checks, simulated adapter tests, and browser checks at 1080p/720p covering focus versus activation, explicit full-screen button, tune errors, superseded requests, Back and delayed preview cleanup. Personal signing, device identities and recovery records remain excluded from Git.

Validación: sintaxis ES5, recursos, adaptador simulado y navegador a 1080p/720p, incluyendo foco frente a pulsación, botón independiente, errores de sintonización, peticiones sustituidas, Volver y limpieza tardía de la vista previa. Firma personal, identidades y recuperación quedan fuera de Git.

## Unlimited carousel and monochrome apps / Carrusel sin límite y apps monocromas · 2026-11-02

Removed the nine-shortcut Home limit and the 256-record restore truncation. Existing Home order is preserved, with the same initial default selection size. Users can add installed apps and available HDMI/Live TV shortcuts without an application-imposed maximum. The order editor scrolls independently, preserves focus, and supports moving/removing/undoing entries beyond the old limit. Storage failures retain the previous saved state.

Se elimina el límite de nueve accesos y el recorte de restauración a 256 registros. Se conservan el orden guardado y el tamaño de la selección inicial. Se pueden añadir apps instaladas y accesos HDMI/TDT disponibles sin máximo impuesto por la app. El editor desplaza su columna de orden y mantiene foco, mover/quitar/deshacer más allá del límite anterior. Los fallos de almacenamiento conservan el estado guardado anterior.

Added bundled theme-aware Crunchyroll and SmartTV Club marks, using their installed IDs or exact normalized names. Sources/licences are recorded in ADDITIONAL-SOURCES.json and third-party notices. Browser validation covers 49 interactively added/reordered shortcuts, a 310-entry saved catalogue with discovery unavailable, reload, long-list navigation, editor visibility, and both icons in light/dark at 1080p/720p. Physical confirmation is pending after installation.

Se añaden marcas monocromas de Crunchyroll y SmartTV Club a partir de IDs/nombres reales. Fuentes y condiciones constan en los registros de recursos. Las pruebas de navegador cubren 49 accesos añadidos/ordenados, 310 guardados sin consulta disponible, recarga, navegación, visibilidad del editor e iconos claros/oscuros a 1080p/720p. La comprobación física queda pendiente después de instalar.

Owner validation / Validación del propietario · 2026-11-02: the owner accepted the unlimited-carousel and two monochrome-icon update for the bedroom and games TVs and authorized publication. El propietario da por válida la actualización del carrusel sin límite y los dos iconos en dormitorio y juegos, y autoriza su publicación.
