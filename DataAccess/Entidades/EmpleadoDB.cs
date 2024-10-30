using DataAccess.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atributos;

namespace DataAccess.Entidades
{
    public class EmpleadoDB
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public MensajeRespuesta InsertarEmpleado(Empleado Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Empleado", Empleado.Nombre_Empleado);
                cmd.Parameters.AddWithValue("@ID_TipoEmpleado", Empleado.ID_TipoEmpleado);
                cmd.Parameters.AddWithValue("@Correo_Empleado", Empleado.Correo_Empleado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el nuevo Empleado: " + ex.Message; ;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;
        }

        public MensajeRespuesta ConsultaEmpleadosPorNombreCorreo(string Nombre_Empleado, string Correo_Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaEmpleadosPorNombreCorreo"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Empleado", Nombre_Empleado);
                cmd.Parameters.AddWithValue("@Correo_Empleado", Correo_Empleado);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Consulta datos del empleado exitosa!";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {

                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el tipo empleado (Por Nombre o correo): " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ConsultaEmpleado(int? ID_Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Empleado", (object)ID_Empleado ?? DBNull.Value);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el Empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ModificarEmpleado(Empleado Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Empleado", Empleado.ID_Empleado);
                cmd.Parameters.AddWithValue("@Nombre_Empleado", Empleado.Nombre_Empleado);
                cmd.Parameters.AddWithValue("@ID_TipoEmpleado", Empleado.ID_TipoEmpleado);
                cmd.Parameters.AddWithValue("@Correo_Empleado", Empleado.Correo_Empleado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el Empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta EliminarEmpleado(int ID_Empleado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Empleado", ID_Empleado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el Empleado: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
    }
}
