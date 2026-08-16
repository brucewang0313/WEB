namespace DelegateSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeAction action1 = new SomeAction(ShowText);
            action1 += ShowMessage;

            // 簡寫
            SomeAction action2 = ShowText;

            action1.Invoke("第一個");

            action2("第二個");
            Console.ReadLine();
        }
        static void ShowText(string msg)
        {
            Console.WriteLine($"ShowText{msg}");
        }
        static void ShowMessage(string str)
        {
            Console.WriteLine($"ShowMessage{str}");
        }
    }
    public delegate void SomeAction(string message);
}
