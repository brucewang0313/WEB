namespace MethodSample001_R1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 1, -2, 3, -4, 5, 6 };
            int[] numbers2 = { 10, 20, -30, 40, -50 };

            // 使用提取出的方法處理 numbers1
            int sumOfPositives1 = CalculateSumOfPositives(numbers1);
            Console.WriteLine($"numbers1 中的正數總和: {sumOfPositives1}");

            // 使用提取出的方法處理 numbers2
            int sumOfPositives2 = CalculateSumOfPositives(numbers2);
            Console.WriteLine($"numbers2 中的正數總和: {sumOfPositives2}");

            Console.ReadLine(); 
        }

        /// <summary>
        /// 提取出的方法，用於計算正數的總和
        /// </summary>
        /// <param name="numbers">包含正負整數的陣列</param>
        /// <returns>輸入陣列中所有正整數的和</returns>
        static int CalculateSumOfPositives(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    sum += num;
                }
            }
            return sum;
        }
    }
}
