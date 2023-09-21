using System;
using System.Collections.Generic;

class Program
{
    static List<Tarea> tareas = new List<Tarea>();
    static int id = 1;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Gestor de Tareas:");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    ListarTareas();
                    break;
                case "3":
                    MarcarComoCompletada();
                    break;
                case "4":
                    EliminarTarea();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Ingrese la descripción de la tarea: ");
        string descripcion = Console.ReadLine();

        Tarea nuevaTarea = new Tarea
        {
            ID = id++,
            Descripcion = descripcion,
            FechaCreacion = DateTime.Now,
            Completada = false
        };

        tareas.Add(nuevaTarea);
        Console.WriteLine("Tarea agregada con éxito.");
    }

    static void ListarTareas()
    {
        Console.WriteLine("Lista de Tareas:");
        foreach (var tarea in tareas)
        {
            Console.WriteLine($"{tarea.ID}. {tarea.Descripcion} (Creada el {tarea.FechaCreacion}) - {(tarea.Completada ? "Completada" : "Pendiente")}");
        }
    }

    static void MarcarComoCompletada()
    {
        Console.Write("Ingrese el ID de la tarea a marcar como completada: ");
        if (int.TryParse(Console.ReadLine(), out int tareaID))
        {
            var tarea = tareas.Find(t => t.ID == tareaID);
            if (tarea != null)
            {
                tarea.Completada = true;
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("ID de tarea no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID de tarea no válido.");
        }
    }

    static void EliminarTarea()
    {
        Console.Write("Ingrese el ID de la tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int tareaID))
        {
            var tarea = tareas.Find(t => t.ID == tareaID);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("ID de tarea no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID de tarea no válido.");
        }
    }
}

class Tarea
{
    public int ID { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Completada { get; set; }
}
