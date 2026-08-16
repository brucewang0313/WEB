using System;
using System.Collections.Generic;
using System.Text;

namespace DictionarySample001
{
    internal class MyRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int GetArea()
        {
            return Width * Height;
        }
    }
}
