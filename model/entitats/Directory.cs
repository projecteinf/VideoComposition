namespace model.entitats
{
    public class Directory
    {
        private List<model.entitats.File> Files;

        public Directory(string path) { 
            Files = new List<model.entitats.File>(); 
            setFiles(path);
        }
        private void setFiles(string path)
        {
            String[] filesDirectory = System.IO.Directory.GetFiles(path);
            foreach (String file in filesDirectory) {
                Files.Add(new model.entitats.File(file, file, 100, 1.1f));
            }
        }

        public List<model.entitats.File> getFiles() { return Files; }
    }
}
