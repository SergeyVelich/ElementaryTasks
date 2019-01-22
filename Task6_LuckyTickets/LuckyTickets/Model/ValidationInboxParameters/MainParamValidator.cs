using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LuckyTickets.Resources;

namespace LuckyTickets.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        private const int QUANTITY_REQUIRED_PARAM = 0;
        private const string PATH_LOG_DEFAULT = "dataLog.txt";
        private const byte QUANTITY_DIGITS_DEFAULT = 6;
        private const string PARAM_PATTERN = @"(/.*):(.*)";
        private const string PARAM_QUANTITY_DIGITS = "/D";
        private const string PARAM_PATH_LOG = "/L";

        private readonly string[] _args;

        public MainParamValidator(string[] args)
        {
            _args = args;
        }

        public InboxParameters GetMainParameters()
        {
            InboxParameters inboxParams = new InboxParameters
            {
                WorkMode = GetWorkMode(),
                QuantityDigits = QUANTITY_DIGITS_DEFAULT,
                PathLog = PATH_LOG_DEFAULT                
            };

            if (inboxParams.WorkMode == WorkMode.HelpMode)
            {
                return inboxParams;
            }

            for (int i = QUANTITY_REQUIRED_PARAM; i < _args.Length; i++)
            {
                Match match = Regex.Match(_args[i], PARAM_PATTERN);
                if (match.Success)
                {
                    if (match.Groups[1].Value == PARAM_QUANTITY_DIGITS)
                    {
                        if(!byte.TryParse(match.Groups[2].Value, out byte quantityDigits))
                        {
                            throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, PARAM_QUANTITY_DIGITS));
                        }
                        if(quantityDigits % 2 != 0)
                        {
                            throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, PARAM_QUANTITY_DIGITS));
                        }
                        inboxParams.QuantityDigits = quantityDigits;
                    }
                    if (match.Groups[1].Value == PARAM_PATH_LOG)
                    {
                        inboxParams.PathLog = match.Groups[2].Value;
                    }
                }
            }

            return inboxParams;
        }

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 0)
            {
                workMode = WorkMode.HelpMode;
            }
            else 
            {
                workMode = WorkMode.MainMode;
            }

            return workMode;
        }
    }
}
