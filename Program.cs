using System.Diagnostics; // Es necessari per a poder utilitzar comandes de sistema
using model.entitats;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<model.entitats.File> files = GetFitxers("./videos");
        GetDadesFitxers(files); 
        
        EscriureLlista(files);
        
        //if (files.Count > 1) files[0].Concatenate(files[1]);       
    }

    private static void GetFrames(List<model.entitats.File> files)
    {
        files[0].GetFrames();
    }

    private static List<model.entitats.File> GetFitxers(string path)
    {
        return new model.entitats.Directory(path).GetFiles();
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
        Parallel.ForEach(files, file => file.GetData());
        /* SOLUCIÓ CLÀSSICA - SENSE THREADS - SINCRONA
        foreach (model.entitats.File file in files)
        {
            file.getData();
        } 
        */
    }
}