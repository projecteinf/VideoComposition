namespace model.entitats
{
    class Property
    {
        
        private string duration;
        private DateTime creationTime;
        private long nbFrames;
        
        public override string ToString() {
            return $"Duration: {this.duration} \nCreation time: {this.creationTime} \nNb frames: {this.nbFrames}";
        }
        
        public string Duration { get => duration; set => duration = value; }
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }
        public long NbFrames { get => nbFrames; set => nbFrames = value; }  
    }
}