using Atributos;
using DataAccess.Conexiones;
using DataAccess.Entidades;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class NegInventario
    {
        public MensajeRespuesta ModificarInventarioAgregar(string ID_Sucursal, string ID_Producto, string CantidadPorAgregar)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                // Validación para ID_Sucursal
                if (!int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numérico entero." };
                }
                if (idSucursal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser mayor a 0." };
                }

                // Validación para ID_Producto
                if (!int.TryParse(ID_Producto, out int idProducto))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Producto debe ser un valor numérico entero." };
                }
                if (idProducto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Producto debe ser mayor a 0." };
                }

                // Validación para CantidadPorAgregar
                if (!int.TryParse(CantidadPorAgregar, out int cantidadPorAgregar))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La Cantidad Por Agregar debe ser un valor numérico entero." };
                }
                if (cantidadPorAgregar <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "La Cantidad Por Agregar debe ser mayor a 0." };
                }

                // Si todas las validaciones son correctas, llama al método ModificarInventarioAgregar de InventarioDB
                return InventarioRespuesta.ModificarInventarioAgregar(idSucursal, idProducto, cantidadPorAgregar);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar inventario(Agregar): " + ex.Message };
            }
        }

        public MensajeRespuesta ModificarInventarioRestar(string ID_Sucursal, string ID_Producto, string CantidadPorEliminar)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                // Validación para ID_Sucursal
                if (!int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numérico entero." };
                }
                if (idSucursal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser mayor a 0." };
                }

                // Validación para ID_Producto
                if (!int.TryParse(ID_Producto, out int idProducto))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Producto debe ser un valor numérico entero." };
                }
                if (idProducto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Producto debe ser mayor a 0." };
                }

                // Validación para CantidadPorEliminar
                if (!int.TryParse(CantidadPorEliminar, out int cantidadPorEliminar))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La Cantidad Por Restar debe ser un valor numérico entero." };
                }
                if (cantidadPorEliminar <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "La Cantidad Por Restar debe ser mayor a 0." };
                }

                // Si todas las validaciones son correctas, llama al método ModificarInventarioRestar de InventarioDB
                return InventarioRespuesta.ModificarInventarioRestar(idSucursal, idProducto, cantidadPorEliminar);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar inventario(Restar): " + ex.Message };
            }
        }
        
        public MensajeRespuesta InsertarInventario(Inventario iInventario)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                if (!int.TryParse(iInventario.ID_Sucursal.ToString(), out int idSucursal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numérico entero." };
                }
                if (idSucursal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser mayor a 0." };
                }

                // Validación para ID_Producto
                if (!int.TryParse(iInventario.ID_Producto.ToString(), out int idProducto))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Producto debe ser un valor numérico entero." };
                }
                if (idProducto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Producto debe ser mayor a 0." };
                }

                // Validación para Cantidad
                if (!int.TryParse(iInventario.Cantidad.ToString(), out int cantidad))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La Cantidad debe ser un valor numérico entero." };
                }
                if (cantidad < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "La Cantidad no puede ser negativa." };
                }
                if (!bool.TryParse(iInventario.Estado.ToString(), out bool estado))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Estado debe ser un valor booleano (true o false)." };
                }

                // Llamada a la capa de datos para insertar el inventario
                return InventarioRespuesta.NuevoInventario(idSucursal, idProducto, cantidad, estado);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al insertar inventario: " + ex.Message };
            }

        }

        public MensajeRespuesta ConsultaInventarioxSucursal(string ID_Sucursal)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();
                if (string.IsNullOrEmpty(ID_Sucursal))
                {
                    return InventarioRespuesta.ConsultaInventarioxSucursal(null);
                }

                if (int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    return InventarioRespuesta.ConsultaInventarioxSucursal(idSucursal);
                }
                else
                {
                    return InventarioRespuesta.ConsultaInventarioxSucursal(null);
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Inventaro por ID Sucursal" };
            }
        }

        public MensajeRespuesta ConsultaInventarioxSucursalProducto(string ID_Sucursal, string Nombre_Producto)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                // Validación para ID_Sucursal
                if (!string.IsNullOrEmpty(ID_Sucursal) && !int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numérico entero." };
                }

                // Validación para Nombre_Producto (si se requiere)
                if (Nombre_Producto != null && Nombre_Producto.Length > 100)  // Limite en nombre del producto
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El nombre del producto no puede exceder los 100 caracteres." };
                }

                // Llamada al método de InventarioDB
                return InventarioRespuesta.ConsultaInventarioxSucursalProducto(
                    string.IsNullOrEmpty(ID_Sucursal) || ID_Sucursal == "0" ? (int?)null : int.Parse(ID_Sucursal),
                    Nombre_Producto
                );


            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar inventario: " + ex.Message };
            }
        }

        public MensajeRespuesta ConsultaInventario(string ID_Inventario)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                // Convertir ID_Inventario de string a int?
                int? idInventario = null;
                if (!string.IsNullOrEmpty(ID_Inventario) && int.TryParse(ID_Inventario, out int tempId))
                {
                    idInventario = tempId;
                }

                // Llamada al método de InventarioDB con el parámetro convertido
                return InventarioRespuesta.ConsultaInventario(idInventario);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar inventario: " + ex.Message };
            }
        }


        public MensajeRespuesta EliminarInventario(string ID_Inventario)
        {
            try
            {
                InventarioDB InventarioRespuesta = new InventarioDB();

                // Validación para ID_Inventario
                if (!int.TryParse(ID_Inventario, out int idInventario))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Inventario debe ser un valor numérico entero." };
                }
                if (idInventario <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El # de Id del Inventario debe ser mayor a 0." };
                }

                // Llamada al método EliminarInventario de InventarioDB
                return InventarioRespuesta.EliminarInventario(idInventario);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar inventario: " + ex.Message };
            }
        }       
    
    }
}