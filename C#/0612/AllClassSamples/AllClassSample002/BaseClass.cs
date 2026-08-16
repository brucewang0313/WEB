using System;
using System.Collections.Generic;
using System.Text;

namespace AllClassSample002
{
    public class BaseClass
    {
        public virtual void Execute()
        {
            Console.WriteLine("BaseClass Execute Method");
        }
        public virtual void Begin()
        {
            Console.WriteLine("BaseClass Begin Method");
        }
    }
    public class Class1 : BaseClass
    {
        public override void Execute()
        {
            Console.WriteLine("Class1 Executee Method");
        }
    }
    public class Class2 : Class1
    {
        public override sealed void Execute()
        {
            Console.WriteLine("Class2 Execute Method");
        }
        public override void Begin()
        {
            Console.WriteLine("Class2 Begin Method");
        }
    }
    public class Class3 : Class2
    {
        //public override void Execute() // 因為sealed不能覆寫有「子類別」
        //{
        //    Console.WriteLine("Class3 Begin Method");
        //}
    }
}
