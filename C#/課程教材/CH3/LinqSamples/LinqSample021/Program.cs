namespace LinqSample021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            var order1 = list.OrderBy((x) => x.Age);
            Display(order1);
            var order2 = list.OrderByDescending((x) => x.Age);
            Display(order2);
            var order3 = list.OrderBy((x) => x.Name).ThenBy((x) => x.Age);
            Display(order3);
            var order4 = list.OrderBy((x) => x.Name).ThenByDescending((x) => x.Age);
            Display(order4);
            Console.ReadLine();
        }

        static void Display(IOrderedEnumerable<MyData> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine($"{item.Name} : {item.Age}");
            }
            Console.WriteLine("-------------");
        }

        static List<MyData> CreateList()
        {
            var list = new List<MyData>();
            list.Add(new MyData() { Name = "Bill", Age = 47 });
            list.Add(new MyData() { Name = "John", Age = 37 });
            list.Add(new MyData() { Name = "Tom", Age = 48 });
            list.Add(new MyData() { Name = "David", Age = 36 });
            list.Add(new MyData() { Name = "Bill", Age = 35 });
            return list;
        }
    }
}
