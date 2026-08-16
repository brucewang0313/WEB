namespace DoWhereSample002
{
    /// <summary>
    /// 第二個重點 -- 修改為擴充方法
    /// </summary>
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
