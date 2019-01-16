using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task6_LuckyTickets.Resources;

namespace Task6_LuckyTickets.Model
{
    class LuckyTicketsGeneratorMoskow : LuckyTicketsGenerator
    {
        public override void Generate(int quantityDigits)
        {
            int n1, n2;

            for (int i = 1; i < Math.Pow(10, quantityDigits); i++)
            {
                Ticket ticket = new Ticket(i, quantityDigits);

                n1 = ticket[0] + ticket[1] + ticket[2];
                n2 = ticket[3] + ticket[4] + ticket[5];

                if (n1 == n2)
                {
                    Tickets.Add(ticket);
                }
            }
        }
    }
}
