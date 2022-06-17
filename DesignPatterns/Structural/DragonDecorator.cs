namespace DesignPatterns.Structural
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon
    {
        private Lizard lizard = new Lizard();
        private Bird bird = new Bird();
        private int _age;

        public int Age
        {
            set
            {
                _age = value;
                lizard.Age = value;
                bird.Age = value;
            }
            get => _age;
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }
}