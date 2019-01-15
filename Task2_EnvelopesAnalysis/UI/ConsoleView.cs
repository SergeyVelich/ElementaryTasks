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
        private const string BLOCK_SEPARATOR = "==================================================================";

        public event EventHandler SetHeight;
        public event EventHandler SetWidth;
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

        public void AskInputEnvelope(string text)
        {
            Console.WriteLine(text);
        }

        public void AskInputHeight(string text)
        {
            Console.WriteLine(text);
            SetHeight?.Invoke(this, new EventArgs());
        }

        public string GetHeight()
        {
            return Console.ReadLine();
        }

        public void AskInputWidth(string text)
        {
            Console.WriteLine(text);
            SetWidth?.Invoke(this, new EventArgs());
        }

        public string GetWidth()
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
