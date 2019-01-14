using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.UI
{
    interface IView
    {
        void PrintInstructionText(string instruction);
        void PrintErrorText(string errorText);
        void PrintAnswerText(string answerText);
    }
}
