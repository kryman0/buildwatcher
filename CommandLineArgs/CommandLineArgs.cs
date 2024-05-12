using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.CommandLineArgs
{
    internal class CommandLineArgs
    {
        private string _pathToProj;
        public string PathToProj
        {
            get { return _pathToProj; }
            set
            {
                try
                {
                    Environment.GetCommandLineArgs()[1].EndsWith(".csproj");
                }
                catch
                {
                    throw new Exceptions.MissingProjectException("Path to project is wrong or filename not ending with .csproj");
                }

                _pathToProj = value;
            }
        }
        public static string PathToWatch => Environment.GetCommandLineArgs()[2];
        public static string PathToMSBuild => Environment.GetCommandLineArgs()[3];

        public CommandLineArgs()
        {
            try
            {
                CheckCorrectAmountOfArgs();
            } catch (Exception ex)
            {
                throw new Exceptions.MissingCommandLineArgumentException();
            }
        }

        private bool CheckCorrectAmountOfArgs()
        {
            if (Environment.GetCommandLineArgs().Length != 4)
            {
                return false;
            }

            return true;
        }
    }
}
