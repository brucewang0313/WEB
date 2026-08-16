namespace LinqSample004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            // 這裡的 person1 是單個物件, 也就是 MyData person1
            var person1 = list.LastOrDefault((x) => x.Age > 35);
            Console.WriteLine($"大於 35 歲的人最後一個被找到的是 : {person1.Name}");

            // 如果找不到, 就會回傳自訂的物件 (.NET 6.0 新增)
            var customDefault = list.LastOrDefault((x) => x.Age > 50, new MyData { Name = "Not Found", Age = 130 });
            Console.WriteLine($"找不到, 所以回傳自訂物件 : {customDefault.Name}");

            // 因為找不到, 就會跳出例外
            var person2 = list.Last((x) => x.Age > 50);
            Console.WriteLine($"大於 50 歲的人最後一個被找到的是 : {person2.Name}");

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
