namespace _0420hw
{
    internal class Program
    {
        //輸入數字比大小 P180練習題
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入三個整數，用逗號分開");
            string[] content = Console.ReadLine().Split(',');
            ////方法一
            //int [] vsMaxArr = new int[content.Length];
            //for (int i = 0; i < content.Length; i++)
            //{
            //    vsMaxArr[i] = int.Parse(content[i]);
            //}
            //Console.Write($"最大值為：{vsMaxArr.Max()}");

            ////方法二(只需用一個陣列)
            //int max = int.Parse(content[0]);
            //foreach (string item in content)
            //{
            //    int number = int.Parse(item);
            //    if (number > max)
            //    {
            //        max = number;
            //    }
            //}
            //Console.Write($"最大值為：{max}");
        }
    }
}
