namespace DoWhereSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 使用集合運算式 (Collection Expression) 建立 List<string>
            List<string> source = [ "Bill", "John", "David", "Tom", "David" ];
            var result = MyClass.DoWhere(source, x => x.Length == 4);
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }
    }
}
