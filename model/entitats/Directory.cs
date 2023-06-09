namespace model.entitats
{
    public class Directory
    {
        private List<model.entitats.File> Files;
        public Directory() { }

        public Directory(string path) { 
            this.Files = SetFiles(path);
        }

        public static void Move(string path, string newPath)
        {
            System.IO.Directory.Move(path, newPath);
        }
        private List<model.entitats.File> SetFiles(string path)
        {
            List<model.entitats.File> files = new List<model.entitats.File>();

            String[] filesDirectory = System.IO.Directory.GetFiles(path);
            foreach (String file in filesDirectory) {
                files.Add(new model.entitats.File(file, file, new FileInfo(file).Length));
            }
            return files;
        }

        public List<model.entitats.File> GetFiles() { return Files; }
    }
}
