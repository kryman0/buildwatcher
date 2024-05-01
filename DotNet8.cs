using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public class DotNet8 : ITargetDotNetVersionFactory
    {
        public ITargetDotNetVersionFactory GetDotNetVersion()
        {
            return this;
        }
    }
}
