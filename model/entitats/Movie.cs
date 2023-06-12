using System.Diagnostics;

namespace model.entitats {
    class Movie {
        List <File> files;
        string name;
        public Movie(string folder, string name) {
            this.name = name;
            this.files = new Directory(folder).GetFiles();
            Parallel.ForEach(this.files, file => file.GetData());
            this.ReverseMovie();
        }

        public void ReverseMovie() {
            this.files[0].GetImatges(this.name);
            long index=1;
            Directory.CreateDirectory($"./images/{this.name}/reverse");
            for(long i = this.files[0].GetNbFrames(); i > 0; i--) {
                Directory.Move($"./images/{this.name}/{i}.jpg", $"./images/{this.name}/reverse/{index}.jpg");
                index++;
                // ffmpeg.StartInfo.Arguments = "-y -framerate 30 -i " + imagesPath + "%d.jpg -c:v libx264 -r 30 -pix_fmt yuv420p " + videoPath
            }
            ProcessStartInfo startInfo = this.CreateReverseVideo();
            Process process = ExecutarProcess(startInfo);
            process.StandardOutput.ReadToEnd();
        }

        private Process ExecutarProcess(ProcessStartInfo startInfo)
        {
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            return process;
        }
        private ProcessStartInfo CreateReverseVideo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ffmpeg";
            // Versió ràpida
            // startInfo.Arguments = $" -y -framerate 60 -i ./images/reverse/%d.jpg -c:v libx264 -r 60 -pix_fmt yuv420p ./videos/reverse.mp4";
            // Versió lenta
            // startInfo.Arguments = $" -y -framerate 10 -i ./images/reverse/%d.jpg -c:v libx264 -r 10 -pix_fmt yuv420p ./videos/reverse.mp4";
            // SuperSlow
            // Versió lenta
            startInfo.Arguments = $" -y -framerate 1 -i ./images/{this.name}/reverse/%d.jpg -c:v libx264 -r 1 -pix_fmt yuv420p ./videos/reverse.mp4";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            return startInfo;
        }
    }
}