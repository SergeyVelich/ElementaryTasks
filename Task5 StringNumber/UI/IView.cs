using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.UI
{
    interface IView
    {
        void PrintInstructionText(string instruction);
        void PrintErrorText(string errorText);
        void PrintAnswerText(string answerText);
    }
}
