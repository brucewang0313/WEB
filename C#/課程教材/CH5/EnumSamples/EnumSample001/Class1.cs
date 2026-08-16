using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSample001
{
    /// <summary>
    /// 自動從 0 開始
    /// </summary>
    public enum MyWeekDays
    {
        Sun, Mon, Tue, Wen, Thu, Fri, Sat
    }

    /// <summary>
    /// 設定從 1 開始 (最好不要這樣寫)
    /// </summary>
    public enum BrowserTypes
    {
        IE = 1, Edge, FireFox, Chrome
    }

    /// <summary>
    /// 全部值都手動設定
    /// </summary>
    public enum SwitchTypes
    {
        On = 0, Off = 1
    }
}
