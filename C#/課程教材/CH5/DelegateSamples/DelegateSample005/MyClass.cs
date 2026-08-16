namespace DelegateSample005
{  
    internal class MyClass
    {
        /// <summary>
        /// 不使用自訂義委派型別，改用內建的 Func 委派型別
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
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
