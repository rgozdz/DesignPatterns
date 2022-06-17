using System;
using System.Collections.Generic;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.Structural;

namespace DesignPatterns
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Builder
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");

            Console.WriteLine(cb);

            //Factory
            var pf = new PersonFactory();
            var pf1 = pf.CreatePerson("Peter");
            var pf2 = pf.CreatePerson("Paul");
            var pf3 = pf.CreatePerson("Tom");

            Console.WriteLine(pf1.Id + " " + pf1.Name);
            Console.WriteLine(pf2.Id + " " + pf2.Name);
            Console.WriteLine(pf3.Id + " " + pf3.Name);


            //Prototype
            var line1 = new LinePrototype.Line();
            line1.Start = new LinePrototype.Point() {X = 12, Y = 12};
            line1.End = new LinePrototype.Point() {X = 23, Y = 23};

            var line2 = line1.DeepCopy();
            line2.Start.X = 15;
            line2.End.X = 25;

            Console.Write(line1.Start.X + " " +line1.Start.Y);
            Console.WriteLine(line1.End.X + " " +line1.End.Y);
            Console.Write(line2.Start.X + " " +line2.Start.Y);
            Console.WriteLine(line2.End.X + " " +line2.End.Y);

            //Bridge
            var triangle = new ShapeBridge.Triangle(new ShapeBridge.RasterRenderer()).ToString();
            var square = new ShapeBridge.Square(new ShapeBridge.VectorRenderer()).ToString();

            Console.WriteLine(triangle);
            Console.WriteLine(square);

            var sentence = new SentenceFlyweight.Sentence("hello word!");
            sentence[0].Capitalize = true;
            Console.WriteLine(sentence);

            //Command
            var account = new Account();
            account.Balance = 2600;

            var c1 = new Command {Amount = 2601, TheAction = Command.Action.Withdraw};
            // var c2 = new Command {Amount = 500, TheAction = Command.Action.Deposit};

            account.Process(c1);
            // account.Process(c2);

            //Interpreter
            var expression = new ExpressionProcessor();
            expression.Variables.Add('x', 5);

            var calc = expression.Calculate("1+x");//60+26-11-36
            Console.WriteLine(calc);


            //Mediator
            var mediator = new Mediator();
            var participant1 = new Participant(mediator);
            var participant2 = new Participant(mediator);

            participant1.Say(5);
            participant2.Say(3);
            participant2.Say(7);

            Console.WriteLine(participant2.Value);
            Console.WriteLine(participant1.Value);


            Console.ReadKey();


        }

    }

   
}
