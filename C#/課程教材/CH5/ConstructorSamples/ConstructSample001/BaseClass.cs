namespace ConstructSample001
{
    public class BaseClass
    {
        public int X { get; private set; }
        public BaseClass()
        {
            X = 0;
        }
        public BaseClass(int y)
        {
            X = y;
        }
    }
}
