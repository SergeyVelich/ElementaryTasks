using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.UI
{
    class ConsoleView : IView
    {
        private const string BLOCK_SEPARATOR = "==================================================================";

        public void PrintTitleText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
        }

        public void PrintInstructionText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
            Console.ReadKey();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }

        public void PrintResult(string text, IEnumerable<long> sequence)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);

            bool isEmptyResult = true;

            foreach (int f in sequence)
            {
                if (!isEmptyResult)
                {
                    Console.Write(", ");
                }
                else
                {
                    isEmptyResult = false;
                }

                Console.Write(f.ToString());
            };

            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
