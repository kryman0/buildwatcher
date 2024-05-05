using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public class TargetDotNetVersionFactory
    {        
        //public string? PathToMSBuild { get; }

        //public ITargetDotNetVersionFactory TargetedDotNetVersion { get; private set; }

        //ITargetDotNetVersion<GetTargetedDotNetVersion _netVersionFactory;

        public ITargetDotNetVersionFactory TargetDotNetVersion(string pathToMSBuild)
        {
#if NETFRAMEWORK
            return new DotNetFramework481(pathToMSBuild);
#elif NET8_0_OR_GREATER
            //return new DotNet8();
#endif
            return new DotNet8(pathToMSBuild);
        }

        //public TargetDotNetVersionFactory(string pathToMSBuild)
        //{
        //    //PathToMSBuild = pathToMSBuild;
        //    //TargetedDotNetVersion = TargetDotNetVersion(pathToMSBuild);
        //}
    }
}
