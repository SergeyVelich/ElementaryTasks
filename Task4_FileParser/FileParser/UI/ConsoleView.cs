using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.UI
{
    class ConsoleView : IView
    {
        private const string BLOCK_SEPARATOR = "==================================================================";

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

        public void PrintResultText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
