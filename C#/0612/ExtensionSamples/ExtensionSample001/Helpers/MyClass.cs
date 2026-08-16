using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionSample001.Helpers
{
    public static class MyClass
    {
        public static List<T> DoWhere<T>(this List<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach(var item in source)
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
