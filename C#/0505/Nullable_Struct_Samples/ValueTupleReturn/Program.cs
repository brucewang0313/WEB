namespace ValueTupleReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (w, h) = (11, 19);
            Console.WriteLine( CalcuteRectangle(w,h));
        }
        static (double area,double perimeter) CalcuteRectangle(double width,double height)
        {
            //因為回傳的是數值不是字串要改成下面
            //return $"面積{width* height}周長{(width+height)*2}";
            return (width * height, (width + height) * 2);

            //double area = width * height;
            //double perimeter = (width + height) * 2;
            //return (area, perimeter);
        }
    }
}
