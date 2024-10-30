using Atributos;
using DataAccess.Entidades;
using System;

namespace Negocio
{
    public class NegSucursal
    {
        public MensajeRespuesta Insertar(Sucursal Sucursal)
        {
            try
            {
                if (String.IsNullOrEmpty(Sucursal.Nombre_Sucursal))
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "Nombre de Sucursal Incorrecto" };
                }
                if (Sucursal.Nombre_Sucursal.Length > 100)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El nombre de la Sucursal no puede exceder los 100 caracteres" };
                }
                if (Sucursal.Telefono <= 0)
                {
                    return new MensajeRespuesta { Codigo = -15, Mensaje = "Número de Teléfono Incorrecto" };
                }
                if (String.IsNullOrEmpty(Sucursal.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -16, Mensaje = "Descripcion Incorrecta" };
                }
                if (Sucursal.Descripcion.Length > 200)
                {
                    return new MensajeRespuesta { Codigo = -17, Mensaje = "La descripción no puede exceder los 200 caracteres" };
                }

                SucursalDB SucursalRespuesta = new SucursalDB();
                return SucursalRespuesta.Insertar(Sucursal);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nueva Sucursal" };
            }
        }

        public MensajeRespuesta ConsultaSucursal(string ID_Sucursal)
        {
            try
            {
                SucursalDB SucursalRespuesta = new SucursalDB();
                if (string.IsNullOrEmpty(ID_Sucursal))
                {
                    // Si no se proporciona ID_Sucursal, devuelve todas las sucursales
                    return SucursalRespuesta.ConsultaSucursal(null);
                }

                if (int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    if (idSucursal <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser mayor a 0" };
                    }
                    // Si el ID_Sucursal es un número válido, realiza la consulta específica
                    return SucursalRespuesta.ConsultaSucursal(idSucursal);
                }
                else
                {
                    // Si el ID_Sucursal no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Sucursal" };
            }
        }

        public MensajeRespuesta ConsultaSucursalesNombreDescripcion(string Nombre_Sucursal, string Descripcion)
        {
            try
            {

                SucursalDB SucursalRespuesta = new SucursalDB();
                return SucursalRespuesta.ConsultaSucursalesNombreDescripcion(Nombre_Sucursal, Descripcion);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Sucursal (Por Nombre y/o Descripcion)" };
            }
        }

        public MensajeRespuesta ModificarSucursal(Sucursal Sucursal)
        {
            try
            {
                if (Sucursal.ID_Sucursal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser un valor numérico entero mayor a 0" };
                }
                if (String.IsNullOrEmpty(Sucursal.Nombre_Sucursal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre de Sucursal Incorrecto" };
                }
                if (Sucursal.Nombre_Sucursal.Length > 100)
                {
                    return new MensajeRespuesta { Codigo = -15, Mensaje = "El nombre de la Sucursal no puede exceder los 100 caracteres" };
                }
                if (Sucursal.Telefono <= 0)
                {
                    return new MensajeRespuesta { Codigo = -16, Mensaje = "Número de Teléfono Incorrecto" };
                }
                if (String.IsNullOrEmpty(Sucursal.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -17, Mensaje = "Descripcion Incorrecta" };
                }
                if (Sucursal.Descripcion.Length > 200)
                {
                    return new MensajeRespuesta { Codigo = -18, Mensaje = "La descripción no puede exceder los 200 caracteres" };
                }

                SucursalDB SucursalRespuesta = new SucursalDB();
                return SucursalRespuesta.ModificarSucursal(Sucursal);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar Sucursales" };
            }
        }

        public MensajeRespuesta Eliminar(string ID_Sucursal)
        {
            try
            {
                SucursalDB SucursalRespuesta = new SucursalDB();
                if (int.TryParse(ID_Sucursal, out int idSucursal))
                {
                    if (idSucursal <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Sucursal debe ser mayor a 0" };
                    }
                    return SucursalRespuesta.Eliminar(idSucursal);
                }
                else
                {
                    // Si el ID_Sucursal no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Sucursal debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar Sucursal" };
            }
        }
    }
}
