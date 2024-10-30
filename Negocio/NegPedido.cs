
using Atributos;
using DataAccess.Entidades;
using System;

namespace Negocio
{
    public class NegPedido
    {
        public MensajeRespuesta Insertar(Pedido Pedido)
        {
            try
            {
                if (Pedido.Fecha_Creacion == default(DateTime))
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "La fecha de creación es obligatoria y debe ser válida." };
                }
                if (Pedido.ID_Cliente <= 0)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El ID del cliente debe ser un valor numérico entero mayor a 0." };
                }
                if (Pedido.ID_Empleado <= 0)
                {
                    return new MensajeRespuesta { Codigo = -15, Mensaje = "El ID del empleado debe ser un valor numérico entero mayor a 0." };
                }
                if (Pedido.Fecha_Envio == default(DateTime))
                {
                    return new MensajeRespuesta { Codigo = -16, Mensaje = "La fecha de envío es obligatoria y debe ser válida." };
                }
                if (Pedido.Fecha_Envio < Pedido.Fecha_Creacion)
                {
                    return new MensajeRespuesta { Codigo = -17, Mensaje = "La fecha de envío no puede ser anterior a la fecha de creación." };
                }
                if (Pedido.MontoTotal < 0)
                {
                    return new MensajeRespuesta { Codigo = -18, Mensaje = "El monto total debe ser un valor numérico entero positivo." };
                }

                PedidoDB PedidoRespuesta = new PedidoDB();
                return PedidoRespuesta.Insertar(Pedido);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar un nuevo Pedido" };
            }
        }

        public MensajeRespuesta ConsultaPedido(string ID_Pedido)
        {
            try
            {
                PedidoDB PedidoRespuesta = new PedidoDB();
                if (string.IsNullOrEmpty(ID_Pedido))
                {
                    // Si no se proporciona ID_Pedido, devuelve todos los pedidos
                    return PedidoRespuesta.ConsultaPedido(null);
                }

                if (int.TryParse(ID_Pedido, out int idPedidol))
                {
                    if (idPedidol <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id Pedido debe ser mayor a 0" };
                    }
                    // Si el ID_Pedido es un número válido, realiza la consulta específica
                    return PedidoRespuesta.ConsultaPedido(idPedidol);
                }
                else
                {
                    // Si el ID_Pedido no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id Pedido debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Pedido" };
            }
        }

        public MensajeRespuesta ConsultaPedidosClienteEmpleado(string Nombre_Cliente, string Nombre_Empleado)
        {
            try
            {

                PedidoDB PedidoRespuesta = new PedidoDB();
                return PedidoRespuesta.ConsultaPedidosClienteEmpleado(Nombre_Cliente, Nombre_Empleado);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Pedidos (Por Nombre Cliente y/o Nombre Empleado)" };
            }
        }

        public MensajeRespuesta ModificarPedido(Pedido Pedido)
        {
            try
            {
                if (Pedido.ID_Pedido <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El ID del pedido debe ser un valor numérico entero mayor a 0." };
                }
                if (Pedido.ID_Cliente <= 0)
                {
                    return new MensajeRespuesta { Codigo = -15, Mensaje = "El ID del cliente debe ser un valor numérico entero mayor a 0." };
                }
                if (Pedido.ID_Empleado <= 0)
                {
                    return new MensajeRespuesta { Codigo = -16, Mensaje = "El ID del empleado debe ser un valor numérico entero mayor a 0." };
                }
                if (Pedido.Fecha_Envio == default(DateTime))
                {
                    return new MensajeRespuesta { Codigo = -17, Mensaje = "La fecha de envío es obligatoria y debe ser válida." };
                }
                if (Pedido.Fecha_Envio < Pedido.Fecha_Creacion)
                {
                    return new MensajeRespuesta { Codigo = -18, Mensaje = "La fecha de envío no puede ser anterior a la fecha de creación." };
                }
                if (Pedido.MontoTotal < 0)
                {
                    return new MensajeRespuesta { Codigo = -19, Mensaje = "El monto total debe ser un valor numérico entero positivo." };
                }

                PedidoDB PedidoRespuesta = new PedidoDB();
                return PedidoRespuesta.ModificarPedido(Pedido);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar el Pedido" };
            }
        }

        public MensajeRespuesta ModificarMontoTotalPedido(string ID_Pedido, string MontoTotal)
        {
            try
            {
                // Validación para ID_Pedido
                if (!int.TryParse(ID_Pedido, out int idPedido))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Pedido debe ser un valor numérico entero." };
                }
                if (idPedido <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Pedido debe ser mayor a 0." };
                }
                // Validación para MontoTotal
                if (!int.TryParse(MontoTotal, out int montoTotal))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Monto Total debe ser un valor numérico entero." };
                }
                if (montoTotal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Monto Total debe ser mayor a 0." };
                }

                PedidoDB PedidoRespuesta = new PedidoDB();
                return PedidoRespuesta.ModificarMontoTotalPedido(idPedido, montoTotal);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar el Monto Total del Pedido" };
            }
        }

        public MensajeRespuesta Eliminar(string ID_Pedido)
        {
            try
            {
                PedidoDB PedidoRespuesta = new PedidoDB();
                if (int.TryParse(ID_Pedido, out int idPedido))
                {
                    if (idPedido <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Pedido debe ser un  mayor a 0" };
                    }
                    return PedidoRespuesta.Eliminar(idPedido);
                }
                else
                {
                    // Si el ID_Pedido no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Pedido debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar Pedido" };
            }
        }
    }
}
