using System.Net.Http.Headers;

namespace SwitchDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value;
            Console.Write("請輸入一 個數字：");
            string input = Console.ReadLine();
            value = int.Parse(input);
            switch (value)
            {
                case 1:
                    Console.WriteLine("數字是1");
                    break;
                case 2:
                    Console.WriteLine("數字是2");
                    break;
                default:
                    Console.WriteLine("數字不在條件內");
                    break ;
            }
            Console.ReadLine();
        }
    }
}
