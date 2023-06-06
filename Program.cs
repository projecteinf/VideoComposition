using System;
using model.entitats;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<model.entitats.File> files = GetFitxers(".");
        EscriureLlista(files);        
    }
    private static List<model.entitats.File> GetFitxers(string path)
    {
        return new model.entitats.Directory(path).getFiles();
    }
    private static void EscriureLlista(List<model.entitats.File> files)
    {
        foreach (model.entitats.File file in files) Console.WriteLine(file.ToString());
    }
}