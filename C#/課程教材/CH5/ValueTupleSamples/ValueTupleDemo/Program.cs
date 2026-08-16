namespace ValueTupleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 顯式宣告使用 ValueTuple.Create methods 
            ValueTuple<int, string> x1 = ValueTuple.Create<int, string>(8, "ABC");
            Console.WriteLine($"(1) {x1.Item1} : {x1.Item2}");

            // 隱式宣告使用 ValueTuple Constructor
            var x2 = (8, "ABC");
            Console.WriteLine($"(2) {x2.Item1} : {x2.Item2}");

            // 具名宣告欄位名稱 (1)
            var x3 = (length: 8, letters: "ABC");
            Console.WriteLine($"(3) {x3.length} : {x3.letters}");

            // 具名宣告欄位名稱 (2)
            (int length, string letters) x4 = (8, "ABC");
            Console.WriteLine($"(4) {x4.length} : {x4.letters}");

            // 具名宣告欄位名稱 (3) -- 會以指派運算子的左邊為主
            (int length, string letters) x5 = (first: 8, second: "ABC");
            Console.WriteLine($"(5) {x5.length} : {x5.letters}");

            // 直接指派給區域變數
            (int length, string letters) = (8, "ABC");
            Console.WriteLine($"(6) {length} : {letters}");

            var (l, s) = (8, "ABC");
            Console.WriteLine($"(7) {l} : {s}");


            Console.ReadLine();
        }
    }
}
