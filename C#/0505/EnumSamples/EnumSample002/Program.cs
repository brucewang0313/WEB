namespace EnumSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Authority authority = Authority.Read | Authority.Write;
            Console.WriteLine(authority.HasFlag(Authority.Read));
            Console.WriteLine(authority.HasFlag(Authority.Read | Authority.Write));
            Console.WriteLine(authority.HasFlag(Authority.Read | Authority.Write | Authority.Create));

            //0值不可使用HasFlag 因為一定是true
            Console.WriteLine(authority.HasFlag(Authority.None));
            //0值應該直接使用比較運算值 == 或 Equals
            Console.WriteLine(authority == Authority.None);
        }
    }
    [Flags]
    public enum Authority
    {
        None = 0,
        Read = 1,
        Write = 2,
        Create = 4,
        Delete = 8
    }
}
