using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.Model.ValidationInboxParameters
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

            if (!int.TryParse(_args[0], out int height))
            {
                throw new ArgumentException("");
            }
            else if (height <= 0)
            {
                throw new ArgumentException("");
            }
            else if (height > int.MaxValue)
            {
                throw new ArgumentException("");
            }

            if (!int.TryParse(_args[1], out int width))
            {
                throw new ArgumentException("");
            }
            else if (height <= 0)
            {
                throw new ArgumentException("");
            }
            else if (width > int.MaxValue)
            {
                throw new ArgumentException("");
            }

            inboxParameters.Height = height;
            inboxParameters.Width = width;

            return inboxParameters;
        }
    }
}
