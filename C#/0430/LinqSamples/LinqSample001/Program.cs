namespace LinqSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyData> list = CreateList();

            ////Query Expression可列舉的/可迭代的：可以被foreach的意思
            //IEnumerable<MyData> people =
            //    from date in list
            //    where date.Name == "Bill"
            //    select date;

            //Method Expression，跟上面是一樣的
            var people = list.Where((x) => x.Name == "Bill");

            foreach(MyData person in people)
            {
                Console.WriteLine($"{person.Name}是{person.Age}歲");
            }
            Console.ReadLine();              
        }
        static List<MyData> CreateList()
        {
            return new List<MyData>()//集合正規化
            {
            new MyData { Name = "Bill" , Age = 47},
            new MyData { Name = "John", Age = 37},
            new MyData { Name = "Tom", Age = 48},
            new MyData { Name = "David", Age = 36},
            new MyData { Name = "Bill", Age = 35},
            };
        }
    }
    internal class MyData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
