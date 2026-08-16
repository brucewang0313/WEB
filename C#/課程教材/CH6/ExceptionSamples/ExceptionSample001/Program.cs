namespace ExceptionSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }

        static void DoParse()
        {
            try
            {
                string s = "ABC";
                int.Parse(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發生例外 {ex.Message}");
            }
            finally
            {
                Console.WriteLine("執行了 finally 區塊");
            }
        }
    }
}
