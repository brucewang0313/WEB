using System;
using System.Collections.Generic;
using System.Text;

namespace ContructorSample001
{
    public class BaseClass
    {
        public int X { get; private set; }
        public BaseClass():this(0) //使用this呼叫另一個建構式
        {
            //X = 0;
        }
        public BaseClass(int y)
        {
            X = y;
        }
    }
    public class Class1 : BaseClass
    {
            public int K { get; set; }
            public Class1(int x, int y) : base(y)
            {
                K = x;
            }
    }
}
