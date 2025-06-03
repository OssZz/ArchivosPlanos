using System.IO;

public static class ArchivoHelper
{
    public static void VerificarArchivos()
    {
        if (!File.Exists("Users.txt"))
            File.WriteAllText("Users.txt", "jzuluaga,P@ssw0rd123!,true");

        if (!File.Exists("personas.txt"))
            File.WriteAllText("personas.txt", "");

        if (!File.Exists("log.txt"))
            File.WriteAllText("log.txt", "");
    }
}
