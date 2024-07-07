using BuildWatcher.Exceptions;
using BuildWatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Validators
{
    internal class CommandLineArgsValidator
    {
        private static bool NotEnoughAmountOfArgs() => Environment.GetCommandLineArgs().Length < 4;
        private static bool TooManyArgs() => Environment.GetCommandLineArgs().Length > 4;

        private static void AreCLArgsValid(string projFlag, string watchFlag, string msbuildFlag)
        {
            string projArg = string.Empty, watchArg = string.Empty, msbuildArg = string.Empty, exMsg = string.Empty;
            
            foreach (string flag in Environment.GetCommandLineArgs().TakeWhile(f => f.StartsWith("-")))
            {
                if (flag.StartsWith(projFlag))
                {
                    projArg = flag.Substring(projFlag.Length);
                }
                else if (flag.StartsWith(watchFlag))
                {
                    watchArg = flag.Substring(watchFlag.Length);
                }
                else if (flag.StartsWith(msbuildFlag))
                {
                    msbuildArg = flag.Substring(msbuildFlag.Length);
                }
            }

            if (projArg == string.Empty)
            {
                exMsg = "Project path";
            } else if (watchFlag == string.Empty)
            {
                exMsg = "Watch directory";
            } else if (msbuildArg == string.Empty)
            {
                exMsg = "MSBuild path";
            }

            if (exMsg != string.Empty)
            {
                throw new MissingCommandLineArgumentException(exMsg + " is not set");
            }            
        }

        private static void ValidateCLFlags(string projFlag, string watchFlag, string msbuildFlag)
        {
            var exMsg = string.Empty;

            var flags = Environment.GetCommandLineArgs().Where(f => f.StartsWith("-"));

            if (!flags.Any(f => f.StartsWith(projFlag)))
            {
                exMsg = projFlag;
            }
            else if (!flags.Any(f => f.StartsWith(watchFlag)))
            {
                exMsg = watchFlag;
            }
            else if (!flags.Any(f => f.StartsWith(msbuildFlag)))
            {
                exMsg = msbuildFlag;
            }

            if (exMsg != string.Empty)
            {
                throw new MissingCommandLineArgumentException($"Missing {exMsg} flag");
            }
        }

        private static void ValidateNumberOfCLArgs()
        {
            if (NotEnoughAmountOfArgs())
            {
                throw new MissingCommandLineArgumentException("Not enough command line arguments given.");
            }
            else if (TooManyArgs())
            {
                throw new MissingCommandLineArgumentException("Too many command line arguments given.");
            }
        }

        public static void ValidateCommandLineArgs(string projFlag, string watchFlag, string msbuildFlag)
        {
            ValidateNumberOfCLArgs();

            ValidateCLFlags(projFlag, watchFlag, msbuildFlag);

            if (!Environment.GetCommandLineArgs()[1].EndsWith(".csproj"))
            {
                throw new MissingProjectException("Path to project is wrong or filename not ending with .csproj");
            }
        }

        public static bool ValidateNotToUseCommandLineInterface()
        {
            if (Environment.GetCommandLineArgs().Length == 1)
            {
                return true;
            }

            return false;
        }
    }
}
