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
    class LuckyTicketsGenerator
    {
        public List<Ticket> Tickets { get; set; }
        public GenerationLackyTicketsMethod Method { get; set; }

        public LuckyTicketsGenerator()
        {
            Tickets = new List<Ticket>();
        }

        public LuckyTicketsGenerator(string filePath):this()
        {
            Method = GetCountMethod(filePath);
        }

        private GenerationLackyTicketsMethod GetCountMethod(string filePath)
        {
            string[] allStrings = File.ReadAllLines(filePath);

            return (GenerationLackyTicketsMethod)Enum.Parse(typeof(GenerationLackyTicketsMethod), allStrings[0]);
        }

        public void Generate()
        {
            int count = 0;
            string number;
            int n1, n2;

            if (Method == 0)
            {
                throw new Exception(MessagesResources.ErrorMethodNotFound);
            }

            for (int i = 0; i < 1000000; i++)
            {
                number = String.Format("{0:000000}", i);

                if (Method == GenerationLackyTicketsMethod.Piter)
                {
                    n1 = (int)number[0] + (int)number[2] + (int)number[4];
                    n2 = (int)number[1] + (int)number[3] + (int)number[5];
                }
                else
                {
                    n1 = (int)number[0] + (int)number[1] + (int)number[2];
                    n2 = (int)number[3] + (int)number[4] + (int)number[5];
                }

                if (n1 == n2)
                {
                    Ticket ticket = new Ticket(number);
                    Tickets.Add(ticket);
                    count ++;                    
                }              
            }
        }

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
