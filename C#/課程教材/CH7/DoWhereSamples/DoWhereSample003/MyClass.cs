namespace DoWhereSample003
{
    /// <summary>
    /// 第三個重點 -- 修改為泛型方法
    /// </summary>
    public static class MyClass
    {     
        public static List<T> DoWhere<T>(this List<T> source, Func<T, bool> predicate)
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
