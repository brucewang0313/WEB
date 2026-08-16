namespace BreakSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int condition = 15;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"i={i}");
                for(int j = 11; j < 20; j++)
                {
                    if (j == condition)
                    {
                        //break vs continue的差別
                        //break;//跳出後面也不執行
                        continue;//只跳過符合條件，之後會繼續執行
                    }
                    Console.WriteLine($"j={j}");
                    //上面的continue程式碼也可以改寫成下面，所以不太會寫到continue
                    //if (j != condition)
                    //{
                    //    Console.WriteLine($"j={j}");
                    //}
                }
            }
            Console.ReadLine();
        }
    }
}
