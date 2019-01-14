using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_FileParser.Resources;

namespace Task4_FileParser.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        private readonly string[] _args;

        public MainParamValidator(string[] args)
        {
            _args = args;
        }

        public InboxParameters GetMainParameters()
        {
            InboxParameters inboxParameters = new InboxParameters();

            if (_args.Length < 2)
            {
                throw new ArgumentException(MessagesResources.ErrorArgumentNotFoundArgument2);
            }

            if (!File.Exists(_args[0]))
            {
                throw new ArgumentException(MessagesResources.ErrorFileNotFound);
            }

            inboxParameters.Path = _args[0];
            if (_args.Length == 2)
            {
                inboxParameters.Pattern = _args[1];
            }
            else
            {
                inboxParameters.Pattern = _args[1];
                inboxParameters.Replacement = _args[2];
            }

            return inboxParameters;
        }
    }
}
