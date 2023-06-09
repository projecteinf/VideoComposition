using System.Diagnostics;


namespace model.entitats
{
    public class File {
        private string name;
        private string path;
        private long size;
        private Property property;
        private List<Frame> frames; 
        
        
        public File(string name, string path, long size) {
            this.property = new Property();
            this.frames = new List<Frame>();
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
            this.GetFramesData();
        }

        public void Concatenate(File file)
        {
            ProcessStartInfo startInfo = this.Concat(file);
            Process process = ExecutarProcess(startInfo);
            process.StandardOutput.ReadToEnd();
        }

        public void GetFramesData() {
            
            ProcessStartInfo startInfo = this.GetFramesDataJSON();
            Process process = ExecutarProcess(startInfo);
            string dades=process.StandardOutput.ReadToEnd();
            string[] frames = dades.Split("[FRAME]");
            foreach (string frame in frames) {
                if (frame != "") {
                    string position = frame.Substring(14,8);
                    this.frames.Add(new Frame($"{position}.jpg", float.Parse(position)));
                } 
            }
        }
/*

"[FRAME]\npkt_pts_time=0.000000\npict_type=I\n[/FRAME]\n[FRAME]\npkt_pts_time=0.055556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.111111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.166667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.222222\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=0.277778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.333333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.388889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.444444\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=0.500000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.555556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.611111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.666667\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=0.722222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.777778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.833333\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=0.888889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=0.944444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.000000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.055556\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=1.111111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.166667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.222222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.277778\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=1.333333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.388889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.444444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.500000\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=1.555556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.611111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.666667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.722222\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=1.777778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.833333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.888889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=1.944444\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=2.000000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.055556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.111111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.166667\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=2.222222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.277778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.333333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.388889\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=2.444444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.500000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.555556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.611111\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=2.666667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.722222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.777778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.833333\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=2.888889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=2.944444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.000000\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=3.055556\npict_type=I\n[/FRAME]\n[FRAME]\npkt_pts_time=3.111111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.166667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.222222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.277778\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=3.333333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.388889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.444444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.500000\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=3.555556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.611111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.666667\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.722222\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=3.777778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.833333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.888889\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=3.944444\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=4.000000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.055556\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.111111\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.166667\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=4.222222\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.277778\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.333333\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.388889\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=4.444444\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.500000\npict_type=B\n[/FRAME]\n[FRAME]\npkt_pts_time=4.555556\npict_type=P\n[/FRAME]\n[FRAME]\npkt_pts_time=4.611111\npict_type=P\n[/FRAME]\n"

*/
        private ProcessStartInfo GetFramesDataJSON()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffprobe";
            startInfo.Arguments = $"-v error -select_streams v:0 -show_entries frame=pkt_pts_time,pict_type {this.Path}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }


        public void GetImatges() {
            long framenb = 0;
            foreach (Frame frame in this.frames) {
                ProcessStartInfo startInfo = this.GetFramesFile(frame, ++framenb);
                Process process = ExecutarProcess(startInfo);
                process.StandardOutput.ReadToEnd();
            }
            
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
        public long GetNbFrames()
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
        // ffmpeg -i videos/merged.mp4 -ss 00:00:01.000 -vframes 1 image.jpg

        private ProcessStartInfo GetFramesFile(Frame frame, long number)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            startInfo.Arguments = $"-i {this.Path} -ss 00:00:{frame.GetPosition()} -vframes {number} ./images/{number}.jpg";
            startInfo.RedirectStandardOutput = true;
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

        public override string ToString()
        {
            string frameInfo = "";
            foreach(Frame frame in this.frames) {
                frameInfo += frame.ToString()+"\n";
            }
            return $"File: {Name} {Path} \n Size: {Size} \n Properties: {property.ToString()}\n{frameInfo}";
        }

        
        // Getters i setters
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public long Size { get => size; set => size = value; }

        public long NbFrames { get => size; set => size = value; }
    }
}