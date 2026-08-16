namespace LinqSample009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            string name = "Bill";
            bool isAllBill = list.All((x) => x.Name == name);
            if (isAllBill)
            {
                Console.WriteLine($"全都是 {name}");
            }
            else
            {
                Console.WriteLine($"有些人不叫 {name}");
            }
            bool isAllOverForty = list.All((x) => x.Age >= 40);
            if (isAllOverForty)
            {
                Console.WriteLine("大家都超過 40 歲");
            }
            else
            {
                Console.WriteLine("有人不到 40 歲");
            }
            Console.ReadLine();
        }

        static List<MyData> CreateList()
        {
            return new List<MyData>()
            {
                 new MyData { Name = "Bill", Age = 47 },
                 new MyData { Name = "John", Age = 37 },
                 new MyData { Name = "Tom", Age = 48 },
                 new MyData { Name = "David", Age = 36 },
                 new MyData { Name = "Bill", Age = 35 },
            };
        }
    }
}
