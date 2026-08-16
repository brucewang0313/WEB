namespace DoWhileLoopSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int i = 1;
            do
            {
                result = result + i;
                i = i + 1;
                /* 也可以寫成 
                 i++ 或 ++i 或 i+=1
                */
            }
            while (i < 11);
            Console.WriteLine($"加總結果 : {result}");
            Console.ReadLine();
        }
    }
}
