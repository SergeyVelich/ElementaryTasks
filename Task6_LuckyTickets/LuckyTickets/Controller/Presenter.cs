using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly string _pathLog = "dataLog.txt";
        private readonly byte _quantityDigits = 6;

        private IView _view;
        private InboxParameters _inboxParams;
        private bool _continueFlag;
        private string _path;

        public Presenter(IView view)
        {
            _view = view;

            _view.SetPath += OnSetPath;
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

            LuckyTicketsGenerator lackyGenerator = null;
            GenerationLackyTicketsMethod countMethod;
            do
            {
                bool isFailed;
                do
                {
                    isFailed = false;                    
                    try
                    {
                        _view.AskInputPath(MessagesResources.AskInputPath);
                        countMethod = GetCountMethod(_path);
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                        continue;
                    }

                    switch (countMethod)
                    {
                        case GenerationLackyTicketsMethod.Moskow:
                            lackyGenerator = new LuckyTicketsGeneratorMoskow(_quantityDigits);
                            break;
                        case GenerationLackyTicketsMethod.Piter:
                            lackyGenerator = new LuckyTicketsGeneratorPiter(_quantityDigits);
                            break;
                        default:
                            _view.PrintErrorText(MessagesResources.ErrorInvalidWorkMode);
                            isFailed = true;
                            break;
                    }                                                   
                } while (isFailed);

                lackyGenerator.Generate();

                try
                {
                    lackyGenerator.SaveToFile(_pathLog);
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
            _path = path;
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
                case "Moskow":
                    method = GenerationLackyTicketsMethod.Moskow;
                    break;
                case "Piter":
                    method = GenerationLackyTicketsMethod.Piter;
                    break;
                default:
                    throw new Exception(MessagesResources.ErrorMethodNotFound);
            }

            return method;
        }
    }
}
