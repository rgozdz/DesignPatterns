using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DesignPatterns.Behavioral
{
    public class MementoToken
    {
        public int Value;

        public MementoToken(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<MementoToken> Tokens = new List<MementoToken>();
    }

    public class TokenMachine
    {
        public List<MementoToken> Tokens = new List<MementoToken>();

        public Memento AddToken(int value)
        {
            return AddToken(new MementoToken(value));
        }

        public Memento AddToken(MementoToken token)
        {
            Tokens.Add(token);
            var m = new Memento();
            m.Tokens = Tokens.Select(t => new MementoToken(t.Value)).ToList();
            return m;
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens.Select(mm => new MementoToken(mm.Value)).ToList();
        }
    }

    public class Tests
    {
        [Fact]
        public void SingleTokenTest()
        {
            var tm = new TokenMachine();
            var m = tm.AddToken(123);
            tm.AddToken(456);
            tm.Revert(m);
            Assert.True(tm.Tokens.Count == 1);
            Assert.True(tm.Tokens[0].Value == 123);
        }

        [Fact]
        public void TwoTokenTest()
        {
            var tm = new TokenMachine();
            tm.AddToken(1);
            var m = tm.AddToken(2);
            tm.AddToken(3);
            tm.Revert(m);
            Assert.True(tm.Tokens.Count == 2);
            Assert.True(tm.Tokens[0].Value== 1,
                $"First token should have value 1, you got {tm.Tokens[0].Value}");
            Assert.True(tm.Tokens[1].Value == 2);
        }

        [Fact]
        public void FiddledTokenTest()
        {
            var tm = new TokenMachine();
            Console.WriteLine("Made a token with value 111 and kept a reference");
            var token = new MementoToken(111);
            Console.WriteLine("Added this token to the list");
            tm.AddToken(token);
            var m = tm.AddToken(222);
            Console.WriteLine("Changed this token's value to 333 :)");
            token.Value = 333;
            tm.Revert(m);

            Assert.True(tm.Tokens.Count == 2,
                $"At this point, token machine should have exactly two tokens, you got {tm.Tokens.Count}");

            Assert.True(tm.Tokens[0].Value == 111,
                $"You got the token value wrong here. Hint: did you init the memento by value?");
        }
    }
}
