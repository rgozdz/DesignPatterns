namespace DesignPatterns.Creational
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private static int _id;

        public Person CreatePerson(string name)
        {
            return new Person() {Id = _id++, Name = name};
        }
    }
}