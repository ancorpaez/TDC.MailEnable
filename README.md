TDC.MailEnable: Resumen del proyecto
Introducción:

TDC.MailEnable es un proyecto personal desarrollado en VB .NET para automatizar tareas de administración y seguridad en servidores MailEnable. El proyecto surgió de la necesidad de bloquear IPs tras detectar más de 12.000 inicios de sesión diarios en un servidor.

Funcionalidades:

Bloqueo de IPs: Analiza los registros de IMAP, POP y SMTP para identificar IPs maliciosas y las bloquea en los archivos de denegación de servicio de MailEnable (SMTP, POP y webmail).
Integración con SpamAssassin: Inicia y controla SpamAssassin, mostrando su registro en la misma interfaz.
Recuperación de emails: Permite recuperar emails individuales a partir de copias incrementales de la carpeta "postoffices" de MailEnable.
Recuperación de calendario, tareas y contactos: Permite recuperar elementos eliminados de forma permanente del calendario, tareas y contactos de MailEnable.
Migración de cuentas: Automatiza la migración de cuentas de MailEnable, controlando el proceso para evitar sobrecargas en el servidor.
Descarga de certificados SSL: Descarga automáticamente los certificados SSL de los dominios creados en MailEnable desde Plesk, manteniéndolos actualizados para los webmail.
Reparación de Autoresponder: Corrige el problema de Autoresponder que no utiliza CRLF al final de cada línea, evitando rechazos de emails.
Visor de cola de emails: Permite visualizar la cola de emails, mostrando el archivo, el email, el estado de MailEnable y la respuesta del servidor remoto.
Beneficios:

Mejora la seguridad del servidor: Bloquea IPs maliciosas y protege el servidor de ataques.
Aumenta la eficiencia: Automatiza tareas repetitivas, ahorrando tiempo y esfuerzo.
Facilita la recuperación de datos: Permite recuperar emails, calendario, tareas y contactos eliminados.
Optimiza la migración de cuentas: Migra cuentas de forma segura y controlada.
Mantiene los certificados SSL actualizados: Garantiza la seguridad de las comunicaciones webmail.
Resuelve problemas de Autoresponder: Envía emails correctamente con CRLF al final de cada línea.
Diagnostica problemas de la cola de emails: Facilita la identificación y resolución de problemas en la entrega de emails.

Licencia:
TDC.MailEnable es un proyecto de código abierto bajo la licencia MIT.

Conclusión:
TDC.MailEnable es una herramienta útil para administradores de servidores MailEnable que buscan mejorar la seguridad, eficiencia y confiabilidad de sus servidores.
