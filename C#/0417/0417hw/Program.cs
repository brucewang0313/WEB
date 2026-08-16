using System.Security.Cryptography.X509Certificates;

namespace _0417hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////算單詞
            //Console.Write("輸入一個英文句子：");
            //string input = Console.ReadLine();
            //string[] words = input.Split(' ');
            //Console.Write($"{input}一共有{input.Length}個單詞");

            ////印出1-50之間非3的倍數且非5的倍數的數字
            //for ( int i = 1 ; i < 51; i++)
            //{
            //    if (i % 3 != 0 && i % 5 != 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            ////輸入一串數字，顯示數字出現的個數
            //string input = Console.ReadLine();
            //int[] numarr = new int[10];
            //for (int i = 0; i < numarr.Length; i++)
            //{
            //    foreach(char c in input)
            //    {
            //        int myNum = int.Parse(c.ToString());
            //        if (myNum == i)
            //        {
            //            numarr[i]++;
            //        }
            //    }
            //}
            //for(int i = 0; i < numarr.Length; i++)
            //{
            //    Console.WriteLine($"數字{i}：出現{numarr[i]}次");
            //}

            ////別種寫法
            //string input = Console.ReadLine();
            //int[] numarr = new int[10];

            //foreach (char c in input)
            //{
            //    int i = int.Parse(c.ToString());
            //    numarr[i]++;
            //}
            //for (int i = 0; i < numarr.Length; i++)
            //{
            //    Console.WriteLine($"數字{i}：出現{numarr[i]}次");
            //}

            //輸入要排序的數字，用逗號分隔，顯示從小到大的排序結果
            Console.Write("請輸入數字用逗號分隔");
            string input = Console.ReadLine();
            string[] numStr = input.Split(',');

            int[] numArr = new int[numStr.Length];
            for (int i = 0; i < numStr.Length; i++)
            {
                numArr[i] = int.Parse(numStr[i]);
            }
            Array.Sort(numArr);

            //foreach (int item in numArr)
            //{
            //    Console.WriteLine(item);
            //}

            string result = string.Join(Environment.NewLine, numArr);
            Console.WriteLine(result);

        }
        static void DisplayResult(int[] source)
        {
            string result = string.Join(",", source);
            Console.WriteLine(result);
        }

    }
}
