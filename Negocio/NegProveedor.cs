using Atributos;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegProveedor
    {
        public MensajeRespuesta InsertarProveedor(Proveedor pProveedor)
        {
            try
            {
                if (String.IsNullOrEmpty(pProveedor.Nombre_Proveedor))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre incorrecto" };
                }
                if (pProveedor.Telefono < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Telefono incorrecto" };
                }
                if (String.IsNullOrEmpty(pProveedor.Direccion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Direccion Incorrecta" };
                }

                ProveedorDB ProveedorRespuesta = new ProveedorDB();
                return ProveedorRespuesta.InsertarProveedor(pProveedor);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nuevo proveedor" };
            }
        }

        public MensajeRespuesta ConsultaProveedor(int ID_Proveedor)
        {
            try
            {
                if (ID_Proveedor < 0)
                {
                    return new MensajeRespuesta { Codigo = -2, Mensaje = "El Id de proveedor debe ser mayor a 0" };
                }
                ProveedorDB ProveedorRespuesta = new ProveedorDB();
                return ProveedorRespuesta.ConsultaProveedor(ID_Proveedor);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar proveedor por ID" };
            }
        }

        public MensajeRespuesta ConsultaProveedorNombre(string Nombre)
        {
            try
            {
                ProveedorDB ProveedorRespuesta = new ProveedorDB();
                return ProveedorRespuesta.ConsultaProveedorNombre(string.IsNullOrEmpty(Nombre) ? "" : Nombre);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar proveedor por nombre" };
            }
        }

        public MensajeRespuesta ModificarProveedor(Proveedor pProveedor)
        {
            try
            {
                if (String.IsNullOrEmpty(pProveedor.ID_Proveedor.ToString()) || pProveedor.ID_Proveedor == 0)
                {
                    return new MensajeRespuesta { Codigo = -3, Mensaje = "ID proveedor incorrecto" };
                }
                if (String.IsNullOrEmpty(pProveedor.Nombre_Proveedor))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre incorrecto" };
                }
                if (pProveedor.Telefono < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Telefono incorrecto" };
                }
                if (String.IsNullOrEmpty(pProveedor.Direccion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Direccion Incorrecta" };
                }

                ProveedorDB ProveedorRespuesta = new ProveedorDB();
                return ProveedorRespuesta.ModificarProveedor(pProveedor);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar proveedor" };
            }
        }

        public MensajeRespuesta EliminarProveedor(int ID_Proveedor)
        {
            try
            {
                if (ID_Proveedor < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Tipo Producto debe ser mayor a 0" };
                }
                ProveedorDB ProveedorRespuesta = new ProveedorDB();
                return ProveedorRespuesta.EliminarProveedor(ID_Proveedor);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar proveedor" };
            }
        }

    }
}
