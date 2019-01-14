using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_EnvelopesAnalysis.Resources
{
    public class StringEventArgs : EventArgs
    {
        public string Value { get; private set; }

        public StringEventArgs(string value)
        {
            Value = value;
        }
    }
}
