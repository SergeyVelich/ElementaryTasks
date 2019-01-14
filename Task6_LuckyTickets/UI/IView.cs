using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.UI
{
    interface IView
    {
        void PrintInstructionText(string instruction);
        void PrintErrorText(string errorText);
        void PrintAnswerText(string answerText);
        void AskInputPath(string text);
        void AskContinue(string text);    

        event EventHandler SetPath;
        event EventHandler EndWork;
    }
}
