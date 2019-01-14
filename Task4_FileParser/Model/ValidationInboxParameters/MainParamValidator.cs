using System;
using System.Collections.Generic;
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
                throw new ArgumentException("");
            }

            //if (!int.TryParse(_args[0], out lowLimit))
            //{
            //    throw new ArgumentException("");
            //}
            //if (!File.Exists(path))
            //{
            //    throw new FileToParseNotFoundException(path);
            //}

            inboxParameters.Path = _args[0];
            if (_args.Length == 2)
            {
                inboxParameters.StringToFind = _args[1];
        }
            else
            {
                inboxParameters.StringToReplaced = _args[1];
                inboxParameters.StringReplacer = _args[2];
            }

            return inboxParameters;
        }
    }
}
