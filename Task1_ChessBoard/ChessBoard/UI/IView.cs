using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Model;

namespace ChessBoard.UI
{
    interface IView
    {
        void PrintTitleText(string text);
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResult(IBoard<ICell> board, string text);
    }
}
