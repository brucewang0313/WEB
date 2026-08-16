namespace MyLibrary
{
    public class MyRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }
}
