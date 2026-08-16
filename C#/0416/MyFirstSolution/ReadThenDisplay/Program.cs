namespace ReadThenDisplay
{
    /// <summary>
    /// Class註解
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main的註解
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("請輸入文字：");
            /*
             輸入的註解
             */
            string input = Console.ReadLine();
            Console.Write("你輸入的文字是：");
            Console.WriteLine(input);
            Console.ReadLine();


        }
    }
}
