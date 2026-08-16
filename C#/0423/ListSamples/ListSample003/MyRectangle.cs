using System;
using System.Collections.Generic;
using System.Text;

namespace ListSample003
{
    internal class MyRectangle
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Area => Width * Height;//使用運算式主體寫法
    }
}
