using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_StringNumber.Model;
using Task5_StringNumber.Controller;
using Task5_StringNumber.Representation;

namespace Task5_StringNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            IView view = new View();
            Presenter controller = new Presenter(view);
            controller.Run(args);           
        }
    }
}
