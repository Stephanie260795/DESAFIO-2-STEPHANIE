using System;
using MySql.Data.MySqlClient;

namespace Desafio2_Stephanie_Palacios
{
    public class Expediente
    {
        public int ExpedienteID { get; set; }
        public int AlumnoID { get; set; }
        public int MateriaID { get; set; }
        public double NotaFinal { get; set; }
        public string Observaciones { get; set; }

        public static void Crear()
        {
        Console.WriteLine("\n--- Crear Expediente ---");
        Alumno.Listar();
        Console.Write("ID del Alumno: ");
        int alumnoID = int.Parse(Console.ReadLine());

        Materia.Listar();
        Console.Write("ID de la Materia: ");
        int materiaID = int.Parse(Console.ReadLine());

        Console.Write("Nota Final: ");
        double nota = double.Parse(Console.ReadLine());
        Console.Write("Observaciones: ");
        string obs = Console.ReadLine();

        using (var conexion = conexionDB.ObtenerConexion()){

             conexion.Open();
             string query = "INSERT INTO Expediente (AlumnoID, MateriaID, Notal_Final, Observaciones) VALUES (@a, @m, @n, @o)";
             MySqlCommand cmd = new MySqlCommand(query, conexion);
             cmd.Parameters.AddWithValue("@a", alumnoID);
             cmd.Parameters.AddWithValue("@m", materiaID);
             cmd.Parameters.AddWithValue("@n", nota);
             cmd.Parameters.AddWithValue("@o", obs);
             cmd.ExecuteNonQuery();
             Console.WriteLine("✅ Expediente creado correctamente.\n");
            }
        }

        public static void Listar()
        {
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT e.ExpedienteID, a.Nombre AS Alumno, m.Nombre_Materia AS Materia, e.Notal_Final, e.Observaciones " + "FROM Expediente e " + "JOIN Alumno a ON e.AlumnoID = a.AlumnoID " + "JOIN Materia m ON e.MateriaID = m.MateriaID";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Lista de Expedientes ---");
                while (reader.Read()){

                Console.WriteLine($"{reader["ExpedienteID"]}. Alumno: {reader["Alumno"]} | Materia: {reader["Materia"]} | Nota: {reader["Notal_Final"]} | Obs: {reader["Observaciones"]}");
                }
                Console.WriteLine();
           }
      }

        public static void Editar()
        {
            Listar();
            Console.Write("Ingrese el ID del expediente a editar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nueva nota final: ");
            double nuevaNota = double.Parse(Console.ReadLine());
            Console.Write("Nueva observacion: ");
            string nuevaobservacion = Console.ReadLine();
            using (var conexion = conexionDB.ObtenerConexion()){

                conexion.Open();
                string query = "UPDATE Expediente SET Notal_Final=@n, Observaciones=@o WHERE ExpedienteID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@n", nuevaNota);
                cmd.Parameters.AddWithValue("@o", nuevaobservacion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Expediente actualizado correctamente.\n");
            }
        }

        public static void Eliminar()
        {
            Listar();
            Console.Write("Ingrese el ID del expediente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var conexion = conexionDB.ObtenerConexion()){

            conexion.Open();
            string query = "DELETE FROM Expediente WHERE ExpedienteID=@id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Expediente eliminado correctamente.\n");
            }
        }
    }
}
