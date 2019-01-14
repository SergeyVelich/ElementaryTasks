using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_EnvelopesAnalysis.UI
{
    interface IView
    {
        void PrintInstructionText(string instruction);
        void PrintErrorText(string errorText);
        void PrintAnswerText(string answerText);
        void AskInputHeight(string text);
        void AskInputWidth(string text);
        void AskContinue(string text);

        event EventHandler SetHeight;
        event EventHandler SetWidth;
        event EventHandler EndWork;
    }
}
