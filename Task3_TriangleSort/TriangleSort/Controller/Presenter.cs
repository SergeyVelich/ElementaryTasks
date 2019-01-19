using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleSort.Model;
using TriangleSort.Model.ValidationInboxParameters;
using TriangleSort.UI;
using TriangleSort.Resources;

namespace TriangleSort.Controller
{
    class Presenter
    {
        private const int NUMBER_REQUIRED_ARGS = 4;

        private IView _view;
        private InboxParameters _inboxParameters;
        private bool _continueFlag;
        private bool _addNextTriangleFlag;
        private List<IFigure> _triangles;

        public Presenter(IView view)
        {
            _view = view;

            _view.SetTriangle += OnSetTriangle;
            _view.AddTriangle += OnAddTriangle;
            _view.EndWork += OnEndWork;
        }

        public void Run(string[] args)
        {
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

            do
            {
                _triangles = new List<IFigure>();

                do
                {
                    try
                    {
                        _view.AskInputTriangle(MessagesResources.AskInputTriangle);
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                    }

                    _view.AskAddTrianglesFlag(MessagesResources.AskAddTriangle);
                } while (_addNextTriangleFlag);

                ISorter sorter = new TriangleSorter(_triangles);
                sorter.Sort(new TriangleComparerByAreaDesc());

                _view.PrintResult(sorter);
                _view.AskContinueFlag(MessagesResources.AskContunue);
            } while (_continueFlag);            
        }

        protected virtual void OnSetTriangle(object sender, EventArgs e)
        {
            string triangle = _view.GetTriangle();

            string[] arrTriangle = triangle.Split("".ToCharArray());

            if (arrTriangle.Length < NUMBER_REQUIRED_ARGS)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorArgumentNotFoundArgument, arrTriangle.Length + 1));
            }

            string name = arrTriangle[0];

            if (!double.TryParse(arrTriangle[1], out double sideA))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
            }

            if (!double.TryParse(arrTriangle[2], out double sideB))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 3));
            }

            if (!double.TryParse(arrTriangle[3], out double sideC))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 4));
            }

            _triangles.Add(Triangle.CreateTriangle(name, sideA, sideB, sideC));
        }

        protected virtual void OnAddTriangle(object sender, EventArgs e)
        {
            string addNextTriangleFlag = _view.GetAddTrianglesFlag();
            _addNextTriangleFlag = addNextTriangleFlag.ToLower().Trim() == MessagesResources.Yes 
                || addNextTriangleFlag.ToLower().Trim() == MessagesResources.YesShort;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            string continueFlag = _view.GetContinueFlag();
            _continueFlag = continueFlag.ToLower().Trim() == MessagesResources.Yes 
                || continueFlag.ToLower().Trim() == MessagesResources.YesShort;
        }
    }
}
