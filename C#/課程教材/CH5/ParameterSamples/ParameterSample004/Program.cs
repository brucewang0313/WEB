namespace ParameterSample004
{
    internal class Program
    {
        static void Main()
        {
            TestClass y = new TestClass();
            Console.WriteLine($"y 實體中的 x 的初始值為 {y.x}");
            Program.ChangeX(ref y);
            Console.WriteLine($"退出 ChangeX 方法回到 Main 方法後,y 實體中的 x 的值為 {y.x}");
            Console.ReadLine();

        }
        /// <summary>
        /// 參考型別 By Reference 傳遞
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private static TestClass ChangeX(ref TestClass y)
        {
            Console.WriteLine($"進入 ChangeX 方法的時候, y 實體中的 x 的值為 {y.x}");
            y.x = 10;
            Console.WriteLine($"在 ChangeX 方法重新指派後,y 實體中的 x 的值為 {y.x}");
            y = new TestClass();
            Console.WriteLine($"在 ChangeX 方法重新產生 TestClass 的實體後,y 實體中的 x 的值為 {y.x}");
            return y;
        }
    }

    public class TestClass
    {
        public int x = 0;
    }
}
