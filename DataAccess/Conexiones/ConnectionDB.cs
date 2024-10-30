using System.Data.SqlClient;

namespace DataAccess.Conexiones
{
    public class ConnectionDB
    {
        //Conexion de Sergio
        //private SqlConnection Conexion = new SqlConnection("*");
        //Conexion de Sebastian
        private SqlConnection Conexion = new SqlConnection("server=DESKTOP-7BKML4C\\SQLEXPRESS;Database=InventarioDB;Persist Security Info=True; User ID=sa; Password=sebas12345");
        //Conexion de Erick
        //private SqlConnection Conexion = new SqlConnection("*");
        public SqlConnection openSqlConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed) Conexion.Open();
            return Conexion;
        }
        public SqlConnection CloseConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
            return Conexion;
        }
    }
}
