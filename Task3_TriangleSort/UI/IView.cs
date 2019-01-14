using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_TriangleSort.UI
{
    interface IView
    {
        void PrintInstructionText(string instruction);
        void PrintErrorText(string errorText);
        void PrintAnswerText(string answerText);
        void AskInputEnvelope(string text);
        void AskContinue(string text);
        void AskContinueAddTriangles(string text);

        event EventHandler SetTriangle;
        event EventHandler AddTriangle;
        event EventHandler EndWork;
    }
}
