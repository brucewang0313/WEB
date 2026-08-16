using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample002
{
    public delegate bool MyPredicate(string vaule);
    internal class MyClass
    {
        public static List<string> DoWhere(List<string> source, Func<string,bool> predicate)
        {
            List<string> result = new List<string>();
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
