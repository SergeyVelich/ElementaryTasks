using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Model;
using System.Collections;

namespace Sequences.UI
{
    interface IView
    {
        void PrintTitleText(string text);
        void PrintInstructionText(string text);
        void PrintErrorText(string text);
        void PrintResult(string text, IEnumerable<long> sequence);
    }
}
