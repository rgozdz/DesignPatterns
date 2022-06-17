using System.Collections.Generic;
using DesignPatterns.Structural;

namespace DesignPatterns
{
    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }

        public static int Sum(this List<ValueComposite.IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
