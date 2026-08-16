using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhereSample006
{
    public interface IPredicte<T>
    {
        bool Invoke(T item);
    }
}
