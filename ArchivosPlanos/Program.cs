using System;

class Program
{
    static void Main()
    {
        if (Autenticacion.Login())
        {
            Menu();
        }
        else
        {
            Console.WriteLine("Usuario bloqueado o demasiados intentos.");
        }
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Crear Persona");
            Console.WriteLine("2. Editar Persona");
            Console.WriteLine("3. Eliminar Persona");
            Console.WriteLine("4. Mostrar Informe");
            Console.WriteLine("5. Salir");

            Console.Write("Opción: ");
            string opc = Console.ReadLine();

            switch (opc)
            {
                case "1": PersonaManager.Crear(); break;
                case "2": PersonaManager.Editar(); break;
                case "3": PersonaManager.Eliminar(); break;
                case "4": InformeManager.MostrarInforme(); break;
                case "5": return;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }
}
