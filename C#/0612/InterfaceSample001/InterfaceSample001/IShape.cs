using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSample001
{
    public interface IShape
    {
        double GetArea();
    }
    public class MyRectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return Width * Height;
        }
    }
    public class MyCircle : IShape
    {
        public double Radius { get; set; }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

}
