namespace LinqSample012
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            MyData minObject_before = list.First(x => x.Age == list.Min(x => x.Age));
            Console.WriteLine($"最小年齡的人是 : {minObject_before.Name},{minObject_before.Age}");
            // .NET 6 之後才有的 MinBy 方法
            MyData minObject_after = list.MinBy((x) => x.Age);
            Console.WriteLine($"最小年齡的人是 : {minObject_after.Name},{minObject_after.Age}");

            MyData maxObject_before = list.First(x => x.Age == list.Max(x => x.Age));
            Console.WriteLine($"最大年齡的人是 : {maxObject_before.Name},{maxObject_before.Age}");
            // .NET 6 之後才有的 MaxBy 方法
            MyData maxObject_after = list.MaxBy((x) => x.Age);
            Console.WriteLine($"最大年齡的人是 : {maxObject_after.Name},{maxObject_after.Age}");

            Console.ReadLine();
        }


        static List<MyData> CreateList()
        {
            /* 使用 集合運算式 */
            return
            [
                new() { Name = "Bill", Age = 47 },
                new() { Name = "John", Age = 37 },
                new() { Name = "Tom", Age = 48 },
                new() { Name = "David", Age = 36 },
                new() { Name = "Bill", Age = 35 }
            ];
        }
    }
}
