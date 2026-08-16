namespace DoWhereSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source = ["Bill", "John", "David", "Tom", "David"];
            // 改使用擴充方法語法
            var result = source.DoWhere(x => x.Length == 4);
            /* 等同於
             * var result = MyClass.DoWhere(source, x => x.Length == 4);
             */
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }
    }
}
