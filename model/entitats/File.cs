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
        
        public void getData()
        {
            ProcessStartInfo startInfo = prepararProcess();
            string dades = executarProcess(startInfo);
            string[] lines = dades.Split('\n');
            //Console.WriteLine($"FILE: {Name}");
            foreach (string line in lines) {
                //Console.WriteLine(line);
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
        

        public void concat(File file)
        {
            ProcessStartInfo startInfo = prepararConcat(file);
            executarProcess(startInfo);
        }

        private ProcessStartInfo prepararConcat(File file)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";

/*

    ffmpeg -f concat -safe 0 -i /home/miquel/Downloads/myList.txt   -c copy   output.mp4

    myList.txt
    file /home/miquel/Projectes/Video/videos/pexels-life-on-super-3209968-1920x1080-18fps.mp4
    file /home/miquel/Projectes/Video/videos/pexels-life-on-super-3209971-1920x1080-18fps.mp4
*/

            // startInfo.Arguments = $"-i \"concat:{this.Path}|{file.Path}\"  ./videos/merged.mp4";
            startInfo.Arguments = $"-f concat -safe 0 -i ./videos/myList.txt -c copy ./videos/merged.mp4";
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }

        private ProcessStartInfo prepararProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.Arguments = $"-i {this.Path} -f null -";
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }
        private string executarProcess(ProcessStartInfo startInfo)
        {
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            string dades = process.StandardError.ReadToEnd();
            string dades2 = process.StandardOutput.ReadToEnd();
            Console.WriteLine(dades);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(dades2);
            // process.WaitForExit();
            return dades;
        }
        public override string ToString() { return $"File: {Name} {Path} \n Size: {Size} \n Properties: {property.ToString()}";  }

        // Getters i setters
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public long Size { get => size; set => size = value; }
    }
}