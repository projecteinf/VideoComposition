using System;
using model.entitats;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<model.entitats.File> files = new List<model.entitats.File>();
        files.Add(new model.entitats.File("file1", "path1", 100, 1.1f));
        model.entitats.Directory directory = new model.entitats.Directory(".");
        foreach (model.entitats.File file in directory.getFiles()) Console.WriteLine(file.ToString());
        
        
    }
}