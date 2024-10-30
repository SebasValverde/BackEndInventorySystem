using DataAccess.Conexiones;
using System.Data.SqlClient;
using System.Data;
using Atributos;
using System;

namespace DataAccess.Entidades
{
    public class PedidoDB
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public MensajeRespuesta Insertar(Pedido Pedido)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoPedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha_Creacion", Pedido.Fecha_Creacion);
                cmd.Parameters.AddWithValue("@ID_Cliente", Pedido.ID_Cliente);
                cmd.Parameters.AddWithValue("@ID_Empleado", Pedido.ID_Empleado);
                cmd.Parameters.AddWithValue("@Estado_Orden", Pedido.Estado_Orden);
                cmd.Parameters.AddWithValue("@Fecha_Envio", Pedido.Fecha_Envio);
                cmd.Parameters.AddWithValue("@MontoTotal", Pedido.MontoTotal);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                SqlParameter idPedidoParam = new SqlParameter("@ID_Pedido", SqlDbType.Int);
                idPedidoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idPedidoParam);

                cmd.ExecuteNonQuery();

                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();

                Rpta.Contenido = new
                {
                    ID_Pedido = Convert.ToInt32(idPedidoParam.Value)
                };
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el pedido: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;
        }

        public MensajeRespuesta ConsultaPedido(int? ID_Pedido)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaPedido"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pedido", (object)ID_Pedido ?? DBNull.Value);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }

                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();

                if (Rpta.Codigo == 0)
                    Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {

                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el pedido: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ConsultaPedidosClienteEmpleado(string Nombre_Cliente, string Nombre_Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaPedidosClienteEmpleado"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Cliente", Nombre_Cliente);
                cmd.Parameters.AddWithValue("@Nombre_Empleado", Nombre_Empleado);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Consulta Exitosa";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {

                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el pedido (Por Nombre Cliente y/o Nombre Empleado): " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ModificarPedido(Pedido Pedido)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarPedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pedido", Pedido.ID_Pedido);
                cmd.Parameters.AddWithValue("@ID_Cliente", Pedido.ID_Cliente);
                cmd.Parameters.AddWithValue("@ID_Empleado", Pedido.ID_Empleado);
                cmd.Parameters.AddWithValue("@Estado_Orden", Pedido.Estado_Orden);
                cmd.Parameters.AddWithValue("@Fecha_Envio", Pedido.Fecha_Envio);
                cmd.Parameters.AddWithValue("@MontoTotal", Pedido.MontoTotal);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                cmd.ExecuteNonQuery();

                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el pedido: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;

        }

        public MensajeRespuesta ModificarMontoTotalPedido(int ID_Pedido, int MontoTotal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarMontoTotalPedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);
                cmd.Parameters.AddWithValue("@MontoTotal", MontoTotal);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                cmd.ExecuteNonQuery();

                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el monto total del pedido: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;

        }

        public MensajeRespuesta Eliminar(int ID_Pedido)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarPedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pedido", ID_Pedido);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                cmd.ExecuteNonQuery();

                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el pedido: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
    }
}
