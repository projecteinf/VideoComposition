namespace model.entitats
{
    class Property
    {
        
        private string duration;
        private DateTime creationTime;

        public override string ToString() { return $"Property: {Duration} {CreationTime}"; }
        
        public string Duration { get => duration; set => duration = value; }
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }
    }
}