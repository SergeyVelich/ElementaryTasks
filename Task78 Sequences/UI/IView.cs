using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.UI
{
    interface IView
    {
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintAnswerText(string text);
    }
}
