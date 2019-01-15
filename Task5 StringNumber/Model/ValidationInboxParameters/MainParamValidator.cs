using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_StringNumber.Resources;

namespace Task5_StringNumber.Model.ValidationInboxParameters
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
            Local region = Local.RU;

            InboxParameters inboxParameters = new InboxParameters();

            if (_args.Length < 1)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorArgumentNotFoundArgument, _args.Length + 1));
            }

            if (!long.TryParse(_args[0], out long number))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }
            else if (number < long.MinValue || number > long.MaxValue)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }

            if (_args.Length > 1)
            {
                if (Enum.IsDefined(typeof(Local), _args[1]))
                {
                    region = (Local)Enum.Parse(typeof(Local), _args[1]);
                }
                else
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidLocal);
                }
            }

            inboxParameters.Region = region;
            inboxParameters.Number = number;            

            return inboxParameters;
        }
    }
}
