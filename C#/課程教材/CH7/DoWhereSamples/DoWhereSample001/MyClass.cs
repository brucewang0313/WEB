namespace DoWhereSample001
{
    public class MyClass
    {
        /// <summary>
        /// 第一個重點 -- 委派作為參數傳遞進來
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<string> DoWhere(List<string> source, Func<string, bool> predicate)
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
