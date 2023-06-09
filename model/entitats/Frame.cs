namespace model.entitats {
    class Frame {
        private string image;
        private float position;
        private float duration;

        public string GetImage() { return image; }
        public float GetPosition() { return position; }
        
        public string SetImage(string image) { return this.image; }
        public float SetPosition(float position) { return this.position; }
        

        public Frame(float position) {
            this.position = position;
        }

        public Frame(string image, float position) {
            this.image = image;
            this.position = position;
        }
        
    }
}