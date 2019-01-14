using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_FileParser.UI
{
    class ConsoleView : IView
    {
        public void PrintInstructionText(string text)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(text);
            Console.WriteLine("==================================================================");
            Console.ReadKey();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadKey();
        }

        public void PrintAnswerText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
