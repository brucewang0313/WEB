namespace EnumSamples002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  FlagsAttribute 標記的列舉型別 , authority 同時為 Read 與 Write
            Authority authority = Authority.Read | Authority.Write;
            Console.WriteLine(authority.HasFlag(Authority.Read));
            Console.WriteLine(authority.HasFlag(Authority.Read | Authority.Write));
            Console.WriteLine(authority.HasFlag(Authority.Read | Authority.Write | Authority.Create));
            // 0 值不可使用 HasFlag
            Console.WriteLine(authority.HasFlag(Authority.None));
            // 0 值應直接使用比較運算 == 或 Equals
            Console.WriteLine(authority == Authority.None);

            Console.ReadLine();
        }
    }
}
