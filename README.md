# Ejercicio práctico de .NET (SR)
### **Nombre:** Mauro Etzael Henaro Sánchez
### **Fecha:** 27.06.2017
### **Ruta del Código:** https://github.com/mehs2690/SisConNetPractico.git
### **Nombre de la Base de Datos:** MehsDataUser y MehsDataBugs
### **Motor de Base de Datos:** Sql Server

# Elaborar una aplicación en ASP.NET que considere lo siguiente:
  * Se trata de una aplicación de seguimiento de bugsque presenten los sitemas de los usuarios.
  * Los usuarios registrarán en el sistema los bugs que presenten sus otros sistemas.
  * Deberá de elegir el sistema que presenta el problema, y poder subir la imagen de la pantalla de error.
  * Capturar una descripción de la situación en la que se presentó el error.
  * Existirá un módulo de consulta de los incidentes registrados para el seguimiento por parte del depto. de desarrollo de la empresa X.
  * Se debe poder consultar por sistema , por usuario que registra y por rango de fechas.
  * Se debe poder emitir un reporte con los datos que se están consultando en el momento.
  * El departamento de desarrollo podrá cerrar el caso como resuelto.
  * Una vez que los usuarios ingresen al sistema, se les informará de sus casos cerrados.

# Consideraciones funcionales:
  * Debe de existir un catálogo de usuarios con los siguientes perfiles:
    * Usuario
    * Desarrollador
    * Administrador.
  * De acuerdo al usuario firmado en el sistema, se habilitarán las funciones que puede realizar.
  * El sistema debe implementar regionalización, mínimo en lenguaje español e inglés
  * Se debe poder elegir de mínimo 2 temas visuales para configurar el look and feel de la aplicación. Dichos valores deben ser recordados por la apliación, según el usuario que las seleccione.
  * Realizar las validaciones pertinentes.

# Consideraciones Técnicas
  * Implementar interfases
  * implementar ajax
  * la base de datos de usuarios y bugs deben ser bases de datos diferentes
  * la información del tema y el idioma deben ser persistidos mediante profiles
  * la información de los usuarios del sistema debe ser consumida de un web service
  * manejar grupos de validación
  * implementar recursos
  * la validación de usuarios debe ser mediante Membership provider
  * Los menús deben configurar de acuerdo al perfil del usuario firmado.

**Plataforma:** .NET
**Lenguaje:** Indistinto
**Base de Datos:** Sql Server 2000 (stored procedures)
**Arquitectura:** SOA / 3 capas
**Informes:** Crystal Reports

  * Contemplar las validaciones necesarias
