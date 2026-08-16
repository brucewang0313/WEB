using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSample002
{
    using System.Text.Json;
    namespace InterfaceSample002
    {
        public enum SourceType
        {
            CSV,
            JSON,
            XML
        }
        public interface IParsable
        {
            void Parse();
        }

        public class Person
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }

        public abstract class People : IParsable
        {

            public List<Person> Items { get; private set; }

            protected People()
            {
                Items = new List<Person>();

            }

            public abstract void Parse();
        }


        /// <summary>
        /// 從 CSV 檔取得資料
        /// </summary>
        internal class PeopleFromCSV : People
        {

            public override void Parse()
            {
                Items.Clear();
                char[] splitter = new char[] { ',' };
                string[] lines = File.ReadAllLines("Data.txt");
                foreach (var line in lines)
                {
                    string[] items = line.Split(splitter);
                    var person = new Person();
                    person.Name = items[0];
                    person.Address = items[1];
                    person.Phone = items[2];
                    Items.Add(person);
                }

            }

        }

        /// <summary>
        /// 從 json 檔取得資料
        /// </summary>
        internal class PeopleFromJson : People
        {
            public override void Parse()
            {
                Items.Clear();
                string source = File.ReadAllText("Data.json");
                Items.AddRange(JsonSerializer.Deserialize<List<Person>>(source));
            }
        }
    }
}
