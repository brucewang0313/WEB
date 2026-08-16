using System;
using System.Collections.Generic;
using System.Text;

namespace ListSample001
{
    internal class MyRectangle
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int GetArea()
        {
            return Width * Height;
        }
    }
}
