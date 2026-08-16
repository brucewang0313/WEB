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

            int i = (int)day;
            Console.WriteLine($"The value of {day} is {i}");

            Console.ReadLine();
        }
    }
    public enum MyWeekDays
    {
        Sun, Mon, Tue, Wed, Thu, Fri, Sat
    }
    public enum BrowserTypes
    {
        IE = 1, Edge, Firefox, Chrome//最好不要從1開始
    }
    public enum SwithTypes
    {
        on = 0, off = 1
    }
}
