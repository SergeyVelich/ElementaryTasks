using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesAnalysis.UI
{
    interface IView
    {
        void PrintTitleText(string text);
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResultText(string text);
        void AskInputEnvelope(string text);
        void AskInputHeight(string text);
        void AskInputWidth(string text);
        void AskContinueFlag(string text);

        string GetHeight();
        string GetWidth();
        string GetContinueFlag();

        event EventHandler SetHeight;
        event EventHandler SetWidth;
        event EventHandler EndWork;
    }
}
