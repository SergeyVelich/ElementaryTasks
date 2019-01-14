using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_TriangleSort.Model;
using Task3_TriangleSort.Model.ValidationInboxParameters;
using Task3_TriangleSort.UI;
using Task3_TriangleSort.Resources;

namespace Task3_TriangleSort.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;
        private bool _run;
        private bool _add;
        private List<Triangle> _triangles;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            TriangleSorter sorter;
            _view.SetTriangle += OnSetTriangle;
            _view.AddTriangle += OnAddTriangle;
            _view.EndWork += OnEndWork;

            if (args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.instruction);
            }

            try
            {
                _inboxParameters = new MainParamValidator(args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            _triangles = new List<Triangle>();
           
            {
                do
                {
                    try
                    {
                        _view.AskInputEnvelope("Enter next triangle: ");
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                    }

                    _view.AskContinueAddTriangles("Add next one? yes(y)/no(n)");
                } while (_add);

                sorter = new TriangleSorter(_triangles);
                sorter.Sort(new TriangleComparerByAreaDesc());

                _view.PrintAnswerText(sorter.ToString());
                _view.AskContinue("Do you want to continue? yes(y)/no(n)");
            }            
        }

        protected virtual void OnSetTriangle(object sender, EventArgs e)
        {
            if (!(((StringArrEventArgs)e).Value is string[]))
            {
                throw new ArgumentException("Error");
            }

            string[] arrAnswer = ((StringArrEventArgs)e).Value;

            if(arrAnswer.Length < 4)
            {
                throw new ArgumentException("Error");
            }

            string name = arrAnswer[0];
            if (!double.TryParse(arrAnswer[1], out double sideA)
                || !double.TryParse(arrAnswer[2], out double sideB)
                || !double.TryParse(arrAnswer[3], out double sideC))
            {
                throw new ArgumentException("Error");
            }

            _triangles.Add(new Triangle(name, sideA, sideB, sideC));
        }

        protected virtual void OnAddTriangle(object sender, EventArgs e)
        {
            _add = ((StringEventArgs)e).Value.ToLower().Trim() == "y" || ((StringEventArgs)e).Value.ToLower().Trim() == "yes";
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            _run = ((StringEventArgs)e).Value.ToLower().Trim() == "y" || ((StringEventArgs)e).Value.ToLower().Trim() == "yes";
        }
    }
}
