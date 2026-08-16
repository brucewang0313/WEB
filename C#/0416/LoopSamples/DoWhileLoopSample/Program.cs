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
                result += i;
                i++;
            }
            while (i < 11);
            Console.WriteLine($"加總結果：{result}");
            Console.ReadLine();
            //會用梯形公式解((1+10)*10)/2
        }
    }
}
