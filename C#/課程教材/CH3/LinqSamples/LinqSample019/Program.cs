using System.Xml.Linq;

namespace LinqSample019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            var result =
                from o in list
                group o by o.City into gp
                select gp;

            foreach (var item in result)
            {
                Console.WriteLine($"住在 : {item.Key}");
                foreach (var p in item)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine("--------");
            }
            Console.ReadLine();
        }

        static List<MyData> CreateList()
        {
            /* 使用 集合運算式 */
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
}
