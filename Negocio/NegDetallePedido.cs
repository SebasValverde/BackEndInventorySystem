
using Atributos;
using DataAccess.Entidades;
using System;

namespace Negocio
{
    public class NegDetallePedido
    {
        public MensajeRespuesta Insertar(DetallePedido DetallePedido)
        {
            try
            {
                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();

                // Validación para ID_Pedido
                if (DetallePedido.ID_Pedido <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Pedido debe ser un valor numérico entero mayor a 0." };
                }

                // Validación para Cantidad
                if (DetallePedido.Cantidad <= 0)
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La cantidad debe ser un valor numérico entero mayor a 0." };
                }

                // Validación para ID_Producto
                if (DetallePedido.ID_Producto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -15, Mensaje = "El Id del Producto debe ser un valor numérico entero mayor a 0." };
                }

                // Validación para ID_Sucursal
                if (DetallePedido.ID_Sucursal <= 0)
                {
                    return new MensajeRespuesta { Codigo = -16, Mensaje = "El Id de la Sucursal debe ser un valor numérico entero mayor a 0." };
                }

                // Validación para Monto
                if (DetallePedido.Monto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -17, Mensaje = "El Monto debe ser un valor numérico entero mayor a 0." };
                }

                return DetallePedidoRespuesta.Insertar(DetallePedido);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar un nuevo Detalle Pedido" };
            }
        }

        public MensajeRespuesta ConsultaDetallesPedidoxPedido(string ID_Pedido)
        {
            try
            {
                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();
                if (int.TryParse(ID_Pedido, out int idPedido))
                {
                    if (idPedido < 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del ID_Pedido debe ser un número entero positivo" };
                    }
                    // Si el ID_Pedido es un número válido, realiza la consulta específica
                    return DetallePedidoRespuesta.ConsultaDetallesPedidoxPedido(idPedido);
                }
                else
                {
                    // Si el ID_Pedido no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del ID_Pedido debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar los Detalle Pedidos por ID_Pedido" };
            }
        }

        public MensajeRespuesta ConsultaDetallePedidoxID(string ID_Detalle)
        {
            try
            {
                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();
                if (int.TryParse(ID_Detalle, out int idDetalle))
                {
                    if (idDetalle <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Detalle Pedido debe ser mayor a 0" };
                    }
                    // Si el ID_Detalle es un número válido, realiza la consulta específica
                    return DetallePedidoRespuesta.ConsultaDetallePedidoxID(idDetalle);
                }
                else
                {
                    // Si el ID_Detalle no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Detalle Pedido debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar el Detalle Pedido por ID_Detalle" };
            }
        }

        public MensajeRespuesta ConsultaDetallesPedidoProductoSucursal(string ID_Pedido, string Nombre_Producto, string Nombre_Sucursal)
        {
            try
            {

                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();
                return DetallePedidoRespuesta.ConsultaDetallesPedidoProductoSucursal(ID_Pedido, Nombre_Producto, Nombre_Sucursal);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Detalles Pedido (Por Nombre Producto y/o Nombre Sucursal)" };
            }
        }

        public MensajeRespuesta ModificarDetallePedido(string ID_Detalle, string Cantidad, string Monto)
        {
            try
            {
                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();

                // Validación para ID_Detalle
                if (!int.TryParse(ID_Detalle, out int idDetalle))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Detalle Pedido debe ser un valor numérico entero." };
                }
                if (idDetalle <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Detalle Pedido debe ser mayor a 0." };
                }
                // Validación para Cantidad
                if (!int.TryParse(Cantidad, out int cantidad))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "La Cantidad debe ser un valor numérico entero." };
                }
                if (cantidad <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "La Cantidad debe ser mayor a 0." };
                }
                // Validación para Monto
                if (!int.TryParse(Monto, out int monto))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Monto debe ser un valor numérico entero." };
                }
                if (monto <= 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Monto debe ser mayor a 0." };
                }

                return DetallePedidoRespuesta.ModificarDetallePedido(idDetalle, cantidad, monto);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al intentar modificar el Detalle Pedido" };
            }
        }

        public MensajeRespuesta Eliminar(string ID_Detalle)
        {
            try
            {
                DetallePedidoDB DetallePedidoRespuesta = new DetallePedidoDB();
                if (int.TryParse(ID_Detalle, out int idDetalle))
                {
                    if (idDetalle <= 0)
                    {
                        return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id del Detalle Pedido debe ser mayor a 0" };
                    }
                    return DetallePedidoRespuesta.Eliminar(idDetalle);
                }
                else
                {
                    // Si el ID_Detalle no es un número válido, devuelve un mensaje de error
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "El Id del Detalle Pedido debe ser un valor numerico entero." };
                }
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar el Detalle Pedido" };
            }
        }

    }
}
