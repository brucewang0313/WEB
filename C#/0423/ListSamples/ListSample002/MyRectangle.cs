using System;
using System.Collections.Generic;
using System.Text;

namespace ListSample002
{
    internal class MyRectangle
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Area
        {
            get { return Width * Height; }//只有get因為不讓他設定set沒有額外設定
        }
    }
}
