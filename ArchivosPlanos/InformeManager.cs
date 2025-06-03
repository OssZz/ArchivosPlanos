using System;
using System.IO;
using System.Linq;

public static class InformeManager
{
    public static void MostrarInforme()
    {
        if (!File.Exists("personas.txt")) return;

        var personas = File.ReadAllLines("personas.txt")
            .Select(p => p.Split(','))
            .GroupBy(p => p[3]);

        decimal totalGeneral = 0;

        foreach (var grupo in personas)
        {
            Console.WriteLine($"\nCiudad: {grupo.Key}");
            Console.WriteLine("ID\tNombre\tApellido\tSaldo");

            decimal subtotal = 0;

            foreach (var p in grupo)
            {
                Console.WriteLine($"{p[0]}\t{p[1]}\t{p[2]}\t\t{decimal.Parse(p[5]):N2}");
                subtotal += decimal.Parse(p[5]);
            }

            Console.WriteLine($"Total {grupo.Key}: \t\t\t{subtotal:N2}");
            totalGeneral += subtotal;
        }

        Console.WriteLine($"\nTOTAL GENERAL: {totalGeneral:N2}");
        Logger.Log(Autenticacion.UsuarioActual, "Generó informe");
    }
}
