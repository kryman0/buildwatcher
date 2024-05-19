using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public class TargetDotNetVersionFactory
    {        
        public ITargetDotNetVersionFactory TargetedDotNetVersion { get; private set; }

        private ITargetDotNetVersionFactory TargetDotNetVersion(string pathToMSBuild)
        {
#if NETFRAMEWORK
            return new DotNetFramework481(pathToMSBuild);
#elif NET8_0_OR_GREATER
            return new DotNet8(pathToMSBuild);
#endif
        }

        public TargetDotNetVersionFactory(string pathToMSBuild)
        {
            TargetedDotNetVersion = TargetDotNetVersion(pathToMSBuild);
        }
    }
}
