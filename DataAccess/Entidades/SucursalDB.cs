using DataAccess.Conexiones;
using System.Data.SqlClient;
using System.Data;
using System;
using Atributos;

namespace DataAccess.Entidades
{
    public class SucursalDB
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public MensajeRespuesta Insertar(Sucursal Sucursal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevaSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Sucursal", Sucursal.Nombre_Sucursal);
                cmd.Parameters.AddWithValue("@Telefono", Sucursal.Telefono);
                cmd.Parameters.AddWithValue("@Descripcion", Sucursal.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", Sucursal.Estado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar la sucursal: " + ex.Message; ;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;
        }

        public MensajeRespuesta ConsultaSucursal(int? ID_Sucursal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaSucursal"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", (object)ID_Sucursal ?? DBNull.Value);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar la sucursal: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ConsultaSucursalesNombreDescripcion(string Nombre_Sucursal, string Descripcion)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaSucursalesNombreDescripcion"; //Se coloca el nombre del procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Sucursal", Nombre_Sucursal);
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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar la sucursal (Por Nombre y/o Descripcion): " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ModificarSucursal(Sucursal Sucursal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", Sucursal.ID_Sucursal);
                cmd.Parameters.AddWithValue("@Nombre_Sucursal", Sucursal.Nombre_Sucursal);
                cmd.Parameters.AddWithValue("@Telefono", Sucursal.Telefono);
                cmd.Parameters.AddWithValue("@Descripcion", Sucursal.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", Sucursal.Estado);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar la sucursal: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;

        }

        public MensajeRespuesta Eliminar(int ID_Sucursal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", ID_Sucursal);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar la sucursal: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
    }
}
