using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClassSample001
{
    public abstract class MyShape
    {
        /// <summary>
        /// 宣告一個抽象方法 GetArea，計算形狀的面積。
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();
    }

    public class MyRectangle : MyShape
    {
        public double Width { get; set; }
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
