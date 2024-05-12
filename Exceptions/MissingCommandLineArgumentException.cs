using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Exceptions
{
    internal class MissingCommandLineArgumentException : Exception
    {
        public MissingCommandLineArgumentException()
        {

        }
    }
}
