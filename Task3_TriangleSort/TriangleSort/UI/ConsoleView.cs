using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleSort.Model;

namespace TriangleSort.UI
{
    class ConsoleView : IView
    {
        private const string BLOCK_SEPARATOR = "==================================================================";
        private const string TRIANGLE_LIST_HEADER = "============= Triangles list: ===============";
        private const string TRIANGLE_LIST_ROW = "{0}. [Triangle {1}]: {2} сm";

        public event EventHandler SetTriangle;
        public event EventHandler AddTriangle;
        public event EventHandler EndWork;

        public void PrintTitleText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
        }

        public void PrintInstructionText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintResult(IEnumerable<IFigure> triangles)
        {
            int count = 0;

            Console.WriteLine(TRIANGLE_LIST_HEADER);
            foreach (IFigure triangle in triangles)
            {
                Console.WriteLine(TRIANGLE_LIST_ROW, count++, triangle.Name, triangle.GetArea());
            }
            Console.WriteLine();
        }

        public void AskInputTriangle(string text)
        {
            Console.WriteLine(text);
            SetTriangle?.Invoke(this, new EventArgs());
        }

        public string GetTriangle()
        {
            return Console.ReadLine();
        }

        public void AskAddTrianglesFlag(string text)
        {
            Console.WriteLine(text);
            AddTriangle?.Invoke(this, new EventArgs());
        }

        public string GetAddTrianglesFlag()
        {
            return Console.ReadLine();
        }

        public void AskContinueFlag(string text)
        {
            Console.WriteLine(text);
            EndWork?.Invoke(this, new EventArgs());
        }

        public string GetContinueFlag()
        {
            return Console.ReadLine();
        }
    }
}
