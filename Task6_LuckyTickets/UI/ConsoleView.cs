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
        public event EventHandler SetPath;
        public event EventHandler EndWork;

        public void PrintInstructionText(string text)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine(text);
            Console.WriteLine("==================================================================");
            Console.ReadLine();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public void PrintAnswerText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public void AskInputPath(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            SetPath?.Invoke(this, new StringEventArgs(arg));
        }

        public void AskContinue(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            EndWork?.Invoke(this, new StringEventArgs(arg));
        }
    }
}
