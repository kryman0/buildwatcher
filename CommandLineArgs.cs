using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    internal static class CommandLineArgs
    {
        public static string PathToProj => Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
        public static string PathToWatch => Environment.GetCommandLineArgs()[2];
        public static string PathToMSBuild => Environment.GetCommandLineArgs()[3];
    }
}
