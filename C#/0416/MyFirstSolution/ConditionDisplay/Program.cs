namespace ConditionDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int condition = 10;
            int vaule;
            Console.Write("請輸入一個數值：");
            string input = Console.ReadLine();
            vaule = int.Parse(input);
            if (vaule > condition)
            {
                Console.WriteLine($"輸入的數值 {vaule} 大於 {condition}");
            }
            else if (vaule < condition)
            {
                Console.WriteLine($"輸入的數值 {vaule} 小於 {condition}");
            }
            else
            {
                Console.WriteLine($"輸入的數值 {vaule} 等於 {condition}");
            }

        }
    }
}
