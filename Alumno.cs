using System;
using MySql.Data.MySqlClient;

namespace Desafio2_Stephanie_Palacios
{
    public class Alumno
    {
        public int AlumnoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Grado { get; set; }

        public static void Crear(){

            Console.WriteLine("\n------ Agregar Alumno -----");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Fecha de nacimiento (año-mes-dia): ");
            string fecha = Console.ReadLine();
            Console.Write("Grado (ejemplo: 'Noveno Grado', '1°', 'Segundo Año'): ");
            string grado = Console.ReadLine();

            using (var conexion = conexionDB.ObtenerConexion()){

                conexion.Open();
                string query = "INSERT INTO Alumno (Nombre, Apellido, Fecha_nacimiento, Grado) VALUES (@n, @a, @f, @g)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@a", apellido);
                cmd.Parameters.AddWithValue("@f", fecha);
                cmd.Parameters.AddWithValue("@g", grado);
                cmd.ExecuteNonQuery();
                Console.WriteLine("✓ Alumno agregado correctamente.\n");
            }
        }

        public static void Listar(){

            using (var conexion = conexionDB.ObtenerConexion()){

            conexion.Open();
            string query = "SELECT * FROM Alumno";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n-'-- Lista de Alumnos ---");
            while (reader.Read()){

                    Console.WriteLine($"{reader["AlumnoID"]}. {reader["Nombre"]} {reader["Apellido"]} - {reader["Grado"]}");
                }
            Console.WriteLine();
            }
        }

        public static void Editar(){

            Listar();
            Console.Write("Ingrese el ID del alumno a editar: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();

             using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();
                    string query = "UPDATE Alumno SET Nombre=@n WHERE AlumnoID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@n", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("✓ Alumno actualizado de froma correcta.\n");
            }
        }

        public static void Eliminar()
        {
            Listar();
            Console.Write("Ingrese el ID del alumno a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();
                string query = "DELETE FROM Alumno WHERE AlumnoID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Alumno eliminado de forma correcta.\n");
            }
        }
    }
}