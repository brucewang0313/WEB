using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Math.PI * Radius * Radius;
        }
    }
}
