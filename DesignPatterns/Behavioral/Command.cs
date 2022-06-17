using System;

namespace DesignPatterns.Behavioral
{
    public class Command
        {
            public enum Action
            {
                Deposit,
                Withdraw
            }

            public Action TheAction;
            public int Amount;
            public bool Success;
        }

        public class Account
        {
            public int Balance { get; set; }

            public void Process(Command c)
            {
                switch (c.TheAction)
                {
                    case Command.Action.Deposit:
                        c.Success = Deposit(c.Amount);
                        break;
                    case Command.Action.Withdraw:
                        c.Success = Withdraw(c.Amount);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            private bool Deposit(int amount)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount}, balance is now {Balance}");
                return true;
            }

            private bool Withdraw(int amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrew {amount}, balance is now {Balance}");
                    return true;
                }

                return false;
            }
        }
    }