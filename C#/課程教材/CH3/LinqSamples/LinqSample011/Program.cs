namespace LinqSample011
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();
            // 找出名稱為 Bill 中的最小 Age
            var min = list.Where((x) => x.Name == "Bill").Min((x) => x.Age);
            Console.WriteLine("所有 Bill 中最小的年齡是 :" + min);

            // 計算名稱為 Bill 的年齡總和
            var total = list.Where((x) => x.Name == "Bill").Sum((x) => x.Age);
            Console.WriteLine("所有 Bill 的年齡總和是 :" + total);

            var average = list.Where((x) => x.Name == "Bill").Average((x) => x.Age);
            Console.WriteLine("所有 Bill 的年齡平均是 :" + average);

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
