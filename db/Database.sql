CREATE DATABASE InventarioDB;
GO

USE InventarioDB;
GO

-- Crear tabla Cliente
CREATE TABLE Cliente (
    ID_Cliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Cliente VARCHAR(100) NOT NULL,
    Telefono INT,
    Direccion VARCHAR(200),
	CONSTRAINT UQ_Cliente_Nombre_Cliente UNIQUE (Nombre_Cliente),
    CONSTRAINT UQ_Cliente_Telefono UNIQUE (Telefono)
);
GO
-- Crear tabla Sucursal
CREATE TABLE Sucursal (
    ID_Sucursal INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Sucursal VARCHAR(100) NOT NULL,
	Telefono INT,
    Descripcion VARCHAR(200),
    Estado bit,
	CONSTRAINT UQ_Sucursal_Nombre_Sucursal UNIQUE (Nombre_Sucursal),
    CONSTRAINT UQ_Sucursal_Telefono UNIQUE (Telefono)
);
GO
-- Crear tabla Proveedor
CREATE TABLE Proveedor (
    ID_Proveedor INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Proveedor VARCHAR(100) NOT NULL,
    Telefono INT,
    Direccion VARCHAR(200),
	CONSTRAINT UQ_Proveedor_Nombre_Proveedor UNIQUE (Nombre_Proveedor),
    CONSTRAINT UQ_Proveedor_Telefono UNIQUE (Telefono)
);
GO
-- Crear tabla TipoEmpleado 
CREATE TABLE Tipo_Empleado(
	ID_TipoEmpleado INT PRIMARY KEY IDENTITY(1,1),
	Descripcion VARCHAR(100),
	CONSTRAINT UQ_Tipo_Empleado_Descripcion UNIQUE (Descripcion)
);

-- Crear tabla TipoProducto
CREATE TABLE Tipo_Producto(
	ID_TipoProducto INT PRIMARY KEY IDENTITY(1,1),
	Descripcion VARCHAR(50),
	CONSTRAINT UQ_Tipo_Producto_Descripcion UNIQUE (Descripcion)
);
-- Crear tabla Producto
CREATE TABLE Producto (
    ID_Producto INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Producto NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(100),
    ID_TipoProducto INT NOT NULL,
    Fecha_Caducidad DATE ,
    ID_Proveedor INT NOT NULL,
	CostoUnitario INT NOT NULL,
    FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor(ID_Proveedor),
	FOREIGN KEY (ID_TipoProducto) REFERENCES Tipo_Producto(ID_TipoProducto),
	CONSTRAINT UQ_Producto_Nombre_Producto UNIQUE (Nombre_Producto)
);
GO
-- Crear tabla Inventario
CREATE TABLE Inventario (
    ID_Inventario INT PRIMARY KEY IDENTITY(1,1),
    ID_Sucursal INT Not null,
	ID_Producto INT,
    Cantidad INT,
	Estado BIT DEFAULT 1,
    FOREIGN KEY (ID_Producto) REFERENCES Producto(ID_Producto),
    FOREIGN KEY (ID_Sucursal) REFERENCES Sucursal(ID_Sucursal)
);
GO
-- Crear tabla Empleado
CREATE TABLE Empleado (
    ID_Empleado INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Empleado NVARCHAR(100) NOT NULL,
    ID_TipoEmpleado INT,
    Correo_Empleado NVARCHAR(100),
	FOREIGN KEY (ID_TipoEmpleado) REFERENCES Tipo_Empleado(ID_TipoEmpleado),
	CONSTRAINT UQ_Empleado_Correo_Empleado UNIQUE (Correo_Empleado)
);
GO
-- Crear tabla Pedido
CREATE TABLE Pedido (
    ID_Pedido INT PRIMARY KEY IDENTITY(1,1),
    Fecha_Creacion DATE,
    ID_Cliente INT NOT NULL,
	ID_Empleado INT NOT NULL,
    Estado_Orden Bit,
    Fecha_Envio DATE ,
	MontoTotal INT,
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID_Cliente),
	FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado)
);
GO
-- Crear tabla DetallePedido
CREATE TABLE DetallePedido (
	ID_Detalle INT PRIMARY KEY IDENTITY(1,1),
	ID_Pedido INT NOT NULL,
	Cantidad INT NOT NULL,
	ID_Producto INT NOT NULL,
	ID_Sucursal INT NOT NULL,
	Monto INT,
	FOREIGN KEY (ID_Sucursal) REFERENCES Sucursal(ID_Sucursal),
	FOREIGN KEY (ID_Pedido) REFERENCES Pedido(ID_Pedido),
	FOREIGN KEY (ID_Producto) REFERENCES Producto(ID_Producto)
);