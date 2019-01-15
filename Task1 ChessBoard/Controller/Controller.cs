using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ChessBoard.Model;
using Task1_ChessBoard.Model.ValidationInboxParameters;
using Task1_ChessBoard.UI;
using Task1_ChessBoard.Resources;

namespace Task1_ChessBoard.Controller
{
    class Presenter
    {
        protected IView _view;
        protected InboxParameters _inboxParameters;

        public Presenter(IView view)
        {
            _view = view;
        }

        public virtual void Run(string[] args)
        {
            if (args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
                return;
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

            _view.PrintResult(new Board(_inboxParameters.Height, _inboxParameters.Width));
        }
    }
}
