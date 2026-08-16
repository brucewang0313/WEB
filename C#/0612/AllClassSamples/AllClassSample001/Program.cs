using AllClassSample001;

internal class Program
{
    private static void Main(string[] args)
    {
        MyRectangle rect = new MyRectangle { Width = 5, Height = 7 };
        ShowArea(rect);
        MyCircle circle = new MyCircle { Radius = 7 };
        ShowArea(circle);
        Console.ReadLine();
    }
    
    static void ShowArea(MyShape shape)
    {
        Console.WriteLine($"Area: {shape.GetArea()}");
    }
}



