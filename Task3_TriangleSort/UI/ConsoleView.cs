using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_TriangleSort.Resources;

namespace Task3_TriangleSort.UI
{
    class ConsoleView : IView
    {
        public event EventHandler SetTriangle;
        public event EventHandler AddTriangle;
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

        public void AskInputEnvelope(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            string[] args = arg.Split(" ".ToCharArray());
            SetTriangle?.Invoke(this, new StringArrEventArgs(args));
        }

        public void AskContinueAddTriangles(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            AddTriangle?.Invoke(this, new StringEventArgs(arg));
        }

        public void AskContinue(string text)
        {
            Console.WriteLine(text);
            string arg = Console.ReadLine();
            EndWork?.Invoke(this, new StringEventArgs(arg));
        }     
    }
}
