using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionSample001.Helpers
{
    public static class MyClass
    {
        public static List<string> DoWhere(this List<string> source, Func<string, bool> predicate)
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
