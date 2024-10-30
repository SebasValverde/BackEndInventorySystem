using DataAccess.Conexiones;
using System.Data.SqlClient;
using System.Data;
using Atributos;
using System;


namespace DataAccess.Entidades
{
    public class InventarioDB
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public MensajeRespuesta ModificarInventarioAgregar(int ID_Sucursal, int ID_Producto, int CantidadPorAgregar)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarInventarioAgregar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", ID_Sucursal);
                cmd.Parameters.AddWithValue("@ID_Producto", ID_Producto);
                cmd.Parameters.AddWithValue("@CantidadPorAgregar", CantidadPorAgregar);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al intentar agregar producto al inventario: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
        public MensajeRespuesta ModificarInventarioRestar(int ID_Sucursal, int ID_Producto, int CantidadPorEliminar)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarInventarioRestar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", ID_Sucursal);
                cmd.Parameters.AddWithValue("@ID_Producto", ID_Producto);
                cmd.Parameters.AddWithValue("@CantidadPorEliminar", CantidadPorEliminar);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al intentar restar producto al inventario: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
        public MensajeRespuesta NuevoInventario(int ID_Sucursal, int ID_Producto, int Cantidad, bool Estado)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoInventario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", ID_Sucursal);
                cmd.Parameters.AddWithValue("@ID_Producto", ID_Producto);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Estado", Estado);
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
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar un nuevo inventario: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
        public MensajeRespuesta ConsultaInventario(int? ID_Inventario)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaInventario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();  // Limpiar parámetros previos

                // Parámetro de entrada
                cmd.Parameters.AddWithValue("@ID_Inventario", ID_Inventario.HasValue ? (object)ID_Inventario.Value : DBNull.Value);

                // Ejecutar y cargar los datos en el DataTable
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();

                // Asignar el DataTable al contenido de la respuesta
                Rpta.Codigo = 0; // Código 0 para indicar éxito (puedes ajustar este valor según tus necesidades)
                Rpta.Mensaje = "Consulta exitosa"; // Mensaje de éxito
                Rpta.Contenido = dt;

                return Rpta;
            }
            catch (Exception ex)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar inventario: " + ex.Message };
            }
        }


        public MensajeRespuesta ConsultaInventarioxSucursalProducto(int? idSucursal, string nombreProducto)
        {
            MensajeRespuesta rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaInventarioxSucursalProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", idSucursal.HasValue ? (object)idSucursal.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre_Producto", string.IsNullOrEmpty(nombreProducto) ? (object)DBNull.Value : nombreProducto);
                //cmd.Parameters.Add("@IdMensaje", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                
                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);
                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                rpta.Contenido = dt;
                rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                rpta.Mensaje = mensajeParam.Value.ToString();
            }              
            catch (Exception ex)
            {
                rpta.Codigo = -3;
                rpta.Mensaje = ex.Message;
            }
            return rpta;
        }
        public MensajeRespuesta ConsultaInventarioxSucursal(int? ID_Sucursal)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaInventarioxSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Sucursal", (object)ID_Sucursal ?? DBNull.Value);

                SqlParameter idMensajeParam = new SqlParameter("@IdMensaje", SqlDbType.Int);
                idMensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idMensajeParam);

                SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 250);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                Rpta.Contenido = dt;
                Rpta.Codigo = Convert.ToInt32(idMensajeParam.Value);
                Rpta.Mensaje = mensajeParam.Value.ToString();
            }
            catch (Exception ex)
            {
                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el inventario por ID Sucursal: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
        public MensajeRespuesta EliminarInventario(int ID_Inventario)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarInventario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Inventario", ID_Inventario);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el inventario: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }
       
    }
}