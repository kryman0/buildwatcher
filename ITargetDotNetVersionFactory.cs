using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    public interface ITargetDotNetVersionFactory
    {
        public string PathToMSBuild { get; }
        //ITargetDotNetVersionFactory TargetDotNetVersion(string pathToMSBuild);
    }
}
