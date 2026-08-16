namespace LinqSample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 開始用 var 了
            var list = CreateList();
            // 這裡的 person1 是單個物件, 也就是 MyData person1
            var person1 = list.FirstOrDefault((x) => x.Age < 37);
            Console.WriteLine($"小於 37 歲的人第一個被找到的是 : {person1.Name}");

            // 如果找不到, 就會回傳自訂的物件 (.NET 6.0 新增)
            var customDefault = list.FirstOrDefault((x) => x.Age < 30, new MyData { Name = "Not Found", Age = 0 });
            Console.WriteLine($"找不到, 所以回傳自訂物件 : {customDefault.Name}");

            // 因為找不到, 就會跳出例外
            var person2 = list.First((x) => x.Age < 30);
            Console.WriteLine($"小於 30 歲的人第一個被找到的是 : {person2.Name}");

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
