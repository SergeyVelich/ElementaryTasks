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
        private IView _view;
        private InboxParameters _inboxParameters;
        private Envelope _currentEnvelope;
        private bool _run = true;
        private readonly int QUANTITY_ENVELOPES = 2;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            _view.SetHeight += OnSetHeight;
            _view.SetWidth += OnSetWidth;
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

            Envelope[] envelopes;
            EnvelopeComparer comparer;

            while (_run)
            {
                envelopes = new Envelope[QUANTITY_ENVELOPES];
                comparer = new EnvelopeComparer(envelopes);

                for (int i = 0; i < envelopes.Length; i++)
                {
                    _currentEnvelope = new Envelope();

                    bool isFailed = false;
                    do
                    {
                        try
                        {
                            _view.AskInputHeight("Enter height: ");
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
                            _view.AskInputWidth("Enter width: ");
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
                    comparer.Compare(envelopes[0], envelopes[i], out string viewText);
                    _view.PrintAnswerText(viewText);
                }

                _view.AskContinue("Do you want to continue? yes(y)/no(n)");
            }            
        }

        protected virtual void OnSetHeight(object sender, EventArgs e)
        {
            if (!double.TryParse(((StringEventArgs)e).Value, out double height))
            {
                throw new ArgumentException("Error");
            }
            _currentEnvelope.Height = height;         
        }

        protected virtual void OnSetWidth(object sender, EventArgs e)
        {
            if (!double.TryParse(((StringEventArgs)e).Value, out double width))
            {
                throw new ArgumentException("Error");
            }
            _currentEnvelope.Width = width;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            _run = ((StringEventArgs)e).Value.ToLower().Trim() == "y" || ((StringEventArgs)e).Value.ToLower().Trim() == "yes";
        }
    }
}
