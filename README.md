# **Proyecto de Back-End - [InventorySystem]**

### Descripción
Back-end de un sistema de inventario desarrollado en arquitectura por n capas diseñado para gestionar productos perecederos de manera eficiente, permitiendo controlar productos,inventarios por sede, pedidos, clientes, proveedores y empleados. El sistema esta enfocado en las buenas practicas de programacion y en el manejo de errores en diferentes capas para una mejor proteccion de datos, ademas, se utilizo stored procedures para realizar las consultas necesarias y mandar los resultados a las capas superiores. El sistema tiene la capacidad de realizar reportes de productos, inventario, pedidos y demas.

---

## **Tabla de Contenidos**

1. [Tecnologías Utilizadas](#tecnologías-utilizadas)
2. [Arquitectura](#arquitectura)
3. [Instalación y Configuración](#instalación-y-configuración)
4. [Funcionalidades Principales](#funcionalidades-principales)

---

## **Tecnologías Utilizadas**

Lista de las tecnologías y herramientas usadas:

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8
- **Base de Datos:** SQL Server
- **Front-end:** React
- **ORM / Acceso a Datos:** ADO.NET y procedimientos almacenados
- **Herramientas de Configuración:** `System.Configuration` para la conexión a base de datos
- **Control de Versiones:** Git y GitHub
- **Otros:** Crystal Reports para la creacion de reportes.

---

## **Arquitectura**

Describe la arquitectura del proyecto, destacando el diseño modular, el uso de capas, etc. Aquí tienes un ejemplo para un diseño en capas:

### Diseño en Capas

- **Capa de Presentación:** Si tienes una API de prueba o documentación interactiva.
- **Controladores de API:** Endpoints de la API para acceder a los metodos que traen informacion.
- **Capa de Negocio:** Lógica del negocio, validación de datos y manipulación de datos antes de interactuar con la base de datos.
- **Capa de Atributos:** Conexión y acceso a la base de datos mediante ADO.NET y procedimientos almacenados.
- **Capa de DataAccess:** Conexión y acceso a la base de datos mediante ADO.NET y procedimientos almacenados.
- **Modelo de Datos:** Representación de entidades de base de datos mediante clases C#.

### Diagrama de la Base de Datos

![Diagrama](https://github.com/user-attachments/assets/9544baad-5ab6-4156-861c-7d6ca717d4ce)


---

## **Instalación y Configuración**

Pasos para instalar y configurar el proyecto localmente.

1. **Clonar el Repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/nombre-del-repositorio-backend.git
   cd nombre-del-repositorio-backend
   ```
2. **Configuración de la Base de Datos:**

   - Asegúrate de tener SQL Server instalado y de que los procedimientos almacenados y tablas estén creados en tu base de datos.
   - Configura la cadena de conexión en el archivo `web.config` (.NET Framework) para que coincida con tu servidor y base de datos local.
     ```xml
     <connectionStrings>
         <add name="DefaultConnection" 
              connectionString="Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;User ID=USUARIO;Password=CONTRASEÑA"
              providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
## Funcionalidades Principales

Lista de las funcionalidades principales que ofrece tu back-end:

- CRUD de productos, clientes, proveedores y empleados.
- Control de inventario con actualización en tiempo real.
- Reportes generados con Crystal Reports.


