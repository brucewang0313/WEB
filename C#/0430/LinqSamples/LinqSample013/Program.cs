namespace LinqSample013
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            var list2 = new List<int> { 1, 3, 4, 7, 8, 9 };
            /*聯集 & 交集
            var union = list1.Union(list2);
            Console.WriteLine("聯集的結果為：");
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }

            var intetsect = list1.Intersect(list2);
            Console.WriteLine("交集結果為：");
            foreach(var item in intetsect)
            {
                Console.WriteLine(item);
            }
            */

            /*差集*/
            var aExb = list1.Except(list2);
            Console.WriteLine("A差集B的結果為：");
            foreach(var item in aExb)
            {
                Console.WriteLine(item);
            }
            //可以寫成下面這兩行
            Console.WriteLine($"A差集B的結果為：{Environment.NewLine}{string.Join(Environment.NewLine, aExb)}");
            Console.WriteLine($"A差集B的結果為：{string.Join(",", aExb)}");

            var bExa = list2.Except(list1);
            Console.WriteLine("B差集A的結果為：");
            foreach(var item in bExa)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
