using BuildWatcher.Validators;
using System.Text;

namespace BuildWatcher.Interfaces
{
    internal class ConsoleMenu : BaseMenu
    {
        protected ConsoleMenu() { }

        private enum Options
        {
            Quit = 0,
            MainMenu = 1,
            Project = 2,
            Watch = 3,
            MSBuild = 4,
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

        private static readonly string _newLineChooseOption = Environment.NewLine + "Choose: ";
                
        private static int[] _validOptions => [
        
            (int)Options.Quit,
            (int)Options.MainMenu,
            (int)Options.Project,
            (int)Options.Watch,
            (int)Options.MSBuild,
        ];

        private const string _presentMainMenu = "1. Go to Main Menu";
        private const string _configureProject = "2. Configure Project";
        private const string _configureWatch = "3. Configure Folder";
        private const string _configureMSBuild = "4. Configure MSBuild";
        private const string _quit = "0. Quit";

        public static string MainMenu => _presentMainMenu;

        private static Dictionary<Options, Action> OptionSubMenuDict => new()
        {
            { Options.Quit, QuitProgram },
            { Options.MainMenu, PresentMainMenu },
            { Options.Project, MenuProject },
            { Options.Watch, MenuFolder },
            // todo: add others
        };
                
        private static void PresentMainMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Any of the following options can always be chosen:");
            sb.AppendLine($"{_configureProject} (current: {PathToProj}):");
            sb.AppendLine($"{_configureWatch} (current: {PathToWatch}):");
            sb.AppendLine($"{_configureMSBuild} (current: {PathToMSBuild})");
            sb.AppendLine(_quit);
            sb.AppendLine("-----------------------------------------------");
            sb.AppendLine("When paths to Project, Folder and MSBuild are configured, program will start.");

            Console.WriteLine(sb.ToString());
        }

        private static void MenuProject()
        {
            const string pathToProjMsg = "Enter absoulute path to project (e.g. C:\\PathToProject\\MyProject.csproj): ";

            Retry:
            Console.WriteLine(pathToProjMsg);

            var input = Console.ReadLine() ?? string.Empty;

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(InputMessagesDict[InputMessages.InputIsNullOrEmtpy]);

                goto Retry;
            }
            else if (HasUserChosenAnyOption(input))
            {
                PresentSubMenu(input);
            }
            else if (!ConsoleMenuValidator.IsPathToProjExtensionCorrect(input))
            {
                Console.WriteLine($"Path to project {input} does not end with '.csproj'. Try again.");

                goto Retry;
            }
            else
            {
                PathToProj = input;
            }

            PresentMainMenu();
        }

        private static void MenuFolder()
        {
            const string pathToFolder = "Enter absolute path to folder (e.g. C:\\PathToProject\\SomeDirectory or C:\\PathToProject)";

            Retry:
            Console.WriteLine(pathToFolder);

            var input = Console.ReadLine() ?? string.Empty;

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(InputMessagesDict[InputMessages.InputIsNullOrEmtpy]);

                goto Retry;
            }
            else if (HasUserChosenAnyOption(input))
            {
                PresentSubMenu(input);
            }
            else
            {
                PathToProj = input;
            }

            PresentMainMenu();
        }
        
        private static void QuitProgram()
        {
            Console.WriteLine("Exiting program...");

            Thread.Sleep(1500);

            Environment.Exit(0);
        }

        public static bool HasUserChosenAnyOption(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return _validOptions.Contains(result);
            }

            return false;
        }

        public static void PresentConsoleMenu()
        {
            PresentMainMenu();
        }

        public static void PresentSubMenu(string input)
        {
            var option = (Options)int.Parse(input);

            OptionSubMenuDict[option]();
        }
    }
}
