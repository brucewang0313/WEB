namespace GenericSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1<int> o1 = new Class1<int>();
            string s1 = o1.Data.GetType().ToString();
            Display("o1.Data", s1);

            Class1<bool> o2 = new Class1<bool>();
            string s2 = o2.Data.GetType().ToString();
            Display("o2.Data", s2);

            Console.ReadLine();
        }

        static void Display(string varName, string typeString)
        {
            Console.WriteLine($"{varName} 的型別是 {typeString}");
        }
    }
}
