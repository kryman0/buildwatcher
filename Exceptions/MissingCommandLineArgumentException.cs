using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Exceptions
{
    internal class MissingCommandLineArgumentException : Exception
    {
        private string _message;
        public override string Message => _message;

        public MissingCommandLineArgumentException(string message)
        {
            _message = message;
        }
    }
}
