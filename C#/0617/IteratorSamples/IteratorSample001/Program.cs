using System.Collections;

namespace IteratorSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //foreach (var item in Exec())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadLine();
            //using (IEnumerator<string> enumerator = Exec().GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        Console.WriteLine(enumerator.Current);
            //    }
            //}

            IEnumerator<string> enumerator = Exec().GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }
        static IEnumerable<string> Exec()// 用yield最方便
        {
            //yield return "A";
            //yield return "B";
            //yield return "C";
            return new EnumString();
        }
    }

    internal class EnumString : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct Enumerator : IEnumerator<string>
        {
            public string Current { get; private set; }

            object IEnumerator.Current => Current;

            private int _index;

            public Enumerator()
            {
                Current = default!;
                _index = -1;
            }

            public bool MoveNext()
            {
                _index++;
                switch (_index)
                {
                    case 0:
                        Current = "A";
                        return true;
                    case 1:
                        Current = "B";
                        return true;
                    case 2:
                        Current = "C";
                        return true;
                    default:
                        return false;
                }
            }
            public void Dispose()
            {
            }


            public void Reset()
            {
                throw new NotSupportedException();
            }
        }
    }
}
