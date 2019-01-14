using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_EnvelopesAnalysis.Model.ValidationInboxParameters
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
            return inboxParameters;
        }
    }
}
