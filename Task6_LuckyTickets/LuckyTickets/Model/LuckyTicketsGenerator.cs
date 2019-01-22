using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LuckyTickets.Resources;

namespace LuckyTickets.Model
{
    public abstract class LuckyTicketsGenerator : IEnumerable<Ticket>
    {
        public byte QuantityDigits { get; set; }    

        public LuckyTicketsGenerator(byte quantityDigits)
        {
            QuantityDigits = quantityDigits;      
        }

        public static LuckyTicketsGenerator Create(GenerationLackyTicketsMethod method, byte quantityDigits)
        {
            switch (method)
            {
                case GenerationLackyTicketsMethod.Moskow:
                    return new LuckyTicketsGeneratorMoskow(quantityDigits);

                case GenerationLackyTicketsMethod.Piter:
                    return new LuckyTicketsGeneratorPiter(quantityDigits);

                default:
                    throw new ArgumentException(MessagesResources.ErrorInvalidWorkMode);
            }
        }

        public IEnumerator<Ticket> GetEnumerator()
        {
            bool[] pattern = GetPattern();

            int limit = (int)Math.Pow(10, QuantityDigits);
            for (uint i = 1; i < limit; i++)
            {
                Ticket ticket = new Ticket(i, QuantityDigits);
                if (IsLuckyTicket(ticket, pattern))
                {
                    yield return ticket;
                }
            }          
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract bool[] GetPattern();

        public void SaveToFile(string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (Ticket ticket in this)
                    {
                        writer.WriteLine(ticket.ToString());
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public int Count()
        {
            return (this as IEnumerable<Ticket>).Count();
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
