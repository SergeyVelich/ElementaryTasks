using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.UI
{
    interface IView
    {
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResultText(string text);
        void AskInputPath(string text);
        void AskContinueFlag(string text);

        string GetPath();
        string GetContinueFlag();

        event EventHandler SetPath;
        event EventHandler EndWork;
    }
}
