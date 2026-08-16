using InterfaceSample002.InterfaceSample002;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSample002
{
    /// <summary>
    /// Simple Factory Pattern (簡單工廠模式)
    /// </summary>
    public class PeopleFactory
    {
        private Dictionary<SourceType, People> Sources;

        public PeopleFactory()
        {
            Sources = new Dictionary<SourceType, People>();
            Sources.Add(SourceType.CSV, new PeopleFromCSV());
            Sources.Add(SourceType.JSON, new PeopleFromJson());

        }

        public List<Person> GetPeopleList(SourceType type)
        {
            People p = Sources[type];
            p.Parse();
            // 上述可縮為一行 Sources[type].Parse();

            return Sources[type].Items;
        }
    }
}
