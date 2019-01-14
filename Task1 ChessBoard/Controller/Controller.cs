using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ChessBoard.Model;
using Task1_ChessBoard.Model.ValidationInboxParameters;
using Task1_ChessBoard.UI;

namespace Task1_ChessBoard.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.instruction);
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

            _view.PrintAnswerText(new Board(_inboxParameters.Height, _inboxParameters.Width).ToString());          
        }
    }
}
