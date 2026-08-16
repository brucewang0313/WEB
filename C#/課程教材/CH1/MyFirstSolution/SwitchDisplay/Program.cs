namespace SwitchDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value;
            Console.WriteLine("請輸入一個數字 :");
            string input = Console.ReadLine();
            value = int.Parse(input);
            switch (value)
            {
                case 1: 
                    Console.WriteLine("數字是 1"); 
                    break;
                case 2: 
                    Console.WriteLine("數字是 2"); 
                    break;
                default: 
                    Console.WriteLine("數字不在條件內"); 
                    break;
            }
            Console.ReadLine();
        }
    }
}
