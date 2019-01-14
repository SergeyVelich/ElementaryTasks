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
        private bool _continueFlag;
        private bool _addNextTriangleFlag;
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
                _view.PrintInstructionText(MessagesResources.Instruction);
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

            do
            {
                do
                {
                    try
                    {
                        _view.AskInputEnvelope(MessagesResources.AskInputTriangle);
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                    }

                    _view.AskContinueAddTriangles(MessagesResources.AskAddTriangle);
                } while (_addNextTriangleFlag);

                sorter = new TriangleSorter(_triangles);
                sorter.Sort(new TriangleComparerByAreaDesc());

                _view.PrintResultText(sorter.ToString());
                _view.AskContinue(MessagesResources.AskContunue);
            } while (_continueFlag);            
        }

        protected virtual void OnSetTriangle(object sender, EventArgs e)
        {
            if (!(((StringArrEventArgs)e).Value is string[]))
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgument1);
            }

            string[] arrAnswer = ((StringArrEventArgs)e).Value;

            if(arrAnswer.Length < 4)
            {
                throw new ArgumentException(MessagesResources.ErrorArgumentNotFoundArgument4);
            }

            string name = arrAnswer[0];

            if (!double.TryParse(arrAnswer[1], out double sideA))
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgument2);
            }

            if (!double.TryParse(arrAnswer[2], out double sideB))
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgument3);
            }

            if (!double.TryParse(arrAnswer[3], out double sideC))
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgument4);
            }

            _triangles.Add(new Triangle(name, sideA, sideB, sideC));
        }

        protected virtual void OnAddTriangle(object sender, EventArgs e)
        {
            _addNextTriangleFlag = ((StringEventArgs)e).Value.ToLower().Trim() == MessagesResources.Yes || ((StringEventArgs)e).Value.ToLower().Trim() == MessagesResources.YesShort;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            _continueFlag = ((StringEventArgs)e).Value.ToLower().Trim() == MessagesResources.Yes || ((StringEventArgs)e).Value.ToLower().Trim() == MessagesResources.YesShort;
        }
    }
}
