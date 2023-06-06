using System;
using model.entitats;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<model.entitats.File> files = new List<model.entitats.File>();
        files.Add(new model.entitats.File("file1", "path1", 100, 1.1f));
        String[] filesDirectory = System.IO.Directory.GetFiles(".");
        foreach (String file in filesDirectory)
        {
            Console.WriteLine(file);
        }
        Console.WriteLine(files[0].ToString());
    }
}