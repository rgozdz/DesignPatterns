using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral
{
    public class CombinationLock
    {
        public class Statuses
        {
            public const string Locked = "LOCKED";
            public const string Open = "OPEN";
            public const string Error = "ERROR";
        }
        public CombinationLock(int[] combination)
        {
            _combination = combination;
        }

        public string Status = Statuses.Locked;
        private List<int> enteredDigits = new List<int>();

        private readonly int[] _combination;

        public void EnterDigit(int digit)
        {
            enteredDigits.Add(digit);
            var isCombinationCorrect = IsCombinationCorrect(enteredDigits.ToArray());

            if (isCombinationCorrect && enteredDigits.Count == _combination.Length)
            {
                Status = Statuses.Open;
            } 
            else if (isCombinationCorrect)
            {
                Status = ConvertCombination(enteredDigits.ToArray());
            }
            else
            {
                Status = Statuses.Error;
            }
        }

        private string ConvertCombination(int[] combinationArray)
        {
            return string.Join(string.Empty, combinationArray);
        }

        private bool IsCombinationCorrect(int[] enteredDigits)
        {
            var enteredCode = ConvertCombination(enteredDigits);
            var stringCombination = ConvertCombination(_combination);

            return stringCombination
                .Substring(0, enteredCode.Length) == enteredCode;
        }
    }
}
