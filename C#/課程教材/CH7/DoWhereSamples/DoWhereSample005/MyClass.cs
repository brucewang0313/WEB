namespace DoWhereSample005
{
    /// <summary>
    /// 第五個重點 -- 使用 yield return 來簡化程式碼
    /// </summary>
    public static class MyClass
    {     
        public static IEnumerable<T> DoWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }
    }
}
