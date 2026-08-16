using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample001
{
    internal class MyClass
    {
        public event EventHandler? XChanged;

        protected virtual void OnXChanged()
        {
            XChanged?.Invoke(this, EventArgs.Empty);
            //if (XChanged != null)
            //{
            //    XChanged.Invoke(this, EventArgs.Empty);
            //}
        }

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnXChanged();
                }
            }
        }
    }
}
