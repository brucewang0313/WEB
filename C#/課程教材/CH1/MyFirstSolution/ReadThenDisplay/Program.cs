namespace ReadThenDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 顯示提示訊息，要求使用者輸入文字
            Console.WriteLine("請輸入文字 :");
            /* 這裡使用 Console.ReadLine() 方法來讀取使用者輸入的文字。
               使用者輸入的文字會被存儲在 input 變數中。
               然後使用 Console.WriteLine() 方法來顯示使用者輸入的文字。             
             */
            string input = Console.ReadLine();
            Console.Write("你輸入的文字是 : ");
            Console.WriteLine(input);
            Console.ReadLine();
        }
    }
}
