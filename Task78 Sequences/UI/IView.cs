using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Model;
using System.Collections;

namespace Task78_Sequences.UI
{
    interface IView
    {
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResult(string text, IEnumerable sequence);
    }
}
