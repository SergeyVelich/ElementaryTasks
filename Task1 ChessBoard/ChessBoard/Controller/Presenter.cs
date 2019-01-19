using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Model;
using ChessBoard.Model.ValidationInboxParameters;
using ChessBoard.UI;
using ChessBoard.Resources;

namespace ChessBoard.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;

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
