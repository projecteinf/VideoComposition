using System.Diagnostics; // Es necessari per a poder utilitzar comandes de sistema
using model.entitats;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<model.entitats.File> files = GetFitxers("./videos");
        DateTime start = DateTime.Now;
        GetDadesFitxers(files); 
        DateTime end = DateTime.Now;
        Console.WriteLine($"Temps: {end-start}");
        EscriureLlista(files);
        Console.WriteLine("Concatenar");
        // if (files.Count > 1) files[0].concat(files[1]);       
    }
    private static List<model.entitats.File> GetFitxers(string path)
    {
        return new model.entitats.Directory(path).getFiles();
    }
    private static void EscriureLlista(List<model.entitats.File> files)
    {
        foreach (model.entitats.File file in files) Console.WriteLine(file.ToString());
    }
    private static void GetDadesFitxers(List<model.entitats.File> files)
    {
        /* SOLUCIÓ AMB THREADS
        
        List<Thread> threads = new List<Thread>();
        
        foreach (model.entitats.File file in files) {
            // file.getData();
            Thread thread = new Thread(() => file.getData());
            thread.Start();
            threads.Add(thread);
        }
        foreach (Thread thread in threads) thread.Join(); // Espera a que tots els threads acabin 
        */
        Parallel.ForEach(files, file => file.getData());
        /* SOLUCIÓ CLÀSSICA - SENSE THREADS - SINCRONA
        foreach (model.entitats.File file in files)
        {
            file.getData();
        } 
        */
    }
}