--TIPO PRODUCTO
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Frutas Frescas');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Verduras');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Carnes');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Lácteos');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Pescados y Mariscos');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Panadería');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Bebidas');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Congelados');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Enlatados');
INSERT INTO Tipo_Producto (Descripcion) VALUES ('Snacks');


-- Proveedores con números de teléfono de 8 dígitos
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('AgroFresco', 12345678, 'Calle 123, Ciudad A');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Carnes del Norte', 23456789, 'Avenida 45, Ciudad B');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Mariscos del Pacífico', 34567890, 'Boulevard 67, Ciudad C');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Lácteos y Derivados', 45678901, 'Carrera 89, Ciudad D');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('FruVer Export', 56789012, 'Calle 12, Ciudad E');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Panadería Moderna', 67890123, 'Avenida 34, Ciudad F');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Congelados Sur', 78901234, 'Carrera 56, Ciudad G');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Enlatados Delicias', 89012345, 'Boulevard 78, Ciudad H');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Bebidas Refrescantes', 90123456, 'Calle 90, Ciudad I');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Snacks Rápidos', 11234567, 'Avenida 21, Ciudad J');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Pescadería Mar Azul', 22345678, 'Carrera 43, Ciudad K');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Verduras de la Huerta', 33456789, 'Calle 54, Ciudad L');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Frutas Tropicales', 44567890, 'Avenida 76, Ciudad M');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Lácteos Frescos', 55678901, 'Carrera 98, Ciudad N');
INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion) VALUES ('Cárnicos de Calidad', 66789012, 'Boulevard 11, Ciudad O');



-- Sucursales con números de teléfono de 8 dígitos
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Central', 12345670, 'Sucursal principal en el centro de la ciudad.', 1);
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Norte', 12345671, 'Sucursal ubicada en la zona norte, con amplio almacén.', 1);
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Sur', 12345672, 'Sucursal en la zona sur, especializada en productos congelados.', 1);
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Este', 12345673, 'Sucursal en la zona este, enfocada en distribución.', 1);
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Oeste', 12345674, 'Sucursal en la zona oeste, con atención al cliente.', 1);
INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado) 
VALUES ('Sucursal Costa', 12345675, 'Sucursal cerca de la costa, especializada en mariscos.', 1);

-- Clientes con números de teléfono de 8 dígitos
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Supermercado La Plaza', 98765432, 'Calle 10, Zona Comercial, Ciudad A');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Distribuidora El Buen Gusto', 87654321, 'Avenida Principal, Barrio Centro, Ciudad B');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Restaurante Delicias del Mar', 76543210, 'Boulevard del Mar, Zona Costera, Ciudad C');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Café y Panadería Los Abuelos', 65432109, 'Calle 22, Barrio Viejo, Ciudad D');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Hotel Paraíso Tropical', 54321098, 'Avenida de los Hoteles, Zona Turística, Ciudad E');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Tiendas Súper Económicas', 43210987, 'Carrera 9, Zona Residencial, Ciudad F');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Pizzería Italiana Bella Napoli', 32109876, 'Boulevard Italia, Barrio Gourmet, Ciudad G');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Bar y Parrilla El Buen Sabor', 21098765, 'Calle 33, Barrio Bohemio, Ciudad H');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Supermercado La Económica', 10987654, 'Avenida Sur, Zona Comercial, Ciudad I');
INSERT INTO Cliente (Nombre_Cliente, Telefono, Direccion) 
VALUES ('Centro Comercial Ciudad Norte', 19876543, 'Carrera 10, Zona Norte, Ciudad J');


--Tipo Empleado
INSERT INTO Tipo_Empleado (Descripcion) VALUES ('Gerente de Almacén');
INSERT INTO Tipo_Empleado (Descripcion) VALUES ('Supervisor de Turno');
INSERT INTO Tipo_Empleado (Descripcion) VALUES ('Operario de Almacén');
INSERT INTO Tipo_Empleado (Descripcion) VALUES ('Encargado de Inventarios');
INSERT INTO Tipo_Empleado (Descripcion) VALUES ('Auxiliar de Logística');

-- Producto
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Manzana Roja', 'Manzanas frescas y crujientes', 1, '2024-12-15', 1, 50); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Leche Entera', 'Leche entera pasteurizada', 4, '2024-09-10', 4, 25); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Filete de Pollo', 'Filetes de pollo frescos', 3, '2024-08-30', 2, 70); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Pan Integral', 'Pan integral recién horneado', 6, '2024-08-25', 6, 15); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Queso Cheddar', 'Queso cheddar madurado', 4, '2024-10-20', 4, 45); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Atún en Lata', 'Lata de atún en aceite', 9, '2025-03-01', 8, 20); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Zanahorias', 'Zanahorias frescas', 2, '2024-09-05', 5, 10); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Jugo de Naranja', 'Jugo natural de naranja', 7, '2024-11-01', 9, 30); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Helado de Vainilla', 'Helado de vainilla en envase', 8, '2024-12-15', 7, 40); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Tomate', 'Tomates frescos', 2, '2024-09-07', 5, 15); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Papas Fritas', 'Snacks de papas fritas', 10, '2025-01-15', 10, 12); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Pescado Fresco', 'Pescado fresco del día', 5, '2024-08-29', 3, 90); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Yogurt Natural', 'Yogurt natural sin azúcar', 4, '2024-09-20', 4, 35); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Pera Verde', 'Peras frescas y jugosas', 1, '2024-12-10', 1, 45); -- Precio en colones
INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
VALUES ('Lechuga Romana', 'Lechuga fresca y crujiente', 2, '2024-08-24', 5, 18); -- Precio en colones


