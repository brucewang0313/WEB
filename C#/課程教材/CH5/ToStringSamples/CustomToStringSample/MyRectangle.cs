namespace CustomToStringSample
{
    internal class MyRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        override public string ToString()
        {
            return $"Width={Width}, Height={Height}";
        }
    }
}
