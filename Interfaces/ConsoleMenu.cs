using BuildWatcher.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class ConsoleMenu : BaseMenu
    {
        private const int _optionQuit = 0;
        private const int _optionProject = 1;
        private const int _optionWatch = 2;
        private const int _optionMSBuild = 3;

        public static int[] ValidOptions => [
            _optionQuit,
            _optionProject,
            _optionWatch,
            _optionMSBuild];

        private const string _configureProject = "1. Configure Project"; // add clargs and modify/remove below
        private const string _configureWatch = "2. Configure Folder";
        private const string _configureMSBuild = "3. Configure MSBuild";
        private const string _quit = "0. Quit";

        private static string GetMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Choose an option:");
            sb.AppendLine($"{_configureProject} (current: {PathToProj}):");
            sb.AppendLine($"{_configureWatch} (current: {PathToWatch}):");
            sb.AppendLine($"{_configureMSBuild} (current: {PathToMSBuild})");
            sb.AppendLine(_quit);

            return sb.ToString();
        }
        
        public static void PresentMenu()
        {            
            Console.WriteLine(GetMenu());
            
            GetMenuByInputOption();
        }

        private static void GetMenuByInputOption()
        {
            Console.Write("Option: ");

            var input = Console.ReadKey().KeyChar.ToString();

            if (!ConsoleMenuValidator.IsUserInputOptionValid(input))
            {
                Console.WriteLine($"{input} is not an option! Try again.");
                
                GetMenuByInputOption();
            }
            else
            {
                var result = int.Parse(input);

                switch (result)
                {
                    case _optionQuit:
                        Environment.Exit(0);
                        break;
                    case _optionProject:
                        MenuProject();
                        break;
                    case _optionWatch:
                        //
                        break;
                    case _optionMSBuild:
                        //
                        break;
                }
            }
        }

        private static void MenuProject()
        {
            Console.Write($"1. Enter absoulute path to project (e.g. C:\\PathToProject\\MyProject.csproj): ");
            
            var input = Console.ReadLine();

            if (HasUserQuitProgram(input))
            {
                Environment.Exit(0);
            }

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input) || 
                !ConsoleMenuValidator.IsPathToProjExtensionCorrect(input))
            {
                Console.WriteLine("Path to Project does not end with '.csproj'. Try again.");
                
                MenuProject();
            }

            PathToProj = input;

            
        }

        private static bool HasUserQuitProgram(string? quitCommand)
        {
            if (!string.IsNullOrEmpty(quitCommand) && quitCommand == _quit)
            {
                return true;
            }

            return false;
        }

        //public ConsoleMenu(string pathToProj, string pathToWatch, string pathToMSBuild) : base(pathToProj, pathToWatch, pathToMSBuild)
        //{
        //    PresentMenu();
        //}
    }
}
