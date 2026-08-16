namespace MethodSample001
{
    /// <summary>
    /// 找出重複的部分
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {            
            int[] numbers1 = { 1, -2, 3, -4, 5, 6 };
            int[] numbers2 = { 10, 20, -30, 40, -50 };

            // 處理 numbers1
            int sumOfPositives1 = 0;
            foreach (int num in numbers1)
            {
                if (num > 0)
                {
                    sumOfPositives1 += num;
                }
            }
            Console.WriteLine($"numbers1 中的正數總和: {sumOfPositives1}");

            // 處理 numbers2
            int sumOfPositives2 = 0;
            foreach (int num in numbers2)
            {
                if (num > 0)
                {
                    sumOfPositives2 += num;
                }
            }
            Console.WriteLine($"numbers2 中的正數總和: {sumOfPositives2}");

            Console.ReadLine(); 
        }
    }
}
