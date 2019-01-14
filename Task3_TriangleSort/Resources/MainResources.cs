using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TriangleSort.Resources
{
    public class StringArrEventArgs : EventArgs
    {
        public string[] Value { get; private set; }

        public StringArrEventArgs(string[] value)
        {
            Value = value;
        }
    }

    public class StringEventArgs : EventArgs
    {
        public string Value { get; private set; }

        public StringEventArgs(string value)
        {
            Value = value;
        }
    }
}
