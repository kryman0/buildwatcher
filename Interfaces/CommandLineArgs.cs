using BuildWatcher.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class CommandLineArgs : BaseMenu
    {
        private const string _projFlag = "-proj:";
        private const string _watchFlag = "-watch:";
        private const string _msbuildFlag = "-msbuild:";

        private static void SetPathsFromCLArgs()
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

        public static void Validate()
        {
            CommandLineArgsValidator.ValidateCommandLineArgs(_projFlag, _watchFlag, _msbuildFlag);

            SetPathsFromCLArgs();

            CommandLineArgsValidator.ValidatePaths(PathToProj, PathToWatch, PathToMSBuild);
        }
    }
}
