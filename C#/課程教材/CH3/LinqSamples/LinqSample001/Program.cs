namespace LinqSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyData> list = CreateList();

            //Query Expression
            IEnumerable<MyData> people =
                  from data in list
                  where data.Name == "Bill"
                  select data;


            //顯示結果
            foreach (MyData person in people)
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

            // C# 9.0 以後可以採用 target-typed new expression
            /*
            return new()
            {
                 new() { Name = "Bill", Age = 47 },
                 new() { Name = "John", Age = 37 },
                 new() { Name = "Tom", Age = 48 },
                 new() { Name = "David", Age = 36 },
                 new() { Name = "Bill", Age = 35 },
            };
            */
        }
    }
}
