namespace LinqSample018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            //var result = list.GroupBy((x) => x.City);//會依據程式先將資料分地區
            //另一種寫法Query Expression
            var result =
                from o in list
                group o by o.City into gp
                select gp;
            foreach(var item in result)//先找到地區
            {
                Console.WriteLine($"住在：{item.Key}");
                foreach (var p in item)//再找到地區裡面的人名
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine("----------");
            }
            Console.ReadLine();
        }
        static List<MyData> CreateList()
        {
            return
            [
                new() { Name = "Bill", City = "台北" },
                new() { Name = "John", City = "台北" },
                new() { Name = "Tom", City = "高雄" },
                new() { Name = "David", City = "台南" },
                new() { Name = "Jeff", City = "台南" },
            ];
        }
    }
    internal class MyData
    {
        public string City
        { get; set; }
        public string Name
        { get; set; }
    }

}
