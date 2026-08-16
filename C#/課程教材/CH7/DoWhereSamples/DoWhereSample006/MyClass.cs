namespace DoWhereSample006
{
    /// <summary>
    /// 第二個參數是 interface 型別，可以和 Sample005 使用 delegate 型別的版本做比較
    /// </summary>
    public static class MyClass
    {
        public static IEnumerable<T> DoWhere<T>(this IEnumerable<T> source, IPredicte<T> predicate)
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
