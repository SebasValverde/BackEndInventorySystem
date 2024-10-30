using Atributos;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegEmpleado
    {
        public MensajeRespuesta InsertarEmpleado(Empleado eEmpleado)
        {
            try
            {
                if (String.IsNullOrEmpty(eEmpleado.Nombre_Empleado))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre incorrecto" };
                }
                if (String.IsNullOrEmpty(eEmpleado.Correo_Empleado))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Direccion Incorrecta" };
                }


                EmpleadoDB EmpleadoRespuesta = new EmpleadoDB();
                return EmpleadoRespuesta.InsertarEmpleado(eEmpleado);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nuevo Empleado" };
            }
        }

        public MensajeRespuesta ConsultaEmpleadosPorNombreCorreo(string Nombre_Empleado, string Correo_Empleado)
        {
            try
            {
                EmpleadoDB EmpleadoRespuesta = new EmpleadoDB();

                // Validación de parámetros, permitiendo valores nulos
                if (string.IsNullOrEmpty(Nombre_Empleado))
                {
                    Nombre_Empleado = null;
                }

                if (string.IsNullOrEmpty(Correo_Empleado))
                {
                    Correo_Empleado = null;
                }

                return EmpleadoRespuesta.ConsultaEmpleadosPorNombreCorreo(Nombre_Empleado, Correo_Empleado);
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar empleados: " + ex.Message };
            }
        }

        public MensajeRespuesta ConsultaEmpleado(string ID_Empleado)
        {
            try
            {
                EmpleadoDB EmpleadoRespuesta = new EmpleadoDB();
                if (string.IsNullOrEmpty(ID_Empleado))
                {
                    return EmpleadoRespuesta.ConsultaEmpleado(null);
                }

                if (int.TryParse(ID_Empleado, out int idEmpleado))
                {
                    if (idEmpleado <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Empleado debe ser mayor a 0" };
                    }
                    return EmpleadoRespuesta.ConsultaEmpleado(idEmpleado);
                }
                else
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Empleado debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Empleado" };
            }
        }
        public MensajeRespuesta ModificarEmpleado(Empleado eEmpleado)
        {
            try
            {
                if (String.IsNullOrEmpty(eEmpleado.ID_Empleado.ToString()) || eEmpleado.ID_Empleado == 0)
                {
                    return new MensajeRespuesta { Codigo = -3, Mensaje = "ID Empleado incorrecto" };
                }
                if (String.IsNullOrEmpty(eEmpleado.Nombre_Empleado))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre Empleado incorrecto" };
                }
                if (eEmpleado.ID_TipoEmpleado < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Telefono Empleado incorrecto" };
                }
                if (String.IsNullOrEmpty(eEmpleado.Correo_Empleado))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Correo electrónico de Empleado Incorrecto" };
                }

                EmpleadoDB EmpleadoRespuesta = new EmpleadoDB();
                return EmpleadoRespuesta.ModificarEmpleado(eEmpleado);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar Empleado" };
            }
        }

        public MensajeRespuesta EliminarEmpleado(int ID_Empleado)
        {
            try
            {
                if (ID_Empleado < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Empleado debe ser mayor a 0" };
                }
                EmpleadoDB EmpleadoRespuesta = new EmpleadoDB();
                return EmpleadoRespuesta.EliminarEmpleado(ID_Empleado);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar Empleado" };
            }
        }

    }
}
