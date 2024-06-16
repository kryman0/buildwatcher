using BuildWatcher.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Validators
{
    internal static class CommandLineArgsValidator
    {
        public static void ValidateCommandLineArgs()
        {
            if (NotEnoughAmountOfArgs())
            {
                throw new MissingCommandLineArgumentException("Not enough command line arguments given.");
            }            
            else if (TooManyArgs())
            {
                throw new MissingCommandLineArgumentException("Too many command line arguments given.");
            }
            else if (!Environment.GetCommandLineArgs()[1].EndsWith(".csproj"))
            {
                throw new MissingProjectException("Path to project is wrong or filename not ending with .csproj");
            }
        }

        private static bool NotEnoughAmountOfArgs() => Environment.GetCommandLineArgs().Length < 4;
        private static bool TooManyArgs() => Environment.GetCommandLineArgs().Length > 4;
    }
}
