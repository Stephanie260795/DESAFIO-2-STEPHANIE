// === CLASE MATERIA ===
using System;
using MySql.Data.MySqlClient;

namespace Desafio2_Stephanie_Palacios
{
    public class Materia
    {
        public int MateriaID 
        { get; set; }
        public string NombreMateria 
        { get; set; }
        public string Docente 
        { get; set; }

            public static void Crear(){

                Console.WriteLine("\n--- Agregar Materia ---");
                Console.Write("Nombre de la materia: ");
                string nombre = Console.ReadLine();
                Console.Write("Docente: ");
                string docente = Console.ReadLine();

                using (var conexion = conexionDB.ObtenerConexion())
                {
                    conexion.Open();

                    string query = "INSERT INTO   Materia (Nombre_Materia, Docente) VALUES (@n, @d)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@d", docente);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(" Materia agregada de forma correcta.\n");
                }
            }

         public static void Listar()
        {
            using (var conexion = conexionDB.ObtenerConexion()){

                    conexion.Open();

                    string query = "SELECT * FROM Materia";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- ⌗ Lista de Materias ---");
                while (reader.Read()){


                    Console.WriteLine($"{reader["MateriaID"]}. {reader["Nombre_Materia"]} - Docente: {reader["Docente"]}");
          }
                Console.WriteLine();
               }
        }

        public static void Editar()
        {
            Listar();

            Console.Write("Ingrese el ID de la materia a editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre de materia: ");
            string nuevoNombre = Console.ReadLine();

            using (var conexion = conexionDB.ObtenerConexion()){

                conexion.Open();
                string query = "UPDATE Materia SET Nombre_Materia=@n WHERE MateriaID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@n", nuevoNombre);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Materia actualizada correctamente.\n");
            }
        }

        public static void Eliminar()
        {
            Listar();
            Console.Write("Ingrese el ID de la materia a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var conexion = conexionDB.ObtenerConexion()){

             conexion.Open();
             string query = "DELETE FROM Materia WHERE MateriaID=@id";
             MySqlCommand cmd = new MySqlCommand(query, conexion);
             cmd.Parameters.AddWithValue("@id", id);
             cmd.ExecuteNonQuery();
             Console.WriteLine("✅ Materia eliminada correctamente.\n");
            }
        }
    }
}
