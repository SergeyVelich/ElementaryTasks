using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvelopesAnalysis.Model;
using EnvelopesAnalysis.Model.ValidationInboxParameters;
using EnvelopesAnalysis.UI;
using EnvelopesAnalysis.Resources;

namespace EnvelopesAnalysis.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParams;
        private Envelope _currentEnvelope;
        private bool _continueFlag = true;       

        public Presenter(IView view)
        {
            _view = view;

            _view.SetHeight += OnSetHeight;
            _view.SetWidth += OnSetWidth;
            _view.EndWork += OnEndWork;
        }

        public void Run(string[] args)
        {
            _view.PrintTitleText(MessagesResources.ApplicationName);

            try
            {
                _inboxParams = new MainParamValidator(args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }
            if (_inboxParams.WorkMode == WorkMode.HelpMode)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
            }

            while (_continueFlag)
            {
                AskEnvelops();
                _view.AskContinueFlag(MessagesResources.AskContunue);
            }            
        }

        protected virtual void OnSetHeight(object sender, EventArgs e)
        {
            if (!double.TryParse(_view.GetHeight(), out double height))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }
            _currentEnvelope.Height = height;         
        }

        protected virtual void OnSetWidth(object sender, EventArgs e)
        {
            if (!double.TryParse(_view.GetWidth(), out double width))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }
            _currentEnvelope.Width = width;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            string continueFlag = _view.GetContinueFlag();
            _continueFlag = continueFlag.ToLower().Trim() == MessagesResources.Yes 
                || continueFlag.ToLower().Trim() == MessagesResources.YesShort;
        }

        protected virtual void AskEnvelops()
        {
            bool isMainEnvelope = true;
            EnvelopeComparer envelopeComparer = new EnvelopeComparer(_inboxParams.QuantityEnvelopes);

            for (int i = 0; i < _inboxParams.QuantityEnvelopes; i++)
            {
                _view.AskInputEnvelope(String.Format(MessagesResources.AskInputEnvelope, i + 1));
                _currentEnvelope = new Envelope();
                bool isFailed;

                do
                {
                    isFailed = false;
                    try
                    {
                        _view.AskInputHeight(MessagesResources.AskInputHeight);
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);

                do
                {
                    isFailed = false;
                    try
                    {
                        _view.AskInputWidth(MessagesResources.AskInputWidth);
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);

                if (isMainEnvelope)
                {
                    envelopeComparer.MainEnvelope = _currentEnvelope;
                    isMainEnvelope = false;
                }
                else
                {
                    envelopeComparer.Insert(i - 1, _currentEnvelope);
                }
            }

            foreach (Envelope envelope in envelopeComparer)
            {
                if (envelopeComparer.Compare(envelope) > 0)
                {
                    _view.PrintResultText(MessagesResources.ResultPositive);
                }
                else
                {
                    _view.PrintResultText(MessagesResources.ResultNegative);
                }
            }
        }
    }
}
