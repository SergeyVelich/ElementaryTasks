using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Representation
{
    class View : IView
    {
        public void PrintInstructionText(string instructionText)
        {
            Console.WriteLine(instructionText);
            Console.ReadKey();
        }

        public void PrintErrorText(string errorText)
        {
            Console.WriteLine(errorText);
            Console.ReadKey();
        }

        public void PrintAnswer(string answerText)
        {
            Console.WriteLine(answerText);
            Console.ReadKey();
        }
    }
}
