namespace ReturnSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ReturnVoid();
            int i = ReturnInt();
            Console.Write($"i={i}");
            Console.ReadLine();

        }
        static int ReturnInt()
        {
            Console.WriteLine("進入 ReturnInt");
            //回傳值要與宣告的型別相同
            return 10;
            Console.WriteLine("這行不會被執行到");
        }
        static void ReturnVoid()
        {
            Console.WriteLine("進入 ReturnVoid");
            // 沒有回傳值時, return 若在整個方法的最後一行可以省略
            return;
            Console.WriteLine("這行不會被執行到");
        }
    }
}
