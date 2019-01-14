using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.Model
{
    public class Ticket
    {
        private string _number;
        public Ticket(string number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToString();
        }
    }
}
