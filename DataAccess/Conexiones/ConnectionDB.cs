using System.Configuration;
using System.Data.SqlClient;

public class ConnectionDB
{
    private readonly SqlConnection Conexion;

    public ConnectionDB()
    {
        // Leer la cadena de conexión desde web.config
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        Conexion = new SqlConnection(connectionString);
    }

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