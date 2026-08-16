namespace LinqSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();


            // Method Expression
            var people = list.Where((x) => x.Name == "Bill");
            // var people =System.Linq.Enumerable.Where(list, (x) => x.Name == "Bill");


            //顯示結果
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} 是 {person.Age} 歲");
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
