namespace DesignPatterns.Structural
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly Person _person;

        public ResponsiblePerson(Person person)
        {
            _person = person;
        }

        public int Age
        {
            get { return age;}
            set
            {
                age = value;

                if (value < 18)
                {
                    drink = false;
                }
                else
                {
                    drink = true;
                }

                if (value < 16)
                {
                    drive = false;
                }
                else
                {
                    drive = true;
                }

                drinkAndDrive = drive && drink;
            }
        }

        private int age;
        private bool drink;
        private bool drive;
        private bool drinkAndDrive;

        public string Drink()
        {
            if (drink)
            {
                return _person.Drink();
            }

            return "too young";
        }

        public string Drive()
        {
            if (drive)
            {
                return _person.Drive();
            }

            return "too young";
        }

        public string DrinkAndDrive()
        {
            if (drinkAndDrive)
            {
                return "dead";
            }

            return _person.DrinkAndDrive();
        }


    }
}
