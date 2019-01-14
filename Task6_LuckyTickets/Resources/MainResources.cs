using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.Resources
{
    public class StringEventArgs : EventArgs
    {
        public string Value { get; private set; }

        public StringEventArgs(string value)
        {
            Value = value;
        }
    }

    public enum GenerationLackyTicketsMethod
    {
        Indefinite,
        Moskow,
        Piter,
    }
}
