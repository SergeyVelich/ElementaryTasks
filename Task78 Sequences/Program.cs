using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Controller;
using Task78_Sequences.Representation;

namespace Task78_Sequences
{
    class Program
    {
        public static void Main(string[] args)
        {
            IView view = new View();
            Presenter controller = new Presenter(view);
            controller.Run(args);            
        }
    }
}
