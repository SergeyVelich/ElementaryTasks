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
    public abstract class LuckyTicketsGenerator
    {
        public byte QuantityDigits { get; set; }
        public List<Ticket> Tickets { get; private set; }        

        public LuckyTicketsGenerator(byte quantityDigits)
        {
            QuantityDigits = quantityDigits;
            Tickets = new List<Ticket>();          
        }

        public void Generate()
        {
            bool[] pattern = GetPattern();

            int limit = (int)Math.Pow(10, QuantityDigits);
            for (uint i = 1; i < limit; i++)
            {
                Ticket ticket = new Ticket(i, QuantityDigits);
                if (IsLuckyTicket(ticket, pattern))
                {
                    Tickets.Add(ticket);
                }
            }
        }

        protected abstract bool[] GetPattern();

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

        public bool IsLuckyTicket(Ticket ticket, bool[] pattern)
        {
            int n1 = 0;
            int n2 = 0;

            for (byte j = 0; j < ticket.QuantityDigits; j++)
            {
                if (pattern[j])
                {
                    n1 += ticket[j];
                }
                else
                {
                    n2 += ticket[j];
                };
            }

            return n1 == n2;
        }
    }
}
