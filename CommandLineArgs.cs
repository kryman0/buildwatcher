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
        private const string _projFlag = "-proj:";
        private const string _watchFlag = "-watch:";
        private const string _msbuildFlag = "-msbuild:";

        private void SetCLArgs()
        {
            foreach (string flag in Environment.GetCommandLineArgs())
            {
                if (flag.StartsWith(_projFlag))
                {
                    PathToProj = flag.Substring(_projFlag.Length);
                }
                else if (flag.StartsWith(_watchFlag))
                {
                    PathToWatch = flag.Substring(_watchFlag.Length);
                }
                else if (flag.StartsWith(_msbuildFlag))
                {
                    PathToMSBuild = flag.Substring(_msbuildFlag.Length);
                }
            }
        }
        
        public string? PathToProj { get; private set; }
        public string? PathToWatch { get; private set; }
        public string? PathToMSBuild { get; private set; }

        public CommandLineArgs()
        {
            CommandLineArgsValidator.ValidateCommandLineArgs();

            SetCLArgs();
        }        
    }
}
