using System;
using System.Collections.Generic;
using System.Text;

namespace CakeSample
{
    public class 雞蛋糕模具
    {
        /// <summary>
        /// 模具的把手
        /// </summary>
        public static string 把手
        { get; set; }

        /// <summary>
        /// 模具的上鐵板
        /// </summary>
        public static string 上鐵板
        { get; set; }

        /// <summary>
        /// 模具的下鐵板
        /// </summary>
        public static string 下鐵板
        { get; set; }

        /// <summary>
        /// 建構式
        /// </summary>
        public 雞蛋糕模具()
        {

        }

        /// <summary>
        /// 雞蛋糕的內餡
        /// </summary>
        public string 內餡
        { get; set; }
    }
}
