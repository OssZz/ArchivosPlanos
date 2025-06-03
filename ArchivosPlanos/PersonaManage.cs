using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class PersonaManager
{
    private static string path = "personas.txt";

    public static void Crear()
    {
        Console.Write("ID: ");
        string id = Console.ReadLine();
        if (!int.TryParse(id, out _)) { Console.WriteLine("ID inválido."); return; }

        var existentes = File.Exists(path) ? File.ReadAllLines(path) : new string[0];
        if (existentes.Any(p => p.StartsWith(id + ","))) { Console.WriteLine("ID ya existe."); return; }

        Console.Write("Nombres: ");
        string nombres = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nombres)) return;

        Console.Write("Apellidos: ");
        string apellidos = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(apellidos)) return;

        Console.Write("Ciudad: ");
        string ciudad = Console.ReadLine();

        Console.Write("Teléfono: ");
        string tel = Console.ReadLine();
        if (!tel.All(char.IsDigit)) return;

        Console.Write("Saldo: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal saldo) || saldo < 0)
        {
            Console.WriteLine("Saldo inválido."); return;
        }

        File.AppendAllText(path, $"{id},{nombres},{apellidos},{ciudad},{tel},{saldo}\n");
        Logger.Log(Autenticacion.UsuarioActual, $"Persona creada (ID {id})");
    }

    public static void Editar()
    {
        Console.Write("ID a editar: ");
        string id = Console.ReadLine();
        var personas = File.ReadAllLines(path).ToList();

        int index = personas.FindIndex(p => p.StartsWith(id + ","));
        if (index == -1) { Console.WriteLine("ID no encontrado."); return; }

        var campos = personas[index].Split(',');

        Console.Write($"Nombres ({campos[1]}): ");
        string nombres = Console.ReadLine();
        campos[1] = string.IsNullOrWhiteSpace(nombres) ? campos[1] : nombres;

        Console.Write($"Apellidos ({campos[2]}): ");
        string apellidos = Console.ReadLine();
        campos[2] = string.IsNullOrWhiteSpace(apellidos) ? campos[2] : apellidos;

        Console.Write($"Ciudad ({campos[3]}): ");
        string ciudad = Console.ReadLine();
        campos[3] = string.IsNullOrWhiteSpace(ciudad) ? campos[3] : ciudad;

        Console.Write($"Teléfono ({campos[4]}): ");
        string tel = Console.ReadLine();
        campos[4] = string.IsNullOrWhiteSpace(tel) ? campos[4] : tel;

        Console.Write($"Saldo ({campos[5]}): ");
        string saldo = Console.ReadLine();
        campos[5] = string.IsNullOrWhiteSpace(saldo) ? campos[5] : saldo;

        personas[index] = string.Join(",", campos);
        File.WriteAllLines(path, personas);
        Logger.Log(Autenticacion.UsuarioActual, $"Persona editada (ID {id})");
    }

    public static void Eliminar()
    {
        Console.Write("ID a eliminar: ");
        string id = Console.ReadLine();
        var personas = File.ReadAllLines(path).ToList();

        int index = personas.FindIndex(p => p.StartsWith(id + ","));
        if (index == -1) { Console.WriteLine("ID no encontrado."); return; }

        Console.WriteLine("Datos: " + personas[index]);
        Console.Write("¿Desea eliminar? (S/N): ");
        if (Console.ReadLine().ToUpper() == "S")
        {
            personas.RemoveAt(index);
            File.WriteAllLines(path, personas);
            Logger.Log(Autenticacion.UsuarioActual, $"Persona eliminada (ID {id})");
        }
    }
}
