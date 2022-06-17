using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Structural
{
    public class ValueComposite
    {
        public interface IValueContainer : IEnumerable<int>
        {

        }

        public class SingleValue : IValueContainer
        {
            public int Value;

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                yield return this.Value;
            }

            public IEnumerator GetEnumerator()
            {
                yield return this;
            }
        }

        public class ManyValues : List<int>, IValueContainer
        {

        }


    }
}
