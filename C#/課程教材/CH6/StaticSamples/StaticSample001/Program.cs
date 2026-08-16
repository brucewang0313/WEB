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
}
