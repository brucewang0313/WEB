using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSamples002
{
    /// <summary>
    /// 使用 Flags 屬性來定義列舉，表示可以組合多個值
    /// </summary>
    [Flags]
    public enum Authority
    {
        None = 0,
        Read = 1,
        Write = 2,
        Create = 4,
        Delete = 8
    }
}
