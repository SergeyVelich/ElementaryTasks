using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LuckyTickets.Resources;

namespace LuckyTickets.Model
{
    abstract class LuckyTicketsGenerator
    {
        public int QuantityDigits { get; set; }
        public List<Ticket> Tickets { get; private set; }        

        public LuckyTicketsGenerator(int quantityDigits)
        {
            QuantityDigits = quantityDigits;
            Tickets = new List<Ticket>();          
        }

        public void Generate()
        {
            int[] pattern = GetPattern();

            int limit = (int)Math.Pow(10, QuantityDigits);
            for (int i = 1; i < limit; i++)
            {
                int n1 = 0;
                int n2 = 0;

                Ticket ticket = new Ticket(i, QuantityDigits);

                for (int j = 0; j < QuantityDigits; j++)
                {
                    if (pattern.Contains(j))
                    {
                        n1 += ticket[j];
                    }
                    else
                    {
                        n2 += ticket[j];
                    };
                }

                if (n1 == n2)
                {
                    Tickets.Add(ticket);
                }
            }
        }

        protected abstract int[] GetPattern();

        public void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Ticket ticket in Tickets)
                {
                    writer.WriteLine(ticket.ToString());
                }
            }
        }

        public int Count()
        {
            return Tickets.Count();
        } 
    }
}
