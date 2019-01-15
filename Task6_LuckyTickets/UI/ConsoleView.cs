using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_LuckyTickets.Resources;

namespace Task6_LuckyTickets.UI
{
    class ConsoleView : IView
    {
        private const string BLOCK_SEPARATOR = "==================================================================";

        public event EventHandler SetPath;
        public event EventHandler EndWork;

        public void PrintInstructionText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintResultText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void AskInputPath(string text)
        {
            Console.WriteLine(text);
            SetPath?.Invoke(this, new EventArgs());
        }

        public string GetPath()
        {
            return Console.ReadLine();
        }

        public void AskContinueFlag(string text)
        {
            Console.WriteLine(text);
            EndWork?.Invoke(this, new EventArgs());
        }

        public string GetContinueFlag()
        {
            return Console.ReadLine();
        }
    }
}
