using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText.UI
{
    interface IView
    {
        void PrintTitleText(string text);
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResultText(string text);
    }
}
