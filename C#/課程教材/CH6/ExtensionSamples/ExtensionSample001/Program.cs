using ExtensionSample001.Helpers;

namespace ExtensionSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source = new List<string> { "Bill", "John", "David", "Tom", "David" };
            var result = source.DoWhere((x) => x == "David");
            // 其實它原來應該是這樣寫       
            // var result = MyClass.DoWhere(source, ((x) => x == "David"));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
