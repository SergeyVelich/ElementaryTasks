using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_LuckyTickets.Model;
using Task6_LuckyTickets.Model.ValidationInboxParameters;
using Task6_LuckyTickets.UI;
using Task6_LuckyTickets.Resources;
using System.IO;

namespace Task6_LuckyTickets.Controller
{
    class Presenter
    {
        private readonly string PATH_LOG = "dataLog.txt";
        private readonly int QUANTITY_DIGITS = 6;

        private IView _view;
        private InboxParameters _inboxParameters;
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
            LuckyTicketsGenerator lackyGenerator = null;

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

            do
            {
                bool isFailed = false;
                do
                {
                    try
                    {
                        _view.AskInputPath(MessagesResources.AskInputPath);

                        switch (GetCountMethod(_path))
                        {
                            case GenerationLackyTicketsMethod.Moskow:
                                lackyGenerator = new LuckyTicketsGeneratorMoskow();
                                break;
                            case GenerationLackyTicketsMethod.Piter:
                                lackyGenerator = new LuckyTicketsGeneratorPiter();
                                break;
                            default:
                                isFailed = true;
                                throw new Exception(MessagesResources.ErrorInvalidWorkMode);
                        }                       
                        isFailed = false;
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);
               
                lackyGenerator.Generate(QUANTITY_DIGITS);
                lackyGenerator.SaveToFile(PATH_LOG);
                _view.PrintResultText(lackyGenerator.Count().ToString());
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
            _continueFlag = continueFlag.ToLower().Trim() == MessagesResources.Yes || continueFlag.ToLower().Trim() == MessagesResources.YesShort;
        }

        private GenerationLackyTicketsMethod GetCountMethod(string filePath)
        {
            string[] allStrings = File.ReadAllLines(filePath);

            GenerationLackyTicketsMethod method;

            try
            {
                method = (GenerationLackyTicketsMethod)Enum.Parse(typeof(GenerationLackyTicketsMethod), allStrings[0]);
            }
            catch
            {
                throw new Exception(MessagesResources.ErrorMethodNotFound);
            }

            return method;
        }

    }
}
