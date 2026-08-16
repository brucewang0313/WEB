namespace StaticSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var source = "heLlo woRld froM sTatic meTHod";
            var result = StringHelper.ToUpperTitleCase(source);
            Console.WriteLine(result);
            var left = StringHelper.LeftOf("first-middle-last", "-");
            Console.WriteLine(left);
            var right = StringHelper.RightOf("first-middle-last", "-");
            Console.WriteLine(right);

        }
}
    public static class StringHelper
    {
        public static string ToUpperTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return string.Join(' ', input.Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
        public static string LeftOf(string source,string separator)
        {
            if(string.IsNullOrEmpty(source)||separator is null)
            {
                return source;
            }
            int index = source.IndexOf(separator, StringComparison.Ordinal);
            return index < 0 ? source : source.Substring(0, index);
        }
        public static string RightOf(string source,string separator)
        {
            if (string.IsNullOrEmpty(source) || separator is null)
            {
                return source;
            }
            int index = source.IndexOf(separator, StringComparison.Ordinal);
            return index < 0 ? source : source.Substring(index + separator.Length);
        }
    }
}
