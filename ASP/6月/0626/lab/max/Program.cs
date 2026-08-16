namespace max
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入一個整數");
            var input = int.Parse(Console.ReadLine());
            Count(input);
        }
        static void Count(int input)
        {
           int total = 0;
           for(int i = 1; i <= input; i++)
            {
                if (i % 2 != 0)
                {
                    total = total + i;
                }
                else
                {
                    total = total - i;
                }
            }
            Console.WriteLine(total.ToString());
        }
    }
}
