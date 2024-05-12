using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Exceptions
{
    internal class MissingProjectException : Exception
    {
        private string _message;
        public override string Message => _message;

        public MissingProjectException(string message)
        {
            _message = message;
        }
    }
}
