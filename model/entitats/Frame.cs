namespace model.entitats {
    class Frame {
        private string image;
        private TimeOnly position;
        private long duration;

        public Frame(string image, TimeOnly position, long duration) {
            this.image = image;
            this.position = position;
            this.duration = duration;
        }
        public string Image { get => image; set => image = value; }
        public TimeOnly Position { get => position; set => position = value; }
        public long Duration { get => duration; set => duration = value; }
    }
}