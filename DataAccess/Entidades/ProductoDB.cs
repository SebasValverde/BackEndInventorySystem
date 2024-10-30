using Atributos;
using DataAccess.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class ProductoBD
    {
        ConnectionDB Cn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public MensajeRespuesta InsertarProducto(Producto Producto)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "NuevoProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Producto", Producto.Nombre_Producto);
                cmd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@ID_TipoProducto", Producto.ID_TipoProducto);
                cmd.Parameters.AddWithValue("@Fecha_Caducidad", Producto.Fecha_Caducidad);
                cmd.Parameters.AddWithValue("@ID_Proveedor", Producto.ID_Proveedor);
                cmd.Parameters.AddWithValue("@CostoUnitario", Producto.CostoUnitario);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al insertar el producto: " + ex.Message; ;
            }
            finally
            {
                Cn.CloseConnection();
            }

            return Rpta;
        }

        public MensajeRespuesta ConsultaProducto(int ID_Producto)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", ID_Producto);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el producto: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ModificarProducto(Producto Producto)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ModificarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", Producto.ID_Producto);
                cmd.Parameters.AddWithValue("@NuevoNombre_Producto", Producto.Nombre_Producto);
                cmd.Parameters.AddWithValue("@NuevaDescripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@NuevoID_TipoProducto", Producto.ID_TipoProducto);
                cmd.Parameters.AddWithValue("@NuevaFecha_Caducidad", Producto.Fecha_Caducidad);
                cmd.Parameters.AddWithValue("@NuevoID_Proveedor", Producto.ID_Proveedor);
                cmd.Parameters.AddWithValue("@NuevoCostoUnitario", Producto.CostoUnitario);


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
                Rpta.Mensaje = "Se ha presentado un inconveniente al modificar el producto: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta EliminarProducto(int ID_Producto)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "EliminarProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", ID_Producto);

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
                Rpta.Mensaje = "Se ha presentado un inconveniente al eliminar el producto: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

        public MensajeRespuesta ConsultaProductoNombreTipo(string NombreProducto, string Categoria)
        {
            MensajeRespuesta Rpta = new MensajeRespuesta();
            try
            {
                cmd.Connection = Cn.openSqlConnection();
                cmd.CommandText = "ConsultaProductoNombreTipo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Producto", NombreProducto);
                cmd.Parameters.AddWithValue("@Categoria", Categoria);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cmd.Parameters.Clear();
                Rpta.Codigo = 0;
                Rpta.Mensaje = "Consulta exitosa";
                Rpta.Contenido = dt;
            }
            catch (Exception ex)
            {

                Rpta.Codigo = -11;
                Rpta.Mensaje = "Se ha presentado un inconveniente al consultar el producto: " + ex.Message;
            }
            finally
            {
                Cn.CloseConnection();
            }
            return Rpta;
        }

    }
}
