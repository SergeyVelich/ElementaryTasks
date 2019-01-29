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
            return GetEnumerator(1, (int)Math.Pow(10, QuantityDigits));
        }

        public IEnumerator<Ticket> GetEnumerator(int lowLimit, int upLimit)
        {
            bool[] pattern = GetPattern();

            int limit = (int)Math.Pow(10, QuantityDigits);
            for (uint i = (uint)Math.Max(1, lowLimit); i < (uint)Math.Min(limit, upLimit); i++)
            {
                Ticket ticket = Ticket.Create(i, QuantityDigits);
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
            const int arrLenght = 10;
            const int arrLenghtDelta = 9;

            int[] baseArr = new int[arrLenght] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] currentArr = null;
            for (int i = 1; i < QuantityDigits / 2; i++)
            {
                currentArr = new int[baseArr.Length + arrLenghtDelta];
                for (int j = 0; j < currentArr.Length; j++)
                {
                    int kStart = Math.Max((j - arrLenght + 1), 0);
                    int kFinish = Math.Min(baseArr.Length - 1, j);
                    for (int k = kStart; k <= kFinish; k++)
                    {
                        currentArr[j] += baseArr[k];
                    }
                }

                baseArr = currentArr;
            }

            int count = 0;
            for (int i = 1; i < currentArr.Length; i++)
            {
                count += (int)Math.Pow(currentArr[i], 2);
            }

            return count;
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
