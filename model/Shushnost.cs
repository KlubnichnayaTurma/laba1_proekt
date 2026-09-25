namespace laba1
{
    public class Sushnost
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public int Transcendence { get; set; }
        public int Age { get; set; }
        public Sushnost()
        {
            Random Rnd = new Random();
            Transcendence = Rnd.Next(100);
        }
    }
}