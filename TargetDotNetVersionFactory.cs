using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public class TargetDotNetVersionFactory : ITargetDotNetVersionFactory
    {
        //ITargetDotNetVersion<GetTargetedDotNetVersion _netVersionFactory;

        public ITargetDotNetVersionFactory GetDotNetVersion()
        {
#if NETFRAMEWORK
            return new DotNetFrameWork481();
#endif
#if NET8_0_OR_GREATER
            return new DotNet8();
#endif
        }
    }
}
