namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    internal class Calculator
    {
        //private int _x; //private不能共用的
        //private int _y;
        //public int X //public透過屬性存取欄位
        //{
        //    get => _x;
        //    set => _x = value;
        //}
        //public int Y
        //{
        //    get { return _y; }
        //    set { _y = value; }
        //}
        public int X { get; set; }
        public int Y { get; set; }

        public int Add() //方法名稱是大寫開頭
        {
            return X + Y;
        }
        public int Subtract()
        {
            return X - Y;
        }
    }
}
