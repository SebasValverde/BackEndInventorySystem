using Atributos;
using DataAccess.Entidades;
using System;

namespace Negocio
{
    public class NegTipoEmpleado
    {
        public MensajeRespuesta InsertarTipoEmpleado(TipoEmpleado TipoEmpleado)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoEmpleado.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "Descripción Inválida" };
                }
                if (TipoEmpleado.Descripcion.Length > 100)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La Descripción del Tipo Empelado no puede exceder los 100 caractéres" };
                }
                TipoEmpleadoDB TipoEmpleadoRespuesta = new TipoEmpleadoDB();
                return TipoEmpleadoRespuesta.Insertar(TipoEmpleado);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nuevo Tipo Empleadoo" };
            }
        }

        public MensajeRespuesta ConsultaTipoEmpleado(string ID_TipoEmpleado)
        {
            try
            {
                TipoEmpleadoDB TipoEmpleadoRespuesta = new TipoEmpleadoDB();
                if (string.IsNullOrEmpty(ID_TipoEmpleado))
                {
                    return TipoEmpleadoRespuesta.ConsultaTipoEmpleado(null);
                }

                if (int.TryParse(ID_TipoEmpleado, out int idTipoEmpleado))
                {
                    if (idTipoEmpleado <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Tipo de Empleado debe ser mayor a 0" };
                    }
                    return TipoEmpleadoRespuesta.ConsultaTipoEmpleado(idTipoEmpleado);
                }
                else
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Tipo de Empleado debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Tipo de Empleado" };
            }
        }

        public MensajeRespuesta ConsultaTipoEmpleadoxDescripcion(string Descripcion)
        {
            try
            {

                TipoEmpleadoDB TipoEmpleadoRespuesta = new TipoEmpleadoDB();
                return TipoEmpleadoRespuesta.ConsultaTipoEmpleadoxDescripcion(Descripcion);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Tipo de Empleado (Por Descripcion)" };
            }
        }

        public MensajeRespuesta ModificarTipoEmpleado(TipoEmpleado TipoEmpleado)
        {
            try
            {
                if (TipoEmpleado.ID_TipoEmpleado <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Tipo de Empleado debe ser un valor numérico entero mayor a 0" };
                }
                if (String.IsNullOrEmpty(TipoEmpleado.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Descripción Inválida" };
                }
                if (TipoEmpleado.Descripcion.Length > 100)
                {
                    return new MensajeRespuesta { Codigo = -18, Mensaje = "La Descripción del Tipo Empelado no puede exceder los 100 caractéres" };
                }

                TipoEmpleadoDB TipoEmpleadoRespuesta = new TipoEmpleadoDB();
                return TipoEmpleadoRespuesta.ModificarTipoEmpleado(TipoEmpleado);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar Tipo Empelado" };
            }
        }

        public MensajeRespuesta Eliminar(string ID_TipoEmpleado)
        {
            try
            {
                TipoEmpleadoDB TipoEmpleadoRespuesta = new TipoEmpleadoDB();
                if (int.TryParse(ID_TipoEmpleado, out int idTipoEmpleado))
                {
                    if (idTipoEmpleado <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Tipo de Empleado debe ser mayor a 0" };
                    }
                    return TipoEmpleadoRespuesta.Eliminar(idTipoEmpleado);
                }
                else
                {
                    // Si el ID_TipoEmpleado no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Tipo de Empleado debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar Tipo Emplead" };
            }
        }

    }
}
