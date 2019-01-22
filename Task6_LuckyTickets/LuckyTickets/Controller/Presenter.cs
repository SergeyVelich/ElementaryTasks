using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.Model;
using LuckyTickets.Model.ValidationInboxParameters;
using LuckyTickets.UI;
using LuckyTickets.Resources;
using System.IO;

namespace LuckyTickets.Controller
{
    class Presenter
    {
        private const string MOSKOW_METHOD = "Moskow";
        private const string PITER_METHOD = "Piter";

        private IView _view;
        private InboxParameters _inboxParams;
        private bool _continueFlag;
        private GenerationLackyTicketsMethod _countMethod;

        public Presenter(IView view)
        {
            _view = view;

            _view.SetPath += OnSetPath;
            _view.EndWork += OnEndWork;
        }

        public void Run(string[] args)
        {
            _view.PrintTitleText(MessagesResources.ApplicationName);
            _view.PrintInstructionText(MessagesResources.Instruction);

            try
            {
                _inboxParams = new MainParamValidator(args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            do
            {
                bool isFailed;
                do
                {
                    isFailed = false;                    
                    try
                    {
                        _view.AskInputPath(MessagesResources.AskInputPath);                        
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);

                LuckyTicketsGenerator lackyGenerator = LuckyTicketsGenerator.Create(_countMethod, _inboxParams.QuantityDigits);
                
                try
                {
                    if(_inboxParams.PathLog != String.Empty)
                    {
                        lackyGenerator.SaveToFile(_inboxParams.PathLog);
                    }
                }
                catch
                {
                    _view.PrintErrorText(MessagesResources.ErrorFileNotSaved);
                }

                _view.PrintResultText(String.Format(MessagesResources.Result, lackyGenerator.Count().ToString()));
                _view.AskContinueFlag(MessagesResources.AskContunue);

            } while (_continueFlag);
        }

        protected virtual void OnSetPath(object sender, EventArgs e)
        {
            string path = _view.GetPath();
            if (!File.Exists(path))
            {
                throw new ArgumentException(MessagesResources.ErrorFileNotFound);
            }

            _countMethod = GetCountMethod(path);
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            string continueFlag = _view.GetContinueFlag();
            _continueFlag = continueFlag.ToLower().Trim() == MessagesResources.Yes 
                || continueFlag.ToLower().Trim() == MessagesResources.YesShort;
        }

        protected virtual GenerationLackyTicketsMethod GetCountMethod(string filePath)
        {
            string[] allStrings;

            try
            {
                allStrings = File.ReadAllLines(filePath);
            }
            catch
            {
                throw;
            }

            GenerationLackyTicketsMethod method;

            switch (allStrings[0])
            {
                case MOSKOW_METHOD:
                    method = GenerationLackyTicketsMethod.Moskow;
                    break;
                case PITER_METHOD:
                    method = GenerationLackyTicketsMethod.Piter;
                    break;
                default:
                    throw new Exception(MessagesResources.ErrorMethodNotFound);
            }

            return method;
        }
    }
}
