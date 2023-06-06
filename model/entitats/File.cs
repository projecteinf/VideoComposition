namespace model.entitats
{
    public class File {
        private string name;
        private string path;
        private long size;
        private float duration;
        
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public long Size { get => size; set => size = value; }
        public float Duration { get => duration; set => duration = value; }

        public override string ToString() { return $"File: {Name} {Path} {Size} {Duration}";  }
    }
}