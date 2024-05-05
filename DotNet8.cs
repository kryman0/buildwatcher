using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public class DotNet8 : ITargetDotNetVersionFactory
    {
        public string PathToMSBuild { get; private set; }

        //public ITargetDotNetVersionFactory TargetDotNetVersion()
        //{
        //    return this;
        //}

        public DotNet8(string pathToMSBuild)
        {
            PathToMSBuild = pathToMSBuild;
        }
    }
}
