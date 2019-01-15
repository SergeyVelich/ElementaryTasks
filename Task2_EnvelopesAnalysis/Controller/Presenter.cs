using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_EnvelopesAnalysis.Model;
using Task2_EnvelopesAnalysis.Model.ValidationInboxParameters;
using Task2_EnvelopesAnalysis.UI;
using Task2_EnvelopesAnalysis.Resources;

namespace Task2_EnvelopesAnalysis.Controller
{
    class Presenter
    {
        private readonly int QUANTITY_ENVELOPES = 2;

        private IView _view;
        private InboxParameters _inboxParameters;
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
            Envelope[] envelopes;
            EnvelopeComparer envelopeComparer;

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

            while (_continueFlag)
            {
                envelopes = new Envelope[QUANTITY_ENVELOPES];
                envelopeComparer = new EnvelopeComparer();

                for (int i = 0; i < envelopes.Length; i++)
                {
                    _view.AskInputEnvelope(String.Format(MessagesResources.AskInputEnvelope, i+1));
                    _currentEnvelope = new Envelope();
                    bool isFailed = false;

                    do
                    {
                        try
                        {
                            _view.AskInputHeight(MessagesResources.AskInputHeight);
                            isFailed = false;
                        }
                        catch(Exception ex)
                        {
                            _view.PrintErrorText(ex.Message);
                            isFailed = true;
                        }
                    } while (isFailed);

                    do
                    {
                        try
                        {
                            _view.AskInputWidth(MessagesResources.AskInputWidth);
                            isFailed = false;
                        }
                        catch (Exception ex)
                        {
                            _view.PrintErrorText(ex.Message);
                            isFailed = true;
                        }
                    } while (isFailed);

                    envelopes[i] = _currentEnvelope;
                }

                for (int i = 1; i < envelopes.Length; i++)
                {
                    if (envelopeComparer.Compare(envelopes[0], envelopes[i]) > 0)
                    {
                        _view.PrintResultText(MessagesResources.ResultPositive);
                    }
                    else
                    {
                        _view.PrintResultText(MessagesResources.ResultNegative);
                    }
                }

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
                throw new ArgumentException(MessagesResources.ErrorInvalidArgument);
            }
            _currentEnvelope.Width = width;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            string continueFlag = _view.GetContinueFlag();
            _continueFlag = continueFlag.ToLower().Trim() == MessagesResources.Yes || continueFlag.ToLower().Trim() == MessagesResources.YesShort;
        }
    }
}
