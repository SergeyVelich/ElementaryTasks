using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_EnvelopesAnalysis.Resources;

namespace Task2_EnvelopesAnalysis.UI
{
    class ConsoleView : IView
    {
        public event EventHandler SetHeight;
        public event EventHandler SetWidth;
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

        public void AskInputHeight(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            SetHeight?.Invoke(this, new StringEventArgs(arg));
        }

        public void AskInputWidth(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            SetWidth?.Invoke(this, new StringEventArgs(arg));
        }

        public void AskContinue(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            EndWork?.Invoke(this, new StringEventArgs(arg));
        }
    }
}
