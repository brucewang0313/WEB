using System.Text;
namespace StringBuilderSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < 100; i++)
            {
                builder.Append(i);
            }
            string result = builder.ToString();//在這時候才分配記憶體，效率較好。
            Console.WriteLine(result);
        }
    }
}
