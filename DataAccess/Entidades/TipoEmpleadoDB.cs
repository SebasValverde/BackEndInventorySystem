
using Atributos;
using DataAccess.Conexiones;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DataAccess.Entidades
{
    public class TipoEmpleadoDB
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public MensajeRespuesta Insertar(TipoEmpleado TipoEmpleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoTipoEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", TipoEmpleado.Descripcion);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el tipo de empleado: " + ex.Message; ;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;
        }

        

        public MensajeRespuesta ConsultaTipoEmpleado(int? ID_TipoEmpleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaTipoEmpleado"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_TipoEmpleado", (object)ID_TipoEmpleado ?? DBNull.Value);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el tipo de empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ConsultaTipoEmpleadoxDescripcion(string Descripcion)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaTipoEmpleadoxDescripcion"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el tipo empleado (Por Descripcion): " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ModificarTipoEmpleado(TipoEmpleado TipoEmpleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarTipoEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_TipoEmpleado", TipoEmpleado.ID_TipoEmpleado);
                cmd.Parameters.AddWithValue("@Descripcion", TipoEmpleado.Descripcion);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el tipo de empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;

        }

        public MensajeRespuesta Eliminar(int ID_TipoEmpleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarTipoEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_TipoEmpleado", ID_TipoEmpleado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el tipo de empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
    }
}
