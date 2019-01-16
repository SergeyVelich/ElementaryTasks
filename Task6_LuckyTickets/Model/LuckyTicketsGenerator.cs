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
    abstract class LuckyTicketsGenerator
    {
        public List<Ticket> Tickets { get; set; }

        public LuckyTicketsGenerator()
        {
            Tickets = new List<Ticket>();
        }

        public abstract void Generate(int quantityDigits);

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
