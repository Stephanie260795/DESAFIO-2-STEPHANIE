using MySql.Data.MySqlClient;

namespace Desafio2_Stephanie_Palacios
{
    public class conexionDB
    {
        private static string servidor = "localhost";
        private static string baseDatos = "datos_desafio2";
        private static string usuario = "root";
        private static string password = "";

        private static string cadenaConexion = $"server={servidor};database={baseDatos};uid={usuario};pwd={password};";

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
