using BuildWatcher.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class ConsoleMenu : BaseMenu
    {
        private const int _optionQuit = 0;
        private const int _optionProject = 1;
        private const int _optionWatch = 2;
        private const int _optionMSBuild = 3;
        private const int _optionMainMenu = 9;

        private const int _inputIsNullOrEmtpyMsg = 10;

        public static int[] ValidOptions => [
            _optionQuit,
            _optionProject,
            _optionWatch,
            _optionMSBuild,
            ];

        private const string _quit = "0. Quit";
        private const string _configureProject = "1. Configure Project";
        private const string _configureWatch = "2. Configure Folder";
        private const string _configureMSBuild = "3. Configure MSBuild";        
        private const string _presentMainMenu = "9. Present Menu";

        private static readonly Dictionary<int, Action> _optionSubMenuDict = new()
        {
            { _optionQuit, QuitProgram },
            { _optionProject, MenuProject },
            { _optionMainMenu, PresentMainMenu },
            // todo: add others
        };

        private static readonly Dictionary<int, string> _wrongInputMessages = new()
        {
            { _inputIsNullOrEmtpyMsg, "Input was empty. Please try again." },
        };

        private static void QuitProgram()
        {
            Console.WriteLine("Exiting program...");
            
            Thread.Sleep(1500);

            Environment.Exit(0);
        }

        private static void PresentMainMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Any of the following options can always be chosen:");
            sb.AppendLine(_quit);
            sb.AppendLine($"{_configureProject} (current: {PathToProj}):");
            sb.AppendLine($"{_configureWatch} (current: {PathToWatch}):");
            sb.AppendLine($"{_configureMSBuild} (current: {PathToMSBuild})");
            sb.AppendLine($"{_presentMainMenu}");
            sb.AppendLine("-----------------------------------------------");

            Console.WriteLine(sb.ToString());
        }

        private static void GetSubMenuByInputOption()
        {
            Console.Write("Option: ");

            var input = Console.ReadKey().KeyChar.ToString();

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(_wrongInputMessages[_inputIsNullOrEmtpyMsg]);

                GetSubMenuByInputOption();
            }

            if (!ConsoleMenuValidator.IsUserInputOptionValid(input))
            {
                Console.WriteLine($"{input} is not an option! Try again.");

                GetSubMenuByInputOption();
            }

            if (HasUserQuitProgram(input))
            {
                QuitProgram();
            }

            PresentSubMenu(input);
        }

        private static void MenuProject()
        {
            Console.WriteLine("Enter absoulute path to project (e.g. C:\\PathToProject\\MyProject.csproj): ");

            var input = Console.ReadLine() ?? string.Empty;

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(_wrongInputMessages[_inputIsNullOrEmtpyMsg]);

                PresentMainMenu();

                MenuProject();                
            }

            if (HasUserChosenAnyOption(input) && !HasUserQuitProgram(input)) 
            {
                PresentSubMenu(input);
            }
                        
            if (HasUserQuitProgram(input))
            {
                QuitProgram();
            }

            if (!ConsoleMenuValidator.IsPathToProjExtensionCorrect(input))
            {
                Console.WriteLine("Path to Project does not end with '.csproj'. Try again.");

                PresentMainMenu();

                MenuProject();
            }

            PathToProj = input;            
        }

        private static void PresentSubMenu(string input)
        {
            var option = int.Parse(input);
            
            _optionSubMenuDict[option]();
        }

        private static bool HasUserQuitProgram(string input)
        {            
            if (input == _quit)
            {
                return true;
            }

            return false;
        }

        private static bool HasUserChosenAnyOption(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return ValidOptions.Contains(result);
            }

            return false;
        }

        public static void PresentConsoleMenu()
        {
            PresentMainMenu();

            GetSubMenuByInputOption();
        }

        //public ConsoleMenu(string pathToProj, string pathToWatch, string pathToMSBuild) : base(pathToProj, pathToWatch, pathToMSBuild)
        //{
        //    PresentMenu();
        //}
    }
}
