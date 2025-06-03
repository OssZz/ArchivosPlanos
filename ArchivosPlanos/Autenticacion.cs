using System;
using System.IO;

public class Autenticacion
{
    private static string usersPath = "Users.txt";
    public static string UsuarioActual { get; private set; }

    public static bool Login()
    {
        int intentos = 0;

        while (intentos < 3)
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            var lines = File.ReadAllLines(usersPath);
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts[0] == user)
                {
                    if (parts[2].ToLower() == "false")
                    {
                        Logger.Log(user, "Intento de login en cuenta bloqueada");
                        return false;
                    }

                    if (parts[1] == pass)
                    {
                        UsuarioActual = user;
                        Logger.Log(user, "Login exitoso");
                        return true;
                    }
                    else
                    {
                        intentos++;
                        Logger.Log(user, $"Login fallido (intento {intentos})");

                        if (intentos >= 3)
                        {
                            parts[2] = "false";
                            lines[i] = string.Join(",", parts);
                            File.WriteAllLines(usersPath, lines);
                            Logger.Log(user, "Usuario bloqueado por intentos fallidos");
                            return false;
                        }
                    }
                }
            }

            Console.WriteLine("Credenciales incorrectas.");
        }

        return false;
    }
}
