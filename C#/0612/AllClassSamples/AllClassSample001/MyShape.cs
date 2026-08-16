using System;
using System.Collections.Generic;
using System.Text;

namespace AllClassSample001
{
    public abstract class MyShape
    {
        public abstract double GetArea();
    }
    public class MyRectangle : MyShape
    {
        public double Width { get; set; } // 屬性(有get set)
        public double Height { get; set; }
        public override double GetArea()
        {
            return Width * Height;
        }
    }
    public class MyCircle : MyShape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

}
