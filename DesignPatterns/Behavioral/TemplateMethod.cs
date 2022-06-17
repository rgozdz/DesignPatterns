namespace DesignPatterns.Behavioral
{
    public class GameCreature
    {
        public int Attack, Health;

        public GameCreature(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }

    public abstract class CardGame
    {
        public GameCreature[] Creatures;

        public CardGame(GameCreature[] creatures)
        {
            Creatures = creatures;
        }

        // returns -1 if no clear winner (both alive or both dead)
        public int Combat(int creature1, int creature2)
        {
            GameCreature first = Creatures[creature1];
            GameCreature second = Creatures[creature2];
            Hit(first, second);
            Hit(second, first);
            bool firstAlive = first.Health > 0;
            bool secondAlive = second.Health > 0;
            if (firstAlive == secondAlive) return -1;
            return firstAlive ? creature1 : creature2;
        }

        // attacker hits other creature
        protected abstract void Hit(GameCreature attacker, GameCreature other);
    }

    public class TemporaryCardDamageGame : CardGame
    {
        public TemporaryCardDamageGame(GameCreature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(GameCreature attacker, GameCreature other)
        {
            if(attacker.Attack >= other.Health) other.Health -= attacker.Attack;
        }
    }

    public class PermanentCardDamage : CardGame
    {
        public PermanentCardDamage(GameCreature[] creatures) : base(creatures)
        {
        }

        protected override void Hit(GameCreature attacker, GameCreature other)
        {
            other.Health -= attacker.Attack;
        }
    }
}
