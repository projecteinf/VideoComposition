using System.Diagnostics;

namespace model.entitats
{
    public class File {
        private string name;
        private string path;
        private long size;
        private Property property;
        
        public File(string name, string path, long size) {
            this.property = new Property();
            this.name = name;
            this.path = path;
            this.size = size;
        }

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        

        public override string ToString() { return $"File: {Name} {Path} \n Size: {Size} \n Properties: {property.ToString()}";  }

        public void getData()
        {
            ProcessStartInfo startInfo = prepararProcess();
            string dades = executarProcess(startInfo);
            string[] lines = dades.Split('\n');
            foreach (string line in lines) {
                string wLine = line.Trim();
                if (wLine.Contains("Duration:")) this.property.Duration = getDuration(wLine);
                if (wLine.Contains("creation_time")) this.property.CreationTime = getCreationTime(wLine);
            } 
        }
        private DateTime getCreationTime(string line)
        {
            string[] words = line.Split(' ');
            return System.Convert.ToDateTime(words[4]);
        }
        private string getDuration(string line)
        {
            string[] words = line.Split(' ');
            return words[1]; 
        }
        private ProcessStartInfo prepararProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.Arguments = $"-i {this.Path} -f null -";
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }

        private string executarProcess(ProcessStartInfo startInfo)
        {
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            string dades = process.StandardError.ReadToEnd();
            // process.WaitForExit();
            return dades;
        }

        public long Size { get => size; set => size = value; }
    }
}