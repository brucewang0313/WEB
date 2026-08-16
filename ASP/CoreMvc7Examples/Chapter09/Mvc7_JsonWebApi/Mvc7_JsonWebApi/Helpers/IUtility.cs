using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc7_JsonWebApi.Helpers
{
    public interface IUtility
    {
        int[] GetNumbers(int num);

        string GetBookTitle();
    }
}
