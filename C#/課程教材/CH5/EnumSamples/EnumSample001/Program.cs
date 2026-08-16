namespace EnumSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyWeekDays day = MyWeekDays.Sun;
            Console.WriteLine($"Today is {day}");
            if (day == MyWeekDays.Mon)
            {
                Console.WriteLine("Today is Monday");
            }
            else
            {
                Console.WriteLine("Today is not Monday");
            }

            //轉換回 int 
            int i = (int)day;
            Console.WriteLine($"The value of {day} is {i}");

            Console.ReadLine();

        }
    }
}
