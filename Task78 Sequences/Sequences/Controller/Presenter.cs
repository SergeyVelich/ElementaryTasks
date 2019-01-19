using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Model;
using Sequences.Model.ValidationInboxParameters;
using Sequences.UI;
using Sequences.Resources;

namespace Sequences.Controller
{
    class Presenter
    {       
        private IView _view;
        private string[] _args;
        private InboxParams _inboxParams;
        private WorkMode _workMode;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            _args = args;

            if (_args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
                return;
            }

            try
            {
                _inboxParams = new MainParamValidator(_args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            _workMode = GetWorkMode();

            try
            {
                ISequence sequence;
                switch (_workMode)
                {
                    case WorkMode.FibonaccіMode:
                        sequence = new FiboSequence(_inboxParams.LowLimit, _inboxParams.UpLimit);
                        _view.PrintResult(String.Format(MessagesResources.ResultFibonacciMode, _inboxParams.LowLimit, _inboxParams.UpLimit), sequence);
                        break;
                    case WorkMode.PowMode:
                        sequence = new PowSequence(_inboxParams.UpLimit);
                        _view.PrintResult(String.Format(MessagesResources.ResultPowMode, _inboxParams.LowLimit, _inboxParams.UpLimit), sequence);
                        break;
                    default:
                        throw new Exception(MessagesResources.ErrorInvalidWorkMode);
                }
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

        }

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 1)
            {
                workMode = WorkMode.PowMode;
            }
            else
            {
                workMode = WorkMode.FibonaccіMode;
            }

            return workMode;
        }
    }
}
