namespace ConstructSample001
{
    public class BaseClass
    {
        public int X { get; private set; }
        public BaseClass() : this(0) // 使用 this 呼叫另一個建構子
        {
            // X = 0; // 這行程式碼現在不需要了
        }

        public BaseClass(int y)
        {
            X = y;
        }
    }

    public class Class1 : BaseClass
    {
        public int K { get; set; }
        public Class1(int x, int y) : base(y) // 使用 base 呼叫基底類別的建構子
        {
            K = x;
        }
    }
}
