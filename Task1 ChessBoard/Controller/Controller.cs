using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ChessBoard.Model;
using Task1_ChessBoard.Model.ValidationInboxParameters;
using Task1_ChessBoard.Representation;

namespace Task1_ChessBoard.Controller
{
    class Presenter
    {
        IView _view;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            string viewText;
            if (args.Length == 0)
            {
                viewText = "instruction";
                _view.PrintInstructionText(viewText);
                return;
            }

            MainParamValidator paramValidator = new MainParamValidator();
            InboxParameters inboxParameters = paramValidator.GetMainParameters(args);

            if (!inboxParameters.IsValid)
            {
                _view.PrintErrorText(inboxParameters.ErrorText);
                return;
            }

            Board board = new Board(inboxParameters.Height, inboxParameters.Width);
            viewText = board.ToString();
            _view.PrintAnswer(viewText);          
        }
    }
}
