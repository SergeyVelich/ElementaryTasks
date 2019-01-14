using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ArgumentException("Error");
            }

            if (!int.TryParse(_args[0], out int number))
            {
                throw new ArgumentException("Error");
            }
            else if (number < int.MinValue)
            {
                throw new ArgumentException("Error");
            }
            else if (number > int.MaxValue)
            {
                throw new ArgumentException("Error");
            }

            if (_args.Length > 1)
            {
                if (Enum.IsDefined(typeof(Local), _args[1]))
                {
                    region = (Local)Enum.Parse(typeof(Local), _args[1]);
                }
                else
                {
                    throw new ArgumentException("Error");
                }
            }

            inboxParameters.Region = region;
            inboxParameters.Number = number;            

            return inboxParameters;
        }
    }
}
