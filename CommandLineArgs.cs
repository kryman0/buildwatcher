using BuildWatcher.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher
{
    internal class CommandLineArgs
    {
        public string PathToProj => Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
        public string PathToWatch => Path.GetFullPath(Environment.GetCommandLineArgs()[2]);
        public string PathToMSBuild => Path.GetFullPath(Environment.GetCommandLineArgs()[3]);

        public CommandLineArgs()
        {
            CommandLineArgsValidator.ValidateCommandLineArgs();
        }
    }
}
