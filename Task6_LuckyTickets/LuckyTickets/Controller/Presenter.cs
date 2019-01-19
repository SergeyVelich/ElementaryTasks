﻿using System;
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
                                lackyGenerator = new LuckyTicketsGeneratorMoskow(_quantityDigits);
                                break;
                            case GenerationLackyTicketsMethod.Piter:
                                lackyGenerator = new LuckyTicketsGeneratorPiter(_quantityDigits);
                                break;
                            default:
                                isFailed = true;
                                throw new Exception(MessagesResources.ErrorInvalidWorkMode);
                        }                       
                        isFailed = false;
                        lackyGenerator.Generate();                       
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);

                lackyGenerator.SaveToFile(_pathLog);

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
