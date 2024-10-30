using Atributos;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegProducto
    {
        public MensajeRespuesta InsertarProducto(Producto pProducto)
        {
            try
            {
                if (String.IsNullOrEmpty(pProducto.Nombre_Producto))
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "Nombre de producto Incorrecto" };
                }
                if (String.IsNullOrEmpty(pProducto.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Descripcion Incorrecta" };
                }
                if (pProducto.ID_TipoProducto < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Categoria de producto incorrecto" };
                }
                if (!pProducto.Fecha_Caducidad.HasValue)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Fecha de caducidad invalida" };
                }
                if (pProducto.ID_Proveedor < 1)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Proveedor invalido" };
                }
                if (pProducto.CostoUnitario < 1)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Error al ingresar el costo unitario" };
                }

                ProductoBD ProductoRespuesta = new ProductoBD();
                return ProductoRespuesta.InsertarProducto(pProducto);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nueva producto" };
            }
        }

        public MensajeRespuesta ConsultaProducto(int ID_Producto)
        {
            try
            {
                if (ID_Producto < 0)
                {
                    return new MensajeRespuesta { Codigo = -2, Mensaje = "El Id de producto debe ser mayor a 0" };
                }
                ProductoBD ProductoRespuesta = new ProductoBD();
                return ProductoRespuesta.ConsultaProducto(ID_Producto);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar producto por ID" };
            }
        }

        public MensajeRespuesta ModificarProducto(Producto pProducto)
        {
            try
            {
                if (String.IsNullOrEmpty(pProducto.ID_Producto.ToString()) || pProducto.ID_Producto == 0)
                {
                    return new MensajeRespuesta { Codigo = -3, Mensaje = "ID Producto Incorrecto" };
                }
                if (String.IsNullOrEmpty(pProducto.Nombre_Producto))
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "Nombre de producto Incorrecto" };
                }
                if (String.IsNullOrEmpty(pProducto.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Descripcion Incorrecta" };
                }
                if (pProducto.ID_TipoProducto < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Categoria de producto incorrecto" };
                }
                if (!pProducto.Fecha_Caducidad.HasValue)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Fecha de caducidad invalida" };
                }
                if (pProducto.ID_Proveedor < 1)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Proveedor invalido" };
                }
                if (pProducto.CostoUnitario < 1)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Error al ingresar el costo unitario" };
                }

                ProductoBD ProductoRespuesta = new ProductoBD();
                return ProductoRespuesta.ModificarProducto(pProducto);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar producto" };
            }
        }

        public MensajeRespuesta EliminarProducto(int ID_Producto)
        {
            try
            {
                if (ID_Producto < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de producto debe ser mayor a 0" };
                }
                ProductoBD ProductoRespuesta = new ProductoBD();
                return ProductoRespuesta.EliminarProducto(ID_Producto);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar producto" };
            }
        }

        public MensajeRespuesta ConsultaProductoNombreTipo(string NombreProducto, string Categoria)
        {
            try
            {
                ProductoBD ProductoRespuesta = new ProductoBD();
                return ProductoRespuesta.ConsultaProductoNombreTipo(string.IsNullOrEmpty(NombreProducto) ? "" : NombreProducto, string.IsNullOrEmpty(Categoria) ? "" : Categoria);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar producto por ID" };
            }
        }

    }
}