--Empleados:
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Carlos Martínez', 1, 'c.martinez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Ana López', 2, 'a.lopez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Luis Fernández', 3, 'l.fernandez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Marta Gómez', 4, 'm.gomez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Juan Pérez', 5, 'j.perez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Sofía Rodríguez', 1, 's.rodriguez@empresa.com');
INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
VALUES ('Pedro Morales', 3, 'p.morales@empresa.com');

--Invetario
-- Inventario para Sucursal Central
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (1, 1, 100, 1); -- Manzana Roja
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (1, 2, 50, 1);  -- Leche Entera
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (1, 3, 75, 1);  -- Filete de Pollo
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (1, 4, 60, 1);  -- Pan Integral
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (1, 5, 40, 1);  -- Queso Cheddar
-- Inventario para Sucursal Norte
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (2, 6, 80, 1);  -- Atún en Lata
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (2, 7, 90, 1);  -- Zanahorias
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (2, 8, 100, 1); -- Jugo de Naranja
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (2, 9, 50, 1);  -- Helado de Vainilla
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (2, 10, 120, 1); -- Tomate
-- Inventario para Sucursal Sur
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (3, 11, 70, 1);  -- Papas Fritas
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (3, 12, 85, 1);  -- Pescado Fresco
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (3, 13, 65, 1);  -- Yogurt Natural
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (3, 14, 90, 1);  -- Pera Verde
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (3, 15, 55, 1);  -- Lechuga Romana
-- Inventario para Sucursal Este
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (4, 1, 110, 1); -- Manzana Roja
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (4, 4, 55, 1);  -- Pan Integral
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (4, 7, 95, 1);  -- Zanahorias
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (4, 8, 85, 1);  -- Jugo de Naranja
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (4, 10, 130, 1); -- Tomate
-- Inventario para Sucursal Oeste
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (5, 2, 65, 1);  -- Leche Entera
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (5, 3, 80, 1);  -- Filete de Pollo
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (5, 5, 50, 1);  -- Queso Cheddar
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (5, 12, 60, 1); -- Pescado Fresco
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (5, 13, 75, 1); -- Yogurt Natural
-- Inventario para Sucursal Costa
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (6, 6, 100, 1); -- Atún en Lata
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (6, 9, 70, 1);  -- Helado de Vainilla
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (6, 11, 85, 1); -- Papas Fritas
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (6, 14, 80, 1); -- Pera Verde
INSERT INTO Inventario (ID_Sucursal, ID_Producto, Cantidad, Estado) VALUES (6, 15, 90, 1); -- Lechuga Romana

-- Pedidos
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-01', 1, 1, 1, '2024-08-03', 875); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-02', 2, 2, 1, '2024-08-04', 520); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-03', 3, 3, 1, '2024-08-05', 2200); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-04', 4, 4, 1, '2024-08-06', 708); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-05', 5, 5, 1, '2024-08-07', 1550); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-06', 6, 6, 1, '2024-08-08', 1610); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-07', 7, 7, 1, '2024-08-09', 1080); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-08', 8, 1, 1, '2024-08-10', 360); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-09', 9, 2, 1, '2024-08-11', 1300); -- Monto en colones
INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
VALUES ('2024-08-10', 10, 3, 1, '2024-08-12', 1335); -- Monto en colones


-- Detalles de Pedidos con sucursales del 1 al 6 y montos actualizados
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (1, 10, 1, 1, 500); -- Pedido 1, Manzana Roja (Precio por unidad: 50 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (1, 5, 2, 1, 375); -- Pedido 1, Leche Entera (Precio por unidad: 75 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (2, 8, 6, 2, 320); -- Pedido 2, Atún en Lata (Precio por unidad: 40 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (2, 4, 8, 2, 200); -- Pedido 2, Jugo de Naranja (Precio por unidad: 50 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (3, 15, 3, 3, 1800); -- Pedido 3, Filete de Pollo (Precio por unidad: 120 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (3, 10, 9, 3, 400); -- Pedido 3, Helado de Vainilla (Precio por unidad: 40 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (4, 12, 7, 4, 600); -- Pedido 4, Yogurt Natural (Precio por unidad: 50 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (4, 6, 10, 4, 108); -- Pedido 4, Papas Fritas (Precio por unidad: 18 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (5, 20, 4, 5, 1400); -- Pedido 5, Pescado Fresco (Precio por unidad: 70 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (5, 5, 11, 5, 150); -- Pedido 5, Zanahorias (Precio por unidad: 30 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (6, 7, 5, 6, 1050); -- Pedido 6, Filete de Pollo (Precio por unidad: 150 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (6, 8, 4, 6, 560); -- Pedido 6, Queso Cheddar (Precio por unidad: 70 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (7, 14, 2, 1, 840); -- Pedido 7, Leche Entera (Precio por unidad: 60 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (7, 12, 1, 1, 600); -- Pedido 7, Manzana Roja (Precio por unidad: 50 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (8, 10, 12, 2, 200); -- Pedido 8, Pera Verde (Precio por unidad: 20 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (8, 8, 13, 2, 160); -- Pedido 8, Lechuga Romana (Precio por unidad: 20 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (9, 6, 5, 3, 900); -- Pedido 9, Filete de Pollo (Precio por unidad: 150 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (9, 10, 6, 3, 400); -- Pedido 9, Atún en Lata (Precio por unidad: 40 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (10, 8, 3, 4, 960); -- Pedido 10, Filete de Pollo (Precio por unidad: 120 colones)
INSERT INTO DetallePedido (ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
VALUES (10, 5, 2, 4, 375); -- Pedido 10, Leche Entera (Precio por unidad: 75 colones)