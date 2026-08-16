namespace MethodSample001_R1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 1, -2, 3, -4, 5, 6 };
            int[] numbers2 = { 10, 20, -30, 40, -50 };
            int sumOfPositives1 = 0;
            //foreach (int num in numbers1)
            //{
            //    if (num > 0)
            //    {
            //        sumOfPositives1 += num;
            //    }
            //}
            sumOfPositives1 = CalculateSumOfPositives(numbers1);//number1是引數、在方法叫參數
            Console.WriteLine($"numbers1 中的正數總和: {sumOfPositives1}");
            int sumOfPositives2 = 0;
            //foreach (int num in numbers2)
            //{
            //    if (num > 0)
            //    {
            //        sumOfPositives2 += num;
            //    }
            //}
            sumOfPositives2 = CalculateSumOfPositives(numbers2);
            Console.WriteLine($"numbers2 中的正數總和: {sumOfPositives2}");
            Console.ReadLine();

        }
        static int CalculateSumOfPositives(int[] numbers)//方法三要素：回傳值、方法名稱、參數列表
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
