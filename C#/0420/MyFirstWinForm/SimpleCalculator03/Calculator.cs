using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator03
{
    internal class Calculator
    {
        //private int _x;
        //private int _y;
        public int X { get; set; }
        public int Y { get; set; }

        public int Add() //方法名稱是大寫開頭
        {
            return X + Y;
        }
        public int Subtract()
        {
            return X - Y;
        }
    }
}
