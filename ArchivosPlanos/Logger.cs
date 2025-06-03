using System;
using System.IO;

public static class Logger
{
    private static string logPath = "log.txt";

    public static void Log(string usuario, string mensaje)
    {
        string linea = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {usuario} - {mensaje}";
        File.AppendAllText(logPath, linea + Environment.NewLine);
    }
}
