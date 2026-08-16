using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSample003
{
    internal class MyRectangle
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // 使用 expression-bodied 成員來撰寫 Area 屬性
        public int Area => Width * Height;
    }
}
