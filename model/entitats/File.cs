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
        
        public void GetData()
        {
            ProcessStartInfo startInfo = ReadMetaData();
            Process process = ExecutarProcess(startInfo);
            string dades = process.StandardError.ReadToEnd();
            this.SetDadesFromText(dades);
        }

        public void Concatenate(File file)
        {
            ProcessStartInfo startInfo = this.Concat(file);
            Process process = ExecutarProcess(startInfo);
            process.StandardOutput.ReadToEnd();
        }
        private void SetDadesFromText(string dades)
        {
            string[] lines = dades.Split('\n');
            
            foreach (string line in lines) {
                string wLine = line.Trim();
                if (wLine.Contains("Duration:")) this.property.Duration = GetDuration(wLine);
                if (wLine.Contains("creation_time")) this.property.CreationTime = GetCreationTime(wLine);
            } 

            this.property.NbFrames = GetNbFrames();
            
        }
        private long GetNbFrames()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffprobe";
            startInfo.Arguments = $" -v error -select_streams v:0 -show_entries stream=nb_frames -of default=noprint_wrappers=1:nokey=1 {this.Path}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            
            string dades = process.StandardOutput.ReadToEnd();
            return long.Parse(dades);
            
        }
        
        
/*
    TOTS ELS VIDEOS EL MATEIX CODEC

    ffmpeg -f concat -safe 0 -i /home/miquel/Downloads/myList.txt   -c copy   output.mp4

    myList.txt
    file /home/miquel/Projectes/Video/videos/pexels-life-on-super-3209968-1920x1080-18fps.mp4
    file /home/miquel/Projectes/Video/videos/pexels-life-on-super-3209971-1920x1080-18fps.mp4

    // startInfo.Arguments = $"-f concat -safe 0 -i ./videos/myList.txt -c copy ./videos/merged.mp4";
*/
/*
    TOTS ELS VIDEOS AMB DIFERENT CODEC

    ffmpeg -i pexels-life-on-super-3209968-1920x1080-18fps.mp4 \
        -i pexels-life-on-super-3209971-1920x1080-18fps.mp4 \
        -filter_complex "[0:v:0][0:a:0][1:v:0][1:a:0]concat=n=2:v=1:a=1[outv][outa]" \
        -map "[outv]" -map "[outa]" merged.mp4

*/
 
        private ProcessStartInfo Concat(File file)  // https://trac.ffmpeg.org/wiki/Concatenate
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
        
            startInfo.Arguments = this.ConcatArgs(file.Path); // output
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }
        private ProcessStartInfo ReadMetaData()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.Arguments = $"-i {this.Path} -f null -";
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }
        private Process ExecutarProcess(ProcessStartInfo startInfo)
        {
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            return process;
        }

        private string ConcatArgs(string fileName) {
            string args = $" -i  \"{this.Path}\"  "; // 1r video
            args += $" -i  \"{fileName}\"  "; // 2n video
            args += $" -filter_complex \"[0:v:0][1:v:0]"; // stream 1 i 2
            args += $" concat=n=2:v=1[outv]\" "; // concat
            args += $" -map \"[outv]\" ./videos/merged.mp4";
            return args;
        }
        private DateTime GetCreationTime(string line)
        {
            string[] words = line.Split(' ');
            return System.Convert.ToDateTime(words[4]);
        }
        private string GetDuration(string line)
        {
            string[] words = line.Split(' ');
            return words[1]; 
        }

        public override string ToString() { return $"File: {Name} {Path} \n Size: {Size} \n Properties: {property.ToString()}";  }

        // Getters i setters
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public long Size { get => size; set => size = value; }

        public long NbFrames { get => size; set => size = value; }
    }
}