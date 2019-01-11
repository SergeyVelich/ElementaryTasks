using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        public InboxParameters GetMainParameters(string[] args)
        {
            int number = 0;
            Local region = Local.RU;

            InboxParameters inboxParameters = new InboxParameters();
            inboxParameters.IsValid = true;
            inboxParameters.ErrorText = "";

            if (args.Length < 1)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (!int.TryParse(args[0], out number))
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (number < int.MinValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (number > int.MaxValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (args.Length > 1)
            {
                if (Enum.IsDefined(typeof(Local), args[1]))
                {
                    region = (Local)Enum.Parse(typeof(Local), args[1]);
                }
                else
                {
                    inboxParameters.IsValid = false;
                    inboxParameters.ErrorText = "Property cannot be null or empty";
                }
            }

            inboxParameters.Region = region;
            inboxParameters.Number = number;            

            return inboxParameters;
        }
    }
}
