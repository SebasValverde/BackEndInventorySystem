Use InventarioDB
GO

--CRUD Tipo Producto

--Create
Create Procedure NuevoTipoProducto(@Descripcion varchar(50),@IdMensaje int OUTPUT, @Mensaje varchar(250) OUTPUT)
as
begin try
	begin transaction
		if exists (select * from Tipo_Producto where Descripcion= @Descripcion)
			begin 
				SET @IdMensaje = -1
				SET @Mensaje = 'Ya existe ese tipo producto'
			end
		else
			begin
				insert into Tipo_Producto values(@Descripcion)
				SET @IdMensaje = 0
				SET @Mensaje = 'Tipo producto agregado correctamente'
			end
	commit transaction
end try
begin catch
	SET @IdMensaje = -3
    SET @Mensaje = ERROR_MESSAGE()
	rollback transaction
end catch
	select @IdMensaje IdMensaje, @Mensaje Mensaje
GO

--Read
CREATE PROCEDURE ConsultaTipoProducto(@ID_TipoProducto int,@IdMensaje int OUTPUT,@Mensaje varchar(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT 1 FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto)
    BEGIN
        SELECT ID_TipoProducto, Descripcion FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto; 
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Tipo de Producto no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaTipoPNombre(@Categoria varchar(200))
AS
BEGIN
    SELECT ID_TipoProducto, Descripcion FROM Tipo_Producto
    WHERE
        ((ISNULL(@Categoria, '') <> '' AND Descripcion LIKE '%' + @Categoria + '%') OR ISNULL(@Categoria, '') = '')
END
GO

CREATE PROCEDURE ConsultaTiposProducto(@ID_TipoProducto int,@IdMensaje int OUTPUT,@Mensaje varchar(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT * FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto)
    BEGIN
        SELECT * FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto; 
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Tipo de Producto no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

--Update
CREATE PROCEDURE ModificarTipoProducto(@ID_TipoProducto INT,@NuevaDescripcion VARCHAR(50),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT 1 FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto)
        BEGIN
            IF EXISTS (SELECT 1 FROM Tipo_Producto WHERE Descripcion = @NuevaDescripcion AND ID_TipoProducto <> @ID_TipoProducto)
            BEGIN
                SET @IdMensaje = -2;
                SET @Mensaje = 'La descripción del tipo de producto ya existe en otro tipo de producto';
            END
            ELSE
            BEGIN
                UPDATE Tipo_Producto
                SET Descripcion = @NuevaDescripcion
                WHERE ID_TipoProducto = @ID_TipoProducto;

                SET @IdMensaje = 0;
                SET @Mensaje = 'Tipo de Producto modificado correctamente';
            END
        END
        ELSE
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'El Tipo de Producto no existe';
        END

        COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Delete
CREATE PROCEDURE [dbo].[EliminarTipoProducto](@ID_TipoProducto INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION

    IF EXISTS (SELECT 1 FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto)
    BEGIN
        IF EXISTS (SELECT 1 FROM Producto WHERE ID_TipoProducto = @ID_TipoProducto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se eliminó porque el Tipo de Producto está asociado a uno o más Productos';
        END
        ELSE
        BEGIN
            DELETE FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Tipo de Producto eliminado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Tipo de Producto no existe';
    END

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO



--CRUD Proveedor

--Create
CREATE PROCEDURE NuevoProveedor(@Nombre_Proveedor VARCHAR(100),@Telefono INT,@Direccion VARCHAR(200),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT * FROM Proveedor WHERE Nombre_Proveedor = @Nombre_Proveedor)
        BEGIN 
            SET @IdMensaje = -1;
            SET @Mensaje = 'Ya existe ese proveedor';
        END
        ELSE
		BEGIN
			IF EXISTS (SELECT * FROM Proveedor WHERE Telefono = @Telefono)
			BEGIN 
				SET @IdMensaje = -2;
				SET @Mensaje = 'Ya existe un proveedor con este Número Telefónico';
			END
			ELSE
			BEGIN
				INSERT INTO Proveedor (Nombre_Proveedor, Telefono, Direccion)
				VALUES (@Nombre_Proveedor, @Telefono, @Direccion);
            
				SET @IdMensaje = 0;
				SET @Mensaje = 'Proveedor agregado correctamente';
			END
		END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Read
CREATE PROCEDURE ConsultaProveedor(@ID_Proveedor INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT 1 FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor)
    BEGIN
        SELECT ID_Proveedor, Nombre_Proveedor, Telefono, Direccion FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor;    
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Proveedor no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaProveedor(@ID_Proveedor INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT * FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor)
    BEGIN
        SELECT ID_Proveedor, Nombre_Proveedor, Telefono, Direccion FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor;    
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Proveedor no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaProveedorNombre(@Nombre varchar(200))
AS
BEGIN
    SELECT * FROM Proveedor
    WHERE
        ((ISNULL(@Nombre, '') <> '' AND Nombre_Proveedor LIKE '%' + @Nombre + '%') OR ISNULL(@Nombre, '') = '')
END
GO

--Update
CREATE PROCEDURE [dbo].[ModificarProveedor](@ID_Proveedor INT,@NuevoNombre_Proveedor VARCHAR(100),@NuevoTelefono INT,@NuevaDireccion VARCHAR(200),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT 1 FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor)
        BEGIN
            IF EXISTS (SELECT 1 FROM Proveedor WHERE Nombre_Proveedor = @NuevoNombre_Proveedor AND ID_Proveedor <> @ID_Proveedor)
            BEGIN
                SET @IdMensaje = -1;
                SET @Mensaje = 'Ya existe un proveedor con ese nombre';
            END
            ELSE
            BEGIN
                IF EXISTS (SELECT 1 FROM Proveedor WHERE Telefono = @NuevoTelefono AND ID_Proveedor <> @ID_Proveedor)
                BEGIN 
                    SET @IdMensaje = -2;
                    SET @Mensaje = 'Ya existe un proveedor con este número telefónico';
                END
                ELSE
                BEGIN
                    UPDATE Proveedor
                    SET Nombre_Proveedor = @NuevoNombre_Proveedor,
                        Telefono = @NuevoTelefono,
                        Direccion = @NuevaDireccion
                    WHERE ID_Proveedor = @ID_Proveedor;

                    SET @IdMensaje = 0;
                    SET @Mensaje = 'Proveedor modificado correctamente';
                END
            END
        END
        ELSE
        BEGIN
            SET @IdMensaje = -3;
            SET @Mensaje = 'El Proveedor no existe';
        END

        COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -4;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Delete
CREATE PROCEDURE [dbo].[EliminarProveedor](@ID_Proveedor INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION

    IF EXISTS (SELECT 1 FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor)
    BEGIN
        IF EXISTS (SELECT 1 FROM Producto WHERE ID_Proveedor = @ID_Proveedor)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se eliminó porque el Proveedor está asociado a uno o más Productos';
        END
        ELSE
        BEGIN
            DELETE FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Proveedor eliminado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Proveedor no existe';
    END

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


--CRUD Producto

--Create
CREATE PROCEDURE NuevoProducto(@Nombre_Producto NVARCHAR(100),@Descripcion NVARCHAR(100),@ID_TipoProducto INT,@Fecha_Caducidad DATE,@ID_Proveedor INT,@CostoUnitario INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT * FROM Producto WHERE Nombre_Producto = @Nombre_Producto)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'Producto ya existe con este nombre';
        END
        ELSE IF NOT EXISTS (SELECT * FROM Tipo_Producto WHERE ID_TipoProducto = @ID_TipoProducto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No existe un tipo de producto con este ID';
        END
        ELSE IF NOT EXISTS (SELECT * FROM Proveedor WHERE ID_Proveedor = @ID_Proveedor)
        BEGIN
            SET @IdMensaje = -3;
            SET @Mensaje = 'No existe un proveedor con este ID';
        END
        ELSE
        BEGIN
            INSERT INTO Producto (Nombre_Producto, Descripcion, ID_TipoProducto, Fecha_Caducidad, ID_Proveedor, CostoUnitario)
            VALUES (@Nombre_Producto, @Descripcion, @ID_TipoProducto, @Fecha_Caducidad, @ID_Proveedor, @CostoUnitario);
            
            SET @IdMensaje = 0;
            SET @Mensaje = 'Producto ingresado correctamente';
        END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Read
CREATE PROCEDURE [dbo].[ConsultaProducto](@ID_Producto INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT * FROM Producto WHERE ID_Producto = @ID_Producto)
    BEGIN
        SELECT P.ID_Producto, P.Nombre_Producto, P.Descripcion, TP.Descripcion AS Tipo_Producto,TP.ID_TipoProducto AS ID_TipoProducto, 
               P.Fecha_Caducidad, PR.Nombre_Proveedor,PR.ID_Proveedor, P.CostoUnitario
        FROM Producto P
        JOIN Tipo_Producto TP ON P.ID_TipoProducto = TP.ID_TipoProducto
        JOIN Proveedor PR ON P.ID_Proveedor = PR.ID_Proveedor
        WHERE P.ID_Producto = @ID_Producto;
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Producto no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE [dbo].[ConsultaProductoNombreTipo](@Nombre_Producto varchar(100),@Categoria varchar(200))
AS
BEGIN
    SELECT P.ID_Producto, P.Nombre_Producto, P.Descripcion, TP.Descripcion AS Tipo_Producto, PR.Nombre_Proveedor, P.Fecha_Caducidad, P.CostoUnitario
        FROM Producto P
        JOIN Tipo_Producto TP ON P.ID_TipoProducto = TP.ID_TipoProducto
        JOIN Proveedor PR ON P.ID_Proveedor = PR.ID_Proveedor
    WHERE
        ((ISNULL(@Nombre_Producto, '') <> '' AND P.Nombre_Producto LIKE '%' + @Nombre_Producto + '%') OR ISNULL(@Nombre_Producto, '') = '')
    AND
        ((ISNULL(@Categoria, '') <> '' AND TP.Descripcion LIKE '%' + @Categoria + '%') OR ISNULL(@Categoria, '') = '')
END
GO

--Update
CREATE PROCEDURE ModificarProducto(@ID_Producto INT,@NuevoNombre_Producto NVARCHAR(100),@NuevaDescripcion NVARCHAR(100),@NuevoID_TipoProducto INT,@NuevaFecha_Caducidad DATE,@NuevoID_Proveedor INT,@NuevoCostoUnitario INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION

    IF EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
    BEGIN
        IF EXISTS (SELECT 1 FROM Producto WHERE Nombre_Producto = @NuevoNombre_Producto AND ID_Producto <> @ID_Producto)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'Ya existe un producto con ese nombre';
        END
        ELSE IF NOT EXISTS (SELECT 1 FROM Tipo_Producto WHERE ID_TipoProducto = @NuevoID_TipoProducto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'El Tipo de Producto no existe';
        END
        ELSE IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE ID_Proveedor = @NuevoID_Proveedor)
        BEGIN
            SET @IdMensaje = -3;
            SET @Mensaje = 'El Proveedor no existe';
        END
        ELSE
        BEGIN
            UPDATE Producto
            SET Nombre_Producto = @NuevoNombre_Producto,
                Descripcion = @NuevaDescripcion,
                ID_TipoProducto = @NuevoID_TipoProducto,
                Fecha_Caducidad = @NuevaFecha_Caducidad,
                ID_Proveedor = @NuevoID_Proveedor,
                CostoUnitario = @NuevoCostoUnitario
            WHERE ID_Producto = @ID_Producto;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Producto modificado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -4;
        SET @Mensaje = 'El Producto no existe';
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -5;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Delete
CREATE PROCEDURE EliminarProducto(@ID_Producto INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION

    IF EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
    BEGIN
        IF EXISTS (SELECT 1 FROM Inventario WHERE ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'No se puede eliminar porque el producto está siendo utilizado en la tabla Inventario';
        END
        ELSE IF EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se puede eliminar porque el producto está siendo utilizado en la tabla DetallePedido';
        END
        ELSE
        BEGIN
            DELETE FROM Producto
            WHERE ID_Producto = @ID_Producto;
            SET @IdMensaje = 0;
            SET @Mensaje = 'Producto eliminado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -3;
        SET @Mensaje = 'El Producto no existe';
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -4;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


/**********************************************************************************/
--CRUD Cliente
/**********************************************************************************/
--Nuevo Cliente
CREATE PROCEDURE [dbo].[NuevoCliente](@Nombre_Cliente VARCHAR(100),@Telefono INT,@Direccion VARCHAR(200),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT * FROM Cliente WHERE Nombre_Cliente = @Nombre_Cliente)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'Ya existe ese cliente';
        END
        ELSE
        BEGIN
			IF EXISTS (SELECT * FROM Cliente WHERE Telefono = @Telefono)
			BEGIN 
				SET @IdMensaje = -2;
				SET @Mensaje = 'Ya existe un cliente con este Número de Telefónico';
			END
			ELSE
			BEGIN
				INSERT INTO Cliente(Nombre_Cliente, Telefono, Direccion)
				VALUES (@Nombre_Cliente, @Telefono, @Direccion);
            
				SET @IdMensaje = 0;
				SET @Mensaje = 'Cliente agregado correctamente';
			END
        END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
GO

--Consulta Cliente
CREATE PROCEDURE [dbo].[ConsultaClientesoxID]
    @ID_Cliente INT = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    IF @ID_Cliente IS NULL
    BEGIN
        -- Si no se proporciona @ID_Cliente, devuelve todos los registros
        SELECT ID_Cliente, Nombre_Cliente, Telefono, Direccion 
        FROM Cliente;
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta de todos los clientes exitosa';
    END
    ELSE IF EXISTS (SELECT 1 FROM Cliente WHERE ID_Cliente = @ID_Cliente)
    BEGIN
        -- Si se proporciona @ID_Cliente y existe, devuelve el registro específico
        SELECT ID_Cliente, Nombre_Cliente, Telefono, Direccion 
        FROM Cliente 
        WHERE ID_Cliente = @ID_Cliente;    
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta del cliente exitosa';
    END
    ELSE
    BEGIN
        -- Si se proporciona @ID_Cliente y no existe, devuelve mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'El cliente no existe en los registros.';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaClientesNombreDireccion(@Nombre_Cliente varchar(100), @Direccion varchar(200))
AS
BEGIN
	SELECT ID_Cliente, Nombre_Cliente, Telefono, Direccion FROM Cliente
	WHERE
	((isnull(@Nombre_Cliente,'')<>'' and Nombre_Cliente like '%'+ @Nombre_Cliente +'%') or isnull(@Nombre_Cliente,'')='' )
	and
	((isnull(@Direccion,'')<>'' and Direccion like  '%'+ @Direccion + '%') or isnull(@Direccion,'')='')
END 
GO

--Modificar Cliente
create PROCEDURE [dbo].[ModificarCliente](@ID_Cliente INT,@NuevoNombre_Cliente VARCHAR(100),@NuevoTelefono INT,@NuevaDireccion VARCHAR(200),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT 1 FROM Cliente WHERE ID_Cliente = @ID_Cliente)
        BEGIN
            IF EXISTS (SELECT 1 FROM Cliente WHERE Nombre_Cliente = @NuevoNombre_Cliente and ID_Cliente <> @ID_Cliente)
            BEGIN
                SET @IdMensaje = -1;
                SET @Mensaje = 'Ya existe un cliente con ese nombre';
            END
            ELSE
			BEGIN
				IF EXISTS (SELECT * FROM Cliente WHERE Telefono = @NuevoTelefono and ID_Cliente <> @ID_Cliente)
				BEGIN 
					SET @IdMensaje = -2;
					SET @Mensaje = 'Ya existe un cliente con este Número de Telefónico';
				END
				ELSE
				BEGIN
					UPDATE Cliente
					SET Nombre_Cliente = @NuevoNombre_Cliente,
						Telefono = @NuevoTelefono,
						Direccion = @NuevaDireccion
					WHERE ID_Cliente = @ID_Cliente;

					SET @IdMensaje = 0;
					SET @Mensaje = 'Cliente modificado correctamente';
				END
			END
        END
        ELSE
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'El cliente no existe';
        END

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Eliminar Cliente
CREATE PROCEDURE [dbo].[EliminarCliente]
    @ID_Cliente INT,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    BEGIN TRANSACTION
    -- Verificar si el cliente existe
    IF EXISTS (SELECT 1 FROM Cliente WHERE ID_Cliente = @ID_Cliente)
    BEGIN
        -- Verificar si el cliente está siendo utilizado en la tabla Pedido
        IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Cliente = @ID_Cliente)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se eliminó porque el cliente está asociado a un Pedido';
        END
        ELSE
        BEGIN
            DELETE FROM Cliente
            WHERE ID_Cliente = @ID_Cliente;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Cliente eliminado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El cliente no existe';
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
GO

/*****************************************************************************************/
/***********************************CRUD Empleado*****************************************/
/*****************************************************************************************/
CREATE PROCEDURE [dbo].[NuevoEmpleado]
    @Nombre_Empleado VARCHAR(100),
    @ID_TipoEmpleado INT,
    @Correo_Empleado VARCHAR(100),

    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    -- Verificar si el correo ya está registrado
    IF EXISTS (SELECT 1 FROM Empleado WHERE Correo_Empleado = @Correo_Empleado)
    BEGIN
        -- Si el correo ya existe, devolver un mensaje de error y no insertar el registro
        SET @IdMensaje = -1;
        SET @Mensaje = 'Correo ya registrado. Favor verificar los datos.';
    END
    ELSE
    BEGIN
        -- Insertar el nuevo empleado si el correo no está registrado
        INSERT INTO Empleado (Nombre_Empleado, ID_TipoEmpleado, Correo_Empleado)
        VALUES (@Nombre_Empleado, @ID_TipoEmpleado, @Correo_Empleado);

        SET @IdMensaje = 0;
        SET @Mensaje = 'Empleado creado exitosamente';
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
END CATCH
SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
GO

CREATE PROCEDURE [dbo].[ConsultaEmpleado]
    @ID_Empleado INT = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    IF @ID_Empleado IS NULL
    BEGIN
        -- Si no se proporciona @ID_Empleado, devuelve todos los registros
        SELECT e.ID_Empleado, e.Nombre_Empleado, e.ID_TipoEmpleado, te.Descripcion as Nombre_Descripcion_TE, e.Correo_Empleado
        FROM Empleado as e
		INNER JOIN
			Tipo_Empleado te ON e.ID_TipoEmpleado = te.ID_TipoEmpleado;      
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta de todos los empleados exitosa';
    END
    ELSE IF EXISTS (SELECT 1 FROM Empleado WHERE ID_Empleado = @ID_Empleado)
    BEGIN
        -- Si se proporciona @ID_Empleado y existe, devuelve el registro espec�fico
        SELECT e.ID_Empleado, e.Nombre_Empleado, e.ID_TipoEmpleado, te.Descripcion as Nombre_Descripcion_TE, e.Correo_Empleado
        FROM Empleado as e
		INNER JOIN
			Tipo_Empleado te ON e.ID_TipoEmpleado = te.ID_TipoEmpleado
        WHERE ID_Empleado = @ID_Empleado;

        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        -- Si se proporciona @ID_Empleado y no existe, devuelve mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'El empleado no existe en los registros';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

create PROCEDURE [dbo].[ConsultaEmpleadosPorNombreCorreo]
    @Nombre_Empleado varchar(100) = NULL,
    @Correo_Empleado nvarchar(100) = NULL
AS
BEGIN
    SELECT e.ID_Empleado, e.Nombre_Empleado, e.ID_TipoEmpleado, te.Descripcion as Nombre_Descripcion_TE, e.Correo_Empleado
        FROM Empleado as e
		INNER JOIN
			Tipo_Empleado te ON e.ID_TipoEmpleado = te.ID_TipoEmpleado
    WHERE
        (@Nombre_Empleado IS NULL OR e.Nombre_Empleado LIKE '%' + @Nombre_Empleado + '%')
    AND
        (@Correo_Empleado IS NULL OR e.Correo_Empleado LIKE '%' + @Correo_Empleado + '%')
END
GO

CREATE PROCEDURE [dbo].[ModificarEmpleado]
    @ID_Empleado INT,
    @Nombre_Empleado VARCHAR(100),
    @ID_TipoEmpleado INT,
    @Correo_Empleado VARCHAR(100),
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN TRY
    -- Verificar si el empleado existe
    IF EXISTS (SELECT 1 FROM Empleado WHERE ID_Empleado = @ID_Empleado)
    BEGIN
        -- Verificar si el correo ya está registrado por otro empleado
        IF EXISTS (SELECT 1 FROM Empleado WHERE Correo_Empleado = @Correo_Empleado AND ID_Empleado <> @ID_Empleado)
        BEGIN
            -- Si el correo ya existe y pertenece a otro empleado, devolver un mensaje de error
            SET @IdMensaje = -2;
            SET @Mensaje = 'Correo ya registrado por otro empleado. Favor verificar los datos.';
        END
        ELSE
        BEGIN
            -- Actualizar el empleado si el correo no está registrado por otro empleado
            UPDATE Empleado
            SET 
                Nombre_Empleado = @Nombre_Empleado,
                ID_TipoEmpleado = @ID_TipoEmpleado,
                Correo_Empleado = @Correo_Empleado
            WHERE 
                ID_Empleado = @ID_Empleado;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Actualización de datos del empleado exitosa.';
        END
    END
    ELSE
    BEGIN
        -- Si el empleado no existe, devolver un mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'El empleado no existe en los registros. Favor verificar la información.';
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
END CATCH
SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
GO

CREATE PROCEDURE [dbo].[EliminarEmpleado]
    @ID_Empleado INT,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    BEGIN TRANSACTION

    -- Verifica si el empleado existe
    IF EXISTS (SELECT 1 FROM Empleado WHERE ID_Empleado = @ID_Empleado)
    BEGIN
        -- Verifica si el empleado está relacionado con algún pedido
        IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Empleado = @ID_Empleado)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se puede eliminar el empleado porque está relacionado con uno o más pedidos';
        END
        ELSE
        BEGIN
            -- Si no está relacionado, procede con la eliminación
            DELETE FROM Empleado
            WHERE ID_Empleado = @ID_Empleado;

            SET @IdMensaje = 0;
            SET @Mensaje = 'Empleado eliminado correctamente';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El empleado no existe';
    END

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
GO

/*****************************************************************************************/
/***********************************CRUD Inventario*****************************************/
/*****************************************************************************************/

--NuevoInventario
CREATE PROCEDURE NuevoInventario (@ID_Sucursal INT, @ID_Producto INT, @Cantidad INT, @Estado BIT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF NOT EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'No existe una sucursal con este ID';
        END
        ELSE IF NOT EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No existe un producto con este ID';
        END
        ELSE IF EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto AND Estado = 0)
        BEGIN
			DECLARE @IdMensajeTemp INT;
            DECLARE @MensajeTemp VARCHAR(250);

			EXEC ModificarInventarioAgregar @ID_Sucursal, @ID_Producto, @Cantidad, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;

			IF @IdMensajeTemp <> 0
            BEGIN
                SET @IdMensaje = @IdMensajeTemp;
                SET @Mensaje = @MensajeTemp;
                ROLLBACK TRANSACTION;
                RETURN;
            END

			SET @IdMensaje = 0;
			SET @Mensaje = 'Inventario agregado correctamente';
        END
		ELSE
		BEGIN
			IF EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto)
			BEGIN
				SET @IdMensaje = -4;
				SET @Mensaje = 'Ya existe un inventario para esta sucursal y producto';
			END
			ELSE
			BEGIN
				INSERT INTO Inventario(ID_Sucursal, ID_Producto, Cantidad, Estado)
				VALUES (@ID_Sucursal, @ID_Producto, @Cantidad, @Estado);

				SET @IdMensaje = 0;
				SET @Mensaje = 'Inventario creado correctamente';
			END
		END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Consultar Inventario
CREATE PROCEDURE ConsultaInventario
    @ID_Inventario INT = NULL
AS
BEGIN
    IF @ID_Inventario IS NULL
    BEGIN
        SELECT * FROM Inventario;
    END
    ELSE
    BEGIN
        SELECT * FROM Inventario WHERE ID_Inventario = @ID_Inventario;
    END
END
GO

CREATE PROCEDURE [dbo].[ConsultaInventarioxSucursal]
    @ID_Sucursal INT = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    SELECT 
        i.ID_Inventario,
        i.ID_Sucursal,
		s.Nombre_Sucursal AS Nombre_Sucursal,
        i.ID_Producto,
		p.Nombre_Producto AS Nombre_Producto,
		p.CostoUnitario,
        i.Cantidad,
		i.Estado
    FROM 
        Inventario i
    INNER JOIN 
        Producto p ON i.ID_Producto = p.ID_Producto
    INNER JOIN
        Sucursal s ON i.ID_Sucursal = s.ID_Sucursal
    WHERE 
        i.ID_Sucursal = @ID_Sucursal;
    
    SET @IdMensaje = 0;
    SET @Mensaje = 'Consulta de inventario exitosa';
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
END CATCH
GO

CREATE PROCEDURE [dbo].[ConsultaInventarioxSucursalProducto]
    @ID_Sucursal INT = NULL,
    @Nombre_Producto VARCHAR(100) = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    -- Consulta de inventario basada en los criterios proporcionados
    DECLARE @InventarioTemp TABLE (
        ID_Inventario INT,
        ID_Sucursal INT,
        Nombre_Sucursal VARCHAR(100),
        ID_Producto INT,
        Nombre_Producto VARCHAR(100),
        CostoUnitario int,
        Cantidad INT,
        Estado BIT
    );

    INSERT INTO @InventarioTemp
    SELECT 
        i.ID_Inventario,
        i.ID_Sucursal,
        s.Nombre_Sucursal AS Nombre_Sucursal,
        i.ID_Producto,
        p.Nombre_Producto AS Nombre_Producto,
        p.CostoUnitario,
        i.Cantidad,
        i.Estado
    FROM 
        Inventario i
    INNER JOIN 
        Producto p ON i.ID_Producto = p.ID_Producto
    INNER JOIN
        Sucursal s ON i.ID_Sucursal = s.ID_Sucursal
    WHERE 
        (@ID_Sucursal IS NULL OR i.ID_Sucursal = @ID_Sucursal)
        AND
		((ISNULL(@Nombre_Producto, '') <> '' AND  p.Nombre_Producto LIKE '%' + @Nombre_Producto + '%') 
        OR ISNULL(@Nombre_Producto, '') = '');


    SET @IdMensaje = 0;
    SET @Mensaje = 'Consulta de inventario exitosa.';
        
    -- Devolver los resultados de la consulta
    SELECT * FROM @InventarioTemp;
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
END CATCH
GO

--Eliminar Inventario
CREATE PROCEDURE [dbo].[EliminarInventario]
    @ID_Inventario INT,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    -- Verificar si el registro existe
    IF EXISTS (SELECT 1 FROM Inventario WHERE ID_Inventario = @ID_Inventario)
    BEGIN
        DECLARE @CantidadActual INT;
        
        -- Obtener la cantidad actual del inventario
        SELECT @CantidadActual = Cantidad 
        FROM Inventario 
        WHERE ID_Inventario = @ID_Inventario;
        
        -- Verificar si la cantidad es 0
        IF @CantidadActual = 0
        BEGIN
            -- Actualizar el estado a False (0) en lugar de eliminar
            UPDATE Inventario
            SET Estado = 0
            WHERE ID_Inventario = @ID_Inventario;
            
            SET @IdMensaje = 0;
            SET @Mensaje = 'Registro de inventario eliminado exitosamente';
        END
        ELSE
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No se puede eliminar porque la cantidad en stock no es 0';
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'No existe un Inventario con ese ID';
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
END CATCH
SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje;
GO

--CRUD Inventario
--Update
CREATE PROCEDURE ModificarInventarioAgregar (@ID_Sucursal INT, @ID_Producto INT, @CantidadPorAgregar INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
	BEGIN TRANSACTION

    -- Verificar que la sucursal existe
    IF NOT EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'No existe una Sucursal con este ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que el producto existe
    IF NOT EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
    BEGIN
        SET @IdMensaje = -2;
        SET @Mensaje = 'No existe un Producto con este ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que la sucursal tiene un inventario registrado
    IF NOT EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        SET @IdMensaje = -4;
        SET @Mensaje = 'La Sucursal con este ID no tiene un Inventario Registrado';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que la sucursal tiene el producto registrado en su inventario
    IF NOT EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto)
    BEGIN
        SET @IdMensaje = -5;
        SET @Mensaje = 'La Sucursal ingresada no tiene registrado en su Inventario un Producto con ese ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Obtener la cantidad actual del inventario y sumar la cantidad a agregar
    DECLARE @CantidadActual INT;
    DECLARE @NuevaCantidad INT;
    DECLARE @EstadoActual BIT;
    
    SELECT @CantidadActual = Cantidad, @EstadoActual = Estado
    FROM Inventario 
    WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto;
    
    SET @NuevaCantidad = @CantidadActual + @CantidadPorAgregar;
    
    -- Actualizar el inventario y el estado si es necesario
    UPDATE Inventario
    SET Cantidad = @NuevaCantidad,
        Estado = CASE WHEN @EstadoActual = 0 THEN 1 ELSE @EstadoActual END
    WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto;
    
    SET @IdMensaje = 0;
    SET @Mensaje = 'Se agregó la cantidad solicitada al Inventario correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

CREATE PROCEDURE ModificarInventarioRestar (@ID_Sucursal INT, @ID_Producto INT, @CantidadPorEliminar INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION

    -- Verificar que la sucursal existe
    IF NOT EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'No existe una Sucursal con este ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que el producto existe
    IF NOT EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
    BEGIN
        SET @IdMensaje = -2;
        SET @Mensaje = 'No existe un Producto con este ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que la sucursal tiene un inventario registrado
    IF NOT EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        SET @IdMensaje = -4;
        SET @Mensaje = 'La Sucursal con este ID no tiene un Inventario Registrado';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Verificar que la sucursal tiene el producto registrado en su inventario
    IF NOT EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto)
    BEGIN
        SET @IdMensaje = -5;
        SET @Mensaje = 'La Sucursal ingresada no tiene registrado en su Inventario un Producto con ese ID';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Obtener la cantidad actual del inventario y restar la cantidad a eliminar
    DECLARE @CantidadActual INT;
    DECLARE @NuevaCantidad INT;
    
    SELECT @CantidadActual = Cantidad 
    FROM Inventario 
    WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto;
    
    SET @NuevaCantidad = @CantidadActual - @CantidadPorEliminar;
    
    -- Verificar que la nueva cantidad no sea menor a cero
    IF @NuevaCantidad < 0
    BEGIN
        SET @IdMensaje = -6;
        SET @Mensaje = 'No hay suficiente Producto en el Inventario para eliminar la cantidad solicitada';
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Actualizar el inventario
    UPDATE Inventario
    SET Cantidad = @NuevaCantidad
    WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto;
    
    SET @IdMensaje = 0;
    SET @Mensaje = 'Se resto la cantidad solicitada del Inventario correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--CRUD Pedido
--Create
CREATE PROCEDURE NuevoPedido (@Fecha_Creacion DATE, @ID_Cliente INT, @ID_Empleado INT, @Estado_Orden BIT, @Fecha_Envio DATE, @MontoTotal INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT, @ID_Pedido INT OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        -- Verificar que el cliente existe
        IF NOT EXISTS (SELECT 1 FROM Cliente WHERE ID_Cliente = @ID_Cliente)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'No existe un cliente con este ID';
            SET @ID_Pedido = -1;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar que el empleado existe
        IF NOT EXISTS (SELECT 1 FROM Empleado WHERE ID_Empleado = @ID_Empleado)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No existe un empleado con este ID';
            SET @ID_Pedido = -1;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar el nuevo pedido
        INSERT INTO Pedido (Fecha_Creacion, ID_Cliente, ID_Empleado, Estado_Orden, Fecha_Envio, MontoTotal)
        VALUES (@Fecha_Creacion, @ID_Cliente, @ID_Empleado, @Estado_Orden, @Fecha_Envio, @MontoTotal);

        -- Obtener el ID del nuevo pedido
        SET @ID_Pedido = SCOPE_IDENTITY();
        
        -- Establecer mensajes de éxito
        SET @IdMensaje = 0;
        SET @Mensaje = 'Pedido creado correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    -- Manejo de errores
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SET @ID_Pedido = -1;
    ROLLBACK TRANSACTION;
END CATCH

-- Devolver los mensajes y el ID del pedido
SELECT @IdMensaje AS IdMensaje, @Mensaje AS Mensaje, @ID_Pedido AS ID_Pedido;
GO

--Read
CREATE PROCEDURE ConsultaPedido (@ID_Pedido INT = NULL, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF @ID_Pedido IS NULL
    BEGIN
        -- Si no se proporciona @ID_Pedido, devuelve todos los registros
        SELECT 
			P.ID_Pedido, 
			P.Fecha_Creacion, 
			P.ID_Cliente, 
			C.Nombre_Cliente, 
			P.ID_Empleado, 
			E.Nombre_Empleado, 
			P.Estado_Orden, 
			P.Fecha_Envio, 
			P.MontoTotal  
		FROM
			Pedido P
		JOIN
			Cliente C ON P.ID_Cliente = C.ID_Cliente
		JOIN
			Empleado E ON P.ID_Empleado = E.ID_Empleado; 
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta de todos los pedidos exitosa';
    END
    ELSE IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
    BEGIN
        -- Si se proporciona @ID_Pedido y existe, devuelve el registro específico
        SELECT 
			P.ID_Pedido, 
			P.Fecha_Creacion, 
			P.ID_Cliente, 
			C.Nombre_Cliente, 
			P.ID_Empleado, 
			E.Nombre_Empleado, 
			P.Estado_Orden, 
			P.Fecha_Envio, 
			P.MontoTotal  
		FROM 
			Pedido P
		JOIN 
			Cliente C ON P.ID_Cliente = C.ID_Cliente
		JOIN 
			Empleado E ON P.ID_Empleado = E.ID_Empleado
		WHERE
			ID_Pedido = @ID_Pedido;
		
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        -- Si se proporciona @ID_Pedido y no existe, devuelve mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Pedido no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaPedidosClienteEmpleado(
    @Nombre_Cliente VARCHAR(100),
    @Nombre_Empleado VARCHAR(100)
)
AS
BEGIN
    SELECT 
        P.ID_Pedido, 
        P.Fecha_Creacion, 
        P.ID_Cliente, 
        C.Nombre_Cliente, 
        P.ID_Empleado, 
        E.Nombre_Empleado, 
        P.Estado_Orden, 
        P.Fecha_Envio, 
        P.MontoTotal  
    FROM 
        Pedido P
    JOIN
        Cliente C ON P.ID_Cliente = C.ID_Cliente
    JOIN 
        Empleado E ON P.ID_Empleado = E.ID_Empleado
    WHERE
        ((ISNULL(@Nombre_Cliente, '') <> '' AND C.Nombre_Cliente LIKE '%' + @Nombre_Cliente + '%') 
        OR ISNULL(@Nombre_Cliente, '') = '')
    AND
        ((ISNULL(@Nombre_Empleado, '') <> '' AND E.Nombre_Empleado LIKE '%' + @Nombre_Empleado + '%') 
        OR ISNULL(@Nombre_Empleado, '') = '')
END
GO

CREATE PROCEDURE ConsultaReportePedido (@ID_Pedido INT = NULL)
AS
BEGIN
    SELECT 
		P.ID_Pedido, 
		P.Fecha_Creacion, 
		P.ID_Cliente, 
		C.Nombre_Cliente, 
		P.ID_Empleado, 
		E.Nombre_Empleado, 
		P.Estado_Orden, 
		P.Fecha_Envio, 
		P.MontoTotal  
	FROM 
		Pedido P
	JOIN 
		Cliente C ON P.ID_Cliente = C.ID_Cliente
	JOIN 
		Empleado E ON P.ID_Empleado = E.ID_Empleado
	WHERE
		ID_Pedido = @ID_Pedido;
END
GO

--Update
CREATE PROCEDURE ModificarPedido(@ID_Pedido int, @ID_Cliente INT, @ID_Empleado INT, @Estado_Orden Bit, @Fecha_Envio DATE, @MontoTotal INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
    -- Verificar si el pedido existe y si el Estado_Orden está activo (verdadero o 1)
    IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido AND Estado_Orden = 1)
    BEGIN
		IF NOT EXISTS (SELECT 1 FROM Cliente WHERE ID_Cliente = @ID_Cliente)
		BEGIN
			SET @IdMensaje = -4;
			SET @Mensaje = 'No existe un Cliente con este ID';
		END
		ELSE
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM Empleado WHERE ID_Empleado = @ID_Empleado)
			BEGIN
				SET @IdMensaje = -5;
				SET @Mensaje = 'No existe un Empleado con este ID';
			END
			ELSE
			BEGIN
				UPDATE Pedido
				SET ID_Cliente = @ID_Cliente,
					ID_Empleado = @ID_Empleado,
					Estado_Orden = @Estado_Orden,
					Fecha_Envio = @Fecha_Envio,
					MontoTotal = @MontoTotal
				WHERE ID_Pedido = @ID_Pedido;

				SET @IdMensaje = 0;
				SET @Mensaje = 'Pedido modificado correctamente';
			END
		END
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'El Pedido no existe';
        END
        ELSE
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No es posible modificar un Pedido inactivo';
        END
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

CREATE PROCEDURE ModificarMontoTotalPedido(@ID_Pedido int, @MontoTotal INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
    -- Verificar si el pedido existe y si el Estado_Orden está activo (verdadero o 1)
    IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido AND Estado_Orden = 1)
    BEGIN
		UPDATE Pedido
		SET MontoTotal = @MontoTotal
		WHERE ID_Pedido = @ID_Pedido;

		SET @IdMensaje = 0;
		SET @Mensaje = 'MontoTotal del Pedido modificado correctamente';
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'El Pedido no existe';
        END
        ELSE
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No es posible modificar un Pedido inactivo';
        END
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Delete
CREATE PROCEDURE EliminarPedido(@ID_Pedido INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        -- Declaración de variables
        DECLARE @EstadoPedido BIT;
        DECLARE @ID_Producto INT;
        DECLARE @ID_Sucursal INT;
        DECLARE @Cantidad INT;
        DECLARE @IdMensajeTemp INT;
        DECLARE @MensajeTemp VARCHAR(250);

        -- Verificar si el pedido existe
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
        BEGIN
            -- El pedido no existe
            SET @IdMensaje = -1;
            SET @Mensaje = 'El Pedido no existe';
        END
		ELSE
		BEGIN
			-- Verificar si el pedido tiene DetallePedio asociados
			IF NOT EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Pedido = @ID_Pedido)
			BEGIN
				-- Eliminar solamente el pedido ya que este no tenía lineas de Detalle asociadas
				DELETE FROM Pedido
				WHERE ID_Pedido = @ID_Pedido;

				SET @IdMensaje = 0;
				SET @Mensaje = 'Pedido sin DetallePedido asociado eliminado correctamente';
			END
			ELSE
			BEGIN
				-- Obtener el estado del pedido
				SELECT @EstadoPedido = Estado_Orden
				FROM Pedido
				WHERE ID_Pedido = @ID_Pedido;

				-- Reponer el stock si el pedido está activo (Estado_Orden = 1)
				IF @EstadoPedido = 1
				BEGIN
					DECLARE detalle_cursor CURSOR FOR
					SELECT ID_Producto, ID_Sucursal, Cantidad
					FROM DetallePedido
					WHERE ID_Pedido = @ID_Pedido;

					OPEN detalle_cursor;
					FETCH NEXT FROM detalle_cursor INTO @ID_Producto, @ID_Sucursal, @Cantidad;

					WHILE @@FETCH_STATUS = 0
					BEGIN
						-- Llamar al procedimiento para agregar el stock
						EXEC ModificarInventarioAgregar @ID_Sucursal, @ID_Producto, @Cantidad, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;
                    
						-- Verificar si hubo un error al modificar el inventario
						IF @IdMensajeTemp <> 0
						BEGIN
							SET @IdMensaje = @IdMensajeTemp;
							SET @Mensaje = @MensajeTemp;
							ROLLBACK TRANSACTION;
							CLOSE detalle_cursor;
							DEALLOCATE detalle_cursor;
							RETURN;
						END
                    
						FETCH NEXT FROM detalle_cursor INTO @ID_Producto, @ID_Sucursal, @Cantidad;
					END
                
					CLOSE detalle_cursor;
					DEALLOCATE detalle_cursor;
				END

				-- Eliminar los detalles del pedido
				DELETE FROM DetallePedido
				WHERE ID_Pedido = @ID_Pedido;

				-- Eliminar el pedido
				DELETE FROM Pedido
				WHERE ID_Pedido = @ID_Pedido;

				SET @IdMensaje = 0;
				SET @Mensaje = 'Pedido y Detalles pedido asociados eliminados correctamente';
			END 
		END	       
        COMMIT TRANSACTION
END TRY
BEGIN CATCH
    -- Manejo de errores
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO



--CRUD Detalle Pedido
--Create
CREATE PROCEDURE NuevoDetallePedido(@ID_Pedido INT, @Cantidad INT, @ID_Producto INT, @ID_Sucursal INT, @Monto INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        -- Verificar si el pedido existe
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'No existe un Pedido con este ID';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar si el producto existe
        IF NOT EXISTS (SELECT 1 FROM Producto WHERE ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No existe un Producto con este ID';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar si la sucursal existe
        IF NOT EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
        BEGIN
            SET @IdMensaje = -4;
            SET @Mensaje = 'No existe una Sucursal con este ID';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar si el producto está disponible en la sucursal
        IF NOT EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal AND ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -5;
            SET @Mensaje = 'El producto seleccionado no está disponible en esta sucursal';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar la cantidad disponible
        DECLARE @CantidadDisponible INT;
        SELECT @CantidadDisponible = Cantidad 
        FROM Inventario 
        WHERE ID_Producto = @ID_Producto AND ID_Sucursal = @ID_Sucursal;

        IF @CantidadDisponible IS NULL OR @CantidadDisponible < @Cantidad
        BEGIN
            SET @IdMensaje = -6;
            SET @Mensaje = 'No hay suficiente producto en inventario';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar si ya existe un detalle de pedido para el mismo producto
        IF EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Pedido = @ID_Pedido AND ID_Producto = @ID_Producto)
        BEGIN
            SET @IdMensaje = -7;
            SET @Mensaje = 'Ya existe un DetallePedido de ese Producto en ese Pedido';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Modificar el stock
        DECLARE @IdMensajeTemp INT;
        DECLARE @MensajeTemp VARCHAR(250);

        EXEC ModificarInventarioRestar @ID_Sucursal, @ID_Producto, @Cantidad, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;

        -- Verificar si hubo un error al modificar el inventario
        IF @IdMensajeTemp <> 0
        BEGIN
            SET @IdMensaje = @IdMensajeTemp;
            SET @Mensaje = @MensajeTemp;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar el nuevo detalle del pedido
        INSERT INTO DetallePedido(ID_Pedido, Cantidad, ID_Producto, ID_Sucursal, Monto)
        VALUES (@ID_Pedido, @Cantidad, @ID_Producto, @ID_Sucursal, @Monto);

        SET @IdMensaje = 0;
        SET @Mensaje = 'DetallePedido creado correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Read
CREATE PROCEDURE ConsultaDetallesPedidoxPedido(@ID_Pedido INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT 1 FROM Pedido WHERE ID_Pedido = @ID_Pedido)
    BEGIN	
		SELECT 
			DP.ID_Detalle, 
			DP.ID_Pedido, 
			DP.Cantidad, 
			DP.ID_Producto,
			P.Nombre_Producto, 
			DP.ID_Sucursal, 
			S.Nombre_Sucursal,
			DP.Monto
		FROM
			DetallePedido DP
		JOIN
			Producto P ON DP.ID_Producto = P.ID_Producto
		JOIN
			Sucursal S ON DP.ID_Sucursal = S.ID_Sucursal
		WHERE ID_Pedido = @ID_Pedido;

        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Pedido no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH
GO

CREATE PROCEDURE ConsultaDetallePedidoxID(@ID_Detalle INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    IF EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Detalle = @ID_Detalle)
    BEGIN
        SELECT 
			DP.ID_Detalle, 
			DP.ID_Pedido, 
			DP.Cantidad, 
			DP.ID_Producto,
			P.Nombre_Producto, 
			DP.ID_Sucursal, 
			S.Nombre_Sucursal,
			DP.Monto
		FROM
			DetallePedido DP
		JOIN
			Producto P ON DP.ID_Producto = P.ID_Producto
		JOIN
			Sucursal S ON DP.ID_Sucursal = S.ID_Sucursal
		WHERE ID_Detalle = @ID_Detalle; 
		
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El DetallePedido no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH
GO

CREATE PROCEDURE ConsultaDetallesPedidoProductoSucursal(
	@ID_Pedido INT,
    @Nombre_Producto VARCHAR(100),
    @Nombre_Sucursal VARCHAR(100)
)
AS
BEGIN
    SELECT 
		DP.ID_Detalle, 
		DP.ID_Pedido, 
		DP.Cantidad, 
		DP.ID_Producto,
		P.Nombre_Producto, 
		DP.ID_Sucursal, 
		S.Nombre_Sucursal,
		DP.Monto
	FROM
		DetallePedido DP
	JOIN
		Producto P ON DP.ID_Producto = P.ID_Producto
	JOIN
		Sucursal S ON DP.ID_Sucursal = S.ID_Sucursal
	WHERE
		ID_Pedido = @ID_Pedido
	AND
        ((ISNULL(@Nombre_Producto, '') <> '' AND P.Nombre_Producto LIKE '%' + @Nombre_Producto + '%') 
        OR ISNULL(@Nombre_Producto, '') = '')
    AND
        ((ISNULL(@Nombre_Sucursal, '') <> '' AND S.Nombre_Sucursal LIKE '%' + @Nombre_Sucursal + '%') 
        OR ISNULL(@Nombre_Sucursal, '') = '')
END
GO

--Update
CREATE PROCEDURE ModificarDetallePedido(@ID_Detalle INT, @Cantidad INT, @Monto INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        -- Declaración de variables
        DECLARE @CantidadAnterior INT;
        DECLARE @ID_Pedido INT;
        DECLARE @ID_Producto INT;
        DECLARE @ID_Sucursal INT;
        DECLARE @CantidadDisponible INT;
        DECLARE @EstadoPedido BIT;
        DECLARE @DiferenciaCantidad INT;

        -- Verificar si el detalle del pedido existe
        IF NOT EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Detalle = @ID_Detalle)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'No existe un DetallePedido con este ID';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Obtener detalles del pedido y del producto
        SELECT @CantidadAnterior = Cantidad, 
               @ID_Pedido = ID_Pedido, 
               @ID_Producto = ID_Producto, 
               @ID_Sucursal = ID_Sucursal
        FROM DetallePedido
        WHERE ID_Detalle = @ID_Detalle;

        -- Verificar si el pedido está activo
        SELECT @EstadoPedido = Estado_Orden
        FROM Pedido
        WHERE ID_Pedido = @ID_Pedido;

        IF @EstadoPedido = 0
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No es posible modificar un DetallePedido de un Pedido inactivo';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar la cantidad disponible en el inventario
        SELECT @CantidadDisponible = Cantidad 
        FROM Inventario 
        WHERE ID_Producto = @ID_Producto AND ID_Sucursal = @ID_Sucursal;

        SET @CantidadDisponible = @CantidadDisponible + @CantidadAnterior;

        IF @CantidadDisponible < @Cantidad
        BEGIN
            SET @IdMensaje = -4;
            SET @Mensaje = 'No hay suficiente producto en el inventario';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Modificar el inventario si la cantidad ha cambiado
        IF @Cantidad != @CantidadAnterior
        BEGIN
            -- Declarar variables para los mensajes temporales
            DECLARE @IdMensajeTemp INT;
            DECLARE @MensajeTemp VARCHAR(250);

            -- Si la nueva cantidad es menor que la anterior, se agrega al inventario
            IF @Cantidad < @CantidadAnterior
            BEGIN
                SET @DiferenciaCantidad = @CantidadAnterior - @Cantidad;
                -- Llamar al procedimiento para agregar la diferencia de cantidad al inventario
                EXEC ModificarInventarioAgregar @ID_Sucursal, @ID_Producto, @DiferenciaCantidad, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;
            END
            ELSE
            BEGIN
                -- Si la nueva cantidad es mayor que la anterior, se resta del inventario
                SET @DiferenciaCantidad = @Cantidad - @CantidadAnterior;
                -- Llamar al procedimiento para restar la diferencia de cantidad del inventario
                EXEC ModificarInventarioRestar @ID_Sucursal, @ID_Producto, @DiferenciaCantidad, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;
            END

            -- Verificar si hubo un error al modificar el inventario
            IF @IdMensajeTemp <> 0
            BEGIN
                SET @IdMensaje = @IdMensajeTemp;
                SET @Mensaje = @MensajeTemp;
                ROLLBACK TRANSACTION;
                RETURN;
            END
        END

        -- Actualizar el detalle del pedido
        UPDATE DetallePedido
        SET Cantidad = @Cantidad,
            Monto = @Monto
        WHERE ID_Detalle = @ID_Detalle;

        SET @IdMensaje = 0;
        SET @Mensaje = 'DetallePedido modificado correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


--Delete
CREATE PROCEDURE EliminarDetallePedido(@ID_Detalle INT, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        -- Declarar variables para almacenar datos del detalle del pedido
        DECLARE @CantidadDevuelta INT;
        DECLARE @ID_Pedido INT;
        DECLARE @ID_Producto INT;
        DECLARE @ID_Sucursal INT;
        DECLARE @EstadoPedido BIT;
        DECLARE @IdMensajeTemp INT;
        DECLARE @MensajeTemp VARCHAR(250);

        -- Verificar si el detalle del pedido existe
        IF NOT EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Detalle = @ID_Detalle)
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'El DetallePedido no existe';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Obtener los datos del detalle del pedido
        SELECT @CantidadDevuelta = Cantidad, @ID_Pedido = ID_Pedido, @ID_Producto = ID_Producto, @ID_Sucursal = ID_Sucursal
        FROM DetallePedido
        WHERE ID_Detalle = @ID_Detalle;

        -- Verificar el estado del pedido
        SELECT @EstadoPedido = Estado_Orden
        FROM Pedido
        WHERE ID_Pedido = @ID_Pedido;

        -- Verificar si el pedido está inactivo
        IF @EstadoPedido = 0
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'No es posible eliminar un DetallePedido de un Pedido inactivo';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Modificar el stock
        EXEC ModificarInventarioAgregar @ID_Sucursal, @ID_Producto, @CantidadDevuelta, @IdMensajeTemp OUTPUT, @MensajeTemp OUTPUT;

        -- Verificar si hubo un error al modificar el inventario
        IF @IdMensajeTemp <> 0
        BEGIN
            SET @IdMensaje = @IdMensajeTemp;
            SET @Mensaje = @MensajeTemp;
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Eliminar el detalle del pedido
        DELETE FROM DetallePedido
        WHERE ID_Detalle = @ID_Detalle;

        -- Configurar el mensaje de éxito
        SET @IdMensaje = 0;
        SET @Mensaje = 'DetallePedido eliminado correctamente';

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    -- Manejo de errores
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

-- Devolver el mensaje final
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


--CRUD Sucursal
--Create
CREATE PROCEDURE NuevaSucursal(@Nombre_Sucursal VARCHAR(100), @Telefono INT, @Descripcion VARCHAR(200), @Estado bit, @IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT * FROM Sucursal WHERE Nombre_Sucursal = @Nombre_Sucursal)
        BEGIN 
            SET @IdMensaje = -1;
            SET @Mensaje = 'Ya existe esa sucursal';
        END
        ELSE
		BEGIN
			IF EXISTS (SELECT * FROM Sucursal WHERE Telefono = @Telefono)
			BEGIN 
				SET @IdMensaje = -2;
				SET @Mensaje = 'Ya existe una sucursal con este Número Telefónico';
			END
			ELSE
			BEGIN
				INSERT INTO Sucursal (Nombre_Sucursal, Telefono, Descripcion, Estado)
				VALUES (@Nombre_Sucursal, @Telefono, @Descripcion, @Estado);
            
				SET @IdMensaje = 0;
				SET @Mensaje = 'Sucursal agregada correctamente';
			END
		END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Read
CREATE PROCEDURE [dbo].[ConsultaSucursal]
    @ID_Sucursal INT = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    IF @ID_Sucursal IS NULL
    BEGIN
        -- Si no se proporciona @ID_Sucursal, devuelve todos los registros
        SELECT ID_Sucursal, Nombre_Sucursal, Telefono, Descripcion, Estado FROM Sucursal;
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta de todas las sucursales exitosa';
    END
    ELSE IF EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        -- Si se proporciona @ID_Sucursal y existe, devuelve el registro específico
        SELECT ID_Sucursal, Nombre_Sucursal, Telefono, Descripcion, Estado FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal;    
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        -- Si se proporciona @ID_Sucursal y no existe, devuelve mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'La sucursal no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaSucursalesNombreDescripcion(@Nombre_Sucursal varchar(100), @Descripcion varchar(200))
AS
BEGIN
	SELECT ID_Sucursal, Nombre_Sucursal, Telefono, Descripcion, Estado FROM Sucursal
	WHERE
	((isnull(@Nombre_Sucursal,'')<>'' and Nombre_Sucursal like '%'+ @Nombre_Sucursal +'%') or isnull(@Nombre_Sucursal,'')='' )
	and
	((isnull(@Descripcion,'')<>'' and Descripcion like  '%'+ @Descripcion + '%') or isnull(@Descripcion,'')='')
END
GO


--Update
CREATE PROCEDURE ModificarSucursal (@ID_Sucursal INT, @Nombre_Sucursal VARCHAR(100), @Telefono INT, @Descripcion VARCHAR(200), @Estado BIT, @IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
    -- Verificar si la sucursal a modificar existe
    IF EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
        -- Verificar si el nuevo nombre de la sucursal ya existe en otra sucursal
        IF EXISTS (SELECT 1 FROM Sucursal WHERE Nombre_Sucursal = @Nombre_Sucursal AND ID_Sucursal <> @ID_Sucursal)
        BEGIN
            SET @IdMensaje = -2;
            SET @Mensaje = 'El nombre de la sucursal ya existe en otra sucursal';
        END
        ELSE
        BEGIN
			IF EXISTS (SELECT * FROM Sucursal WHERE Telefono = @Telefono AND ID_Sucursal <> @ID_Sucursal)
			BEGIN 
				SET @IdMensaje = -4;
				SET @Mensaje = 'Ya existe una sucursal con este Número Telefónico';
			END
			ELSE
			BEGIN
				-- Realizar la actualización si el nombre no está duplicado
				UPDATE Sucursal
				SET Nombre_Sucursal = @Nombre_Sucursal, 
					Telefono = @Telefono, 
					Descripcion = @Descripcion, 
					Estado = @Estado
				WHERE ID_Sucursal = @ID_Sucursal;

				SET @IdMensaje = 0;
				SET @Mensaje = 'Sucursal modificada correctamente';
			END
        END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'La sucursal no existe';
    END

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH

SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


--Delete
CREATE PROCEDURE EliminarSucursal(@ID_Sucursal INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
    IF EXISTS (SELECT 1 FROM Sucursal WHERE ID_Sucursal = @ID_Sucursal)
    BEGIN
		IF EXISTS (SELECT 1 FROM Inventario WHERE ID_Sucursal = @ID_Sucursal)
		BEGIN
			SET @IdMensaje = -2;
			SET @Mensaje = 'No se eliminó porque la Sucursal está asociada a un Inventario';
		END
		ELSE
		BEGIN
			IF EXISTS (SELECT 1 FROM DetallePedido WHERE ID_Sucursal = @ID_Sucursal)
			BEGIN
				SET @IdMensaje = -4;
				SET @Mensaje = 'No se eliminó porque la Sucursal está asociada a un DetallePedido';
			END
			ELSE
			BEGIN
			    DELETE FROM Sucursal
				WHERE ID_Sucursal = @ID_Sucursal;

				SET @IdMensaje = 0;
				SET @Mensaje = 'Sucursal eliminada correctamente';
			END
		END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'La Sucursal no existe';
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO


--CRUD Tipo_Empleado
--Create
CREATE PROCEDURE NuevoTipoEmpleado(@Descripcion VARCHAR(100),@IdMensaje INT OUTPUT, @Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		IF EXISTS (SELECT * FROM Tipo_Empleado WHERE Descripcion= @Descripcion)
			BEGIN 
				SET @IdMensaje = -1
				SET @Mensaje = 'Ya existe un Tipo de Empleado con esa Descripción'
			END
		ELSE
			BEGIN
				INSERT INTO Tipo_Empleado VALUES(@Descripcion)
				SET @IdMensaje = 0
				SET @Mensaje = 'Tipo Empleado agregado correctamente'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SET @IdMensaje = -3
    SET @Mensaje = ERROR_MESSAGE()
	ROLLBACK TRANSACTION
END catch
	SELECT @IdMensaje IdMensaje, @Mensaje Mensaje
GO

--Read
CREATE PROCEDURE [dbo].[ConsultaTipoEmpleado]
    @ID_TipoEmpleado INT = NULL,
    @IdMensaje INT OUTPUT,
    @Mensaje VARCHAR(250) OUTPUT
AS
BEGIN TRY
    IF @ID_TipoEmpleado IS NULL
    BEGIN
        -- Si no se proporciona @ID_TipoEmpleado, devuelve todos los registros
        SELECT ID_TipoEmpleado, Descripcion FROM Tipo_Empleado;
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta de todos los tipos de empleado exitosa';
    END
    ELSE IF EXISTS (SELECT 1 FROM Tipo_Empleado WHERE ID_TipoEmpleado = @ID_TipoEmpleado)
    BEGIN
        -- Si se proporciona @ID_TipoEmpleado y existe, devuelve el registro específico
        SELECT ID_TipoEmpleado, Descripcion FROM Tipo_Empleado WHERE ID_TipoEmpleado = @ID_TipoEmpleado;    
        SET @IdMensaje = 0;
        SET @Mensaje = 'Consulta exitosa';
    END
    ELSE
    BEGIN
        -- Si se proporciona @ID_TipoEmpleado y no existe, devuelve mensaje de error
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Tipo Empleado no existe';
        SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
    END
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
END CATCH;
GO

CREATE PROCEDURE ConsultaTipoEmpleadoxDescripcion(@Descripcion varchar(200))
AS
BEGIN
    SELECT ID_TipoEmpleado, Descripcion FROM Tipo_Empleado
    WHERE
        ((ISNULL(@Descripcion, '') <> '' AND Descripcion LIKE '%' + @Descripcion + '%') OR ISNULL(@Descripcion, '') = '')
END
GO

--Update
CREATE PROCEDURE ModificarTipoEmpleado(@ID_TipoEmpleado INT,@Descripcion VARCHAR(50),@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
        IF EXISTS (SELECT 1 FROM Tipo_Empleado WHERE ID_TipoEmpleado = @ID_TipoEmpleado)
        BEGIN
            IF EXISTS (SELECT 1 FROM Tipo_Empleado WHERE Descripcion = @Descripcion AND ID_TipoEmpleado <> @ID_TipoEmpleado)
            BEGIN
                SET @IdMensaje = -2;
                SET @Mensaje = 'La descripción del tipo de empleado ya existe en otro tipo de empleado';
            END
            ELSE
            BEGIN
                UPDATE Tipo_Empleado
                SET Descripcion = @Descripcion
                WHERE ID_TipoEmpleado = @ID_TipoEmpleado;

                SET @IdMensaje = 0;
                SET @Mensaje = 'Tipo de Empleado modificado correctamente';
            END
        END
        ELSE
        BEGIN
            SET @IdMensaje = -1;
            SET @Mensaje = 'El Tipo de Empleado no existe';
        END

        COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO

--Delete
CREATE PROCEDURE EliminarTipoEmpleado(@ID_TipoEmpleado INT,@IdMensaje INT OUTPUT,@Mensaje VARCHAR(250) OUTPUT)
AS
BEGIN TRY
    BEGIN TRANSACTION
    IF EXISTS (SELECT 1 FROM Tipo_Empleado WHERE ID_TipoEmpleado = @ID_TipoEmpleado)
    BEGIN
		IF EXISTS (SELECT 1 FROM Empleado WHERE ID_TipoEmpleado = @ID_TipoEmpleado)
		BEGIN
			SET @IdMensaje = -2;
			SET @Mensaje = 'No se eliminó porque el Tipo de Empleado está asociada a un Empleado';
		END
		ELSE
		BEGIN
			DELETE FROM Tipo_Empleado
			WHERE ID_TipoEmpleado = @ID_TipoEmpleado;

			SET @IdMensaje = 0;
			SET @Mensaje = 'Tipo de Empleado eliminado correctamente';
		END
    END
    ELSE
    BEGIN
        SET @IdMensaje = -1;
        SET @Mensaje = 'El Tipo de Empleado no existe';
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SET @IdMensaje = -3;
    SET @Mensaje = ERROR_MESSAGE();
    ROLLBACK TRANSACTION;
END CATCH
SELECT @IdMensaje IdMensaje, @Mensaje Mensaje;
GO