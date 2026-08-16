namespace StringPoolSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "ABC";
            string s2 = "ABC";
            // "ABC" 為固定字串 (字串常值 literal)，會被編譯器放在字串池 (string pool) 中，s1 和 s2 都指向同一個字串物件
            Console.WriteLine(object.ReferenceEquals(s1, s2)); // True
            int x = 1999;
            string s3 = x.ToString(); // s3 為 "1999"，但不是字串常值，會在執行時建立一個新的字串物件
            string s4 = x.ToString(); // s4 也是 "1999"，但同樣不是字串常值，會在執行時建立另一個新的字串物件
            // s3, s4 所指向的物件不同
            // 因為它們是在執行時建立的，而不是編譯時的字串常值
            Console.WriteLine(object.ReferenceEquals(s3, s4)); // False
            Console.ReadLine();
        }
    }
}
