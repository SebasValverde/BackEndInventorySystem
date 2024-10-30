using Atributos;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegCliente
    {
        public MensajeRespuesta InsertarCliente(Cliente cCliente)
        {
            try
            {
                if (String.IsNullOrEmpty(cCliente.Nombre_Cliente))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre de cliente incorrecto" };
                }
                if (cCliente.Telefono < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Telefono de cliente incorrecto" };
                }
                if (String.IsNullOrEmpty(cCliente.Direccion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Direccion de cliente Incorrecta" };
                }

                ClienteDB ClienteRespuesta = new ClienteDB();
                return ClienteRespuesta.InsertarCliente(cCliente);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nuevo cliente" };
            }
        }

        public MensajeRespuesta ConsultaCliente(string ID_Cliente)
        {
            try
            {
                ClienteDB ClienteRespuesta = new ClienteDB();
                if (string.IsNullOrEmpty(ID_Cliente))
                {
                    return ClienteRespuesta.ConsultaCliente(null);
                }

                if (int.TryParse(ID_Cliente, out int idCliente))
                {
                    if (idCliente <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Cliente debe ser mayor a 0" };
                    }
                    return ClienteRespuesta.ConsultaCliente(idCliente);
                }
                else
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id de Cliente debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Cliente" };
            }
        }

        public MensajeRespuesta ConsultaClientesNombreDireccion(string Nombre_Cliente, string Direccion)
        {
            try
            {
                ClienteDB ClienteRespuesta = new ClienteDB();
                return ClienteRespuesta.ConsultaClientesNombreDireccion(Nombre_Cliente, Direccion);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Cliente por nombre o dirección" };
            }
        }

        public MensajeRespuesta ModificarCliente(Cliente cCliente)
        {
            try
            {
                if (String.IsNullOrEmpty(cCliente.ID_Cliente.ToString()) || cCliente.ID_Cliente == 0)
                {
                    return new MensajeRespuesta { Codigo = -3, Mensaje = "ID del Cliente incorrecto" };
                }
                if (String.IsNullOrEmpty(cCliente.Nombre_Cliente))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Nombre de Cliente incorrecto" };
                }
                if (cCliente.Telefono < 1)
                {
                    return new MensajeRespuesta { Codigo = -5, Mensaje = "Teléfono de Cliente incorrecto" };
                }
                if (String.IsNullOrEmpty(cCliente.Direccion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Direccion de Cliente Incorrecta" };
                }

                ClienteDB ClienteRespuesta = new ClienteDB();
                return ClienteRespuesta.ModificarCliente(cCliente);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar Cliente" };
            }
        }

        public MensajeRespuesta EliminarCliente(int ID_Cliente)
        {
            try
            {
                if (ID_Cliente < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Cliente debe ser mayor a 0" };
                }
                ClienteDB ClienteRespuesta = new ClienteDB();
                return ClienteRespuesta.EliminarCliente(ID_Cliente);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar Cliente" };
            }
        }

    }
}
