namespace DoWhereSample004
{
    /// <summary>
    /// 第四個重點 -- 修改方法的第一個參數與回傳值為 IEnumerable<T>
    /// </summary>
    public static class MyClass
    {     
        public static IEnumerable<T> DoWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
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
