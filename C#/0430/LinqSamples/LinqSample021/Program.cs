namespace LinqSample021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            //var order1 = list.OrderBy((x) => x.Age);
            //Display(order1);
            //var order2 = list.OrderByDescending((x) => x.Age);
            //Display(order2);
            //var order3 = list.OrderBy((x => x.Name)).ThenBy(((x) => x.Age));
            //Display(order3);
            //var order4 = list.OrderBy((x) => x.Name).ThenByDescending((x) => x.Age);
            //Display(order4);

            var order1 =
                from o in list
                orderby o.Name, o.Age //與ThenBy比較
                select o;
            Display(order1);
            var order2 =
                from o in list
                orderby o.Name descending, o.Age descending
                select o;
            Display(order2);
        }
        static List<MyData> CreateList()
        {
            return new List<MyData>()
            {
            new MyData { Name = "Bill" , Age = 47 },
            new MyData { Name = "John" , Age = 37 },
            new MyData { Name = "Tom" , Age = 48 },
            new MyData { Name = "David", Age = 36 },
            new MyData { Name = "Bill" , Age = 35 },
            };
        }

        //IOrderedEnumerable是排序後的迭代意思(只能傳排序過後的結果，若是用WHERE就傳不過來)
        static void Display(IOrderedEnumerable<MyData> source) 
        {
            foreach(var item in source)
            {
                Console.WriteLine($"{item.Name}：{item.Age}");
            }
            Console.WriteLine("----------");
        }
    }
    internal class MyData
    {
        public string Name
        { get; set; }
        public int Age
        { get; set; }
    }
}
