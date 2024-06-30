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
        private enum Options
        {
            Quit = 0,
            Project = 1,
            Watch = 2,
            MSBuild = 3,
            MainMenu = 9,
        };

        public enum InputMessages
        {
            InputIsNullOrEmtpy = 1,
            InputIsNotAValidOption = 2,
        }

        public static Dictionary<InputMessages, string> InputMessagesDict => new()
        {
            { InputMessages.InputIsNullOrEmtpy, "Input was empty. Try again." + _newLineChooseOption },
            { InputMessages.InputIsNotAValidOption, "That's not an option! Try again." + _newLineChooseOption }
        };

        public static int[] ValidOptions => [
        
            (int)Options.Quit,
            (int)Options.Project,
            (int)Options.Watch,
            (int)Options.MSBuild,
            (int)Options.MainMenu,
        ];

        private const string _quit = "0. Quit";
        private const string _configureProject = "1. Configure Project";
        private const string _configureWatch = "2. Configure Folder";
        private const string _configureMSBuild = "3. Configure MSBuild";
        private const string _presentMainMenu = "9. Go to Main Menu";

        private static readonly string _newLineChooseOption = Environment.NewLine + "Choose: ";

        public static string MainMenu => _presentMainMenu;

        private static readonly Dictionary<Options, Action> _optionSubMenuDict = new()
        {
            { Options.Quit, QuitProgram },
            { Options.Project, MenuProject },
            { Options.MainMenu, PresentMainMenu },
            // todo: add others
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
            //sb.AppendLine($"{_presentMainMenu}");
            sb.AppendLine("-----------------------------------------------");

            Console.WriteLine(sb.ToString());
        }

        private static void GetSubMenuByInputOption()
        {
            Console.Write("Option: ");

            var input = Console.ReadKey().KeyChar.ToString();

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(InputMessagesDict[InputMessages.InputIsNullOrEmtpy]);

                GetSubMenuByInputOption();
            }

            if (!ConsoleMenuValidator.IsUserInputOptionValid(input))
            {
                Console.WriteLine(InputMessagesDict[InputMessages.InputIsNotAValidOption]);

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
                Console.WriteLine(InputMessagesDict[InputMessages.InputIsNullOrEmtpy]);

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

        public static void PresentSubMenu(string input)
        {
            var option = (Options)int.Parse(input);
            
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

            //GetSubMenuByInputOption();
        }

        //public ConsoleMenu(string pathToProj, string pathToWatch, string pathToMSBuild) : base(pathToProj, pathToWatch, pathToMSBuild)
        //{
        //    PresentMenu();
        //}
    }
}
