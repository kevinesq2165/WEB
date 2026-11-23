
# Laboratorio - CRUD de Usuarios en ASP.NET Web Forms

implementación de un **CRUD (Crear, Leer, Actualizar y Eliminar)** utilizando **C#, ASP.NET Web Forms, HTML, CSS, Bootstrap** y conexión a una base de datos MySQL.

**Laboratorio de Desarrollo Web - CRUD**  
**Universidad Tecnológica de Panamá - Facultad de Ingeniería en Sistemas**

**Programado por:** Kevin Esquivel

**Fecha:** 22/11/2026

---

## 📋 Descripción

Este laboratorio implementa una aplicación web para la **gestión de usuarios**, permitiendo registrar, consultar, modificar y eliminar información almacenada en una base de datos MySQL.

Cada usuario contiene información como:

- Nombre
- Edad
- Correo electrónico
- Fecha de nacimiento

El sistema utiliza un **GridView** para mostrar los registros y permite seleccionar un usuario para consultar, modificar o eliminar sus datos.

La aplicación utiliza una **página maestra (Master Page)** para mantener un diseño común, junto con Bootstrap para mejorar la apariencia de los formularios y botones.

---

## 🔧 Funciones principales

El programa permite realizar las operaciones básicas de un CRUD:

- **Crear:** registrar nuevos usuarios en la base de datos.
- **Leer:** consultar los datos de un usuario sin permitir modificaciones.
- **Actualizar:** modificar la información de un usuario seleccionado.
- **Eliminar:** eliminar un usuario mediante una confirmación.
- **Listar:** mostrar los usuarios registrados mediante un GridView.
- **Validaciones:** comprobar los campos ingresados antes de guardar o actualizar.
- **Navegación:** desplazarse entre el listado y el formulario mediante botones.
- **Diseño:** interfaz en modo oscuro utilizando CSS y Bootstrap.



## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8
- **Tecnología web:** ASP.NET Web Forms
- **IDE:** Visual Studio
- **Lenguajes de diseño:** HTML5 y CSS3
- **Framework de diseño:** Bootstrap 5.2.3
- **Base de datos:** MySQL
- **Administrador de base de datos:** MySQL Workbench
- **Conexión:** MySql.Data
- **Controles:** GridView, TextBox, Label y Button
- **Programación:** Eventos y procedimientos almacenados

---

## 🗄️ Base de datos

El sistema utiliza la base de datos **`CRUD`**, que contiene la tabla **`Usuarios`** con los siguientes campos:

- **Id_Usuario:** identificador único del usuario.
- **Nombre:** nombre del usuario.
- **Edad:** edad registrada.
- **Correo:** correo electrónico.
- **FechaNacimiento:** fecha de nacimiento.

Para realizar las operaciones se utilizan cinco **procedimientos almacenados** de MySQL:

- **sp_load:** listar todos los usuarios.
- **sp_create:** registrar un nuevo usuario.
- **sp_read:** consultar un usuario mediante su ID.
- **sp_update:** modificar los datos de un usuario.
- **sp_delete:** eliminar un usuario mediante su ID.

El archivo **`CRUD.sql`** se encuentra en la carpeta `Base de datos` del repositorio.

---

## ⚙️ Instalación

**Requisitos:** Visual Studio, .NET Framework 4.8, MySQL Server, MySQL Workbench y el paquete NuGet MySql.Data.

**Importar la base de datos:**

1. Abrir MySQL Workbench.
2. Ir a **Server → Data Import**.
3. Seleccionar **Import from Self-Contained File**.
4. Buscar el archivo `CRUD.sql` de la carpeta `Base de datos`.
5. Importar la base de datos.

**Configurar la conexión:**

En el archivo `Web.config`, configurar los datos de conexión según el servidor MySQL utilizado:

- **Server:** dirección del servidor MySQL.
- **Database:** CRUD.
- **Uid:** usuario de MySQL.
- **Pwd:** contraseña del usuario.

La conexión debe tener los permisos necesarios para ejecutar los procedimientos almacenados.

Para visualizar la aplicación, abrir el proyecto en Visual Studio y ejecutar `Index.aspx` mediante IIS Express.
