# Classroom by Dani

<p align="center">
  <img src="https://github.com/user-attachments/assets/0973a388-68bd-4849-b7e6-d2c8f7480fbc" alt="Classroom by Dani">
</p>

<h4 align="center">
🚧 Proyecto en construcción 🚧
</h4>

## 📁 Propósito del proyecto

Este proyecto se está desarrollando con el objetivo de trabajar con la tecnología de C# y .NET, además de implementar un sistema tipo "classroom" que integre un chat para que los alumnos puedan compartir la información enseñada en el centro educativo.

## 🔨 Funcionalidades del proyecto

### 📂 Login
- La aplicación incluye un sistema de inicio de sesión compartido por profesores y alumnos.
- Una vez logueados, profesores y alumnos tendrán pantallas con funcionalidades específicas.

### 📂 Funcionalidades de profesores
- **Menú desplegable** con varias opciones:
  - Dar de alta o baja a un alumno.
  - Enviar un correo electrónico a un alumno o a sus padres.
- **Sección de clases:**
  - Cada cuadro corresponde a una clase. Al seleccionarlo, se cargarán las funcionalidades asociadas a esa clase:
    - Ver a todos los alumnos de la clase en una tabla, con opciones de búsqueda en la base de datos por ID u otros campos.
    - Crear tareas para toda la clase o para un alumno en particular.
    - Visualizar cuántas tareas ha completado cada alumno a tiempo.
    - Verificar alumnos, asignándoles un correo y un ID único de forma automática al agregarlos.
    - Mover alumnos entre clases y gestionar sus perfiles.
    - Corregir tareas con comentarios personalizados.

### 📂 Funcionalidades del servidor web (Hub)
- Alojamiento en la nube para mantener el servidor activo.
- Control de privilegios entre usuarios:
  - Los profesores tendrán funcionalidades adicionales en el chat, como silenciar a un alumno o borrar mensajes.
- Gestión de recepción de mensajes:
  - Los mensajes solo se enviarán a las clases correspondientes.
- Control de métodos y envío de mensajes recíprocos dentro del chat.

### 📂 Funcionalidades de los alumnos
- Interfaz intuitiva con un menú lateral para navegar entre las diferentes funcionalidades.
- Acceso a las clases y sus contenidos.
- Conexión al servidor web para chatear con compañeros.
- Visualización de tareas pendientes y opción de entregarlas subiendo un archivo.
- Acceso a clasificaciones de las tareas.

<p align="left">
  <img src="https://img.shields.io/badge/STATUS-EN%20DESARROLLO-green" alt="Estado del proyecto">
</p>

