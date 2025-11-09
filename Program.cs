using System;

namespace Desafio2_Stephanie_Palacios
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestión de Alumnos");
                Console.WriteLine("2. Gestión de Materias");
                Console.WriteLine("3. Gestión de Expedientes");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion){
                 case "1": MenuAlumno(); break;
                 case "2": MenuMateria(); break;
                 case "3": MenuExpediente(); break;
                 case "0": return;
                 default: Console.WriteLine("Opción no válida."); break;
                }
            }}

        static void MenuAlumno(){

             Console.WriteLine("\n----- Gestión de Alumnos -----");
             Console.WriteLine("1. Agregar");
             Console.WriteLine("2. Listar");
             Console.WriteLine("3. Editar");
             Console.WriteLine("4. Eliminar");
             Console.Write("Seleccione una opción: ");
            string op = Console.ReadLine();

            switch (op){

             case "1": Alumno.Crear(); break;
             case "2": Alumno.Listar(); break;
             case "3": Alumno.Editar(); break;
             case "4": Alumno.Eliminar(); break;
             default: Console.WriteLine("Opción inválida."); break;
        }
      }

        static void MenuMateria(){

        Console.WriteLine("\n--- Gestión de Materias ---");
        Console.WriteLine("1. Agregar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("3. Editar");
        Console.WriteLine("4. Eliminar");
        Console.Write("Seleccione una opción: ");
        string op = Console.ReadLine();

            switch (op){

            case "1": Materia.Crear(); break;
            case "2": Materia.Listar(); break;
            case "3": Materia.Editar(); break;
            case "4": Materia.Eliminar(); break;
            default: Console.WriteLine("Opción inválida."); break;
            }
        }

        static void MenuExpediente(){

            Console.WriteLine("\n--- Gestión de Expedientes ---");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.Write("Seleccione una opción: ");
            string op = Console.ReadLine();

            switch (op){

            case "1": Expediente.Crear(); break;
            case "2": Expediente.Listar(); break;
            case "3": Expediente.Editar(); break;
            case "4": Expediente.Eliminar(); break;
            default: Console.WriteLine("Opción inválida."); break;
            }
    }
    }}
