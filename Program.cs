using BuildWatcher;
using BuildWatcher.Handlers;
using BuildWatcher.Interfaces;
using BuildWatcher.Validators;

#if !NETSTANDARD
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Locator;
#endif

//pathToMSBuild = "C:\\Program Files\\dotnet\\sdk\\8.0.203\\";
//var clArgs = new CommandLineArgs();

// todo: need to check which approach user chooses, cli or menu

CommandLineArgs.Validate();

var dotNetVersion = TargetDotNetVersionFactory.TargetDotNetVersion(CommandLineArgs.PathToMSBuild);

#if !NETSTANDARD
MSBuildLocator.RegisterMSBuildPath(dotNetVersion.PathToMSBuild);
#endif

void OnChanged(object sender, FileSystemEventArgs e)
{
    if (e.ChangeType == WatcherChangeTypes.Changed && e.FullPath.Contains(".cs"))
    {        
        BuildHandler.Build(CommandLineArgs.PathToProj, null);

        Console.WriteLine(
            $"File or Directory changed: {e.Name}{Environment.NewLine}" +
            $"Location of the change: {e.FullPath}{Environment.NewLine}" +
            $"ChangeType: {e.ChangeType}{Environment.NewLine}");

        Console.WriteLine("Waiting for changes...");
        
        Console.WriteLine(ConsoleMenu.MainMenu);
    }        
}

try
{
    using (var fsWatcher = new FileSystemWatcher(CommandLineArgs.PathToWatch))
    {
        fsWatcher.EnableRaisingEvents = true;
        fsWatcher.IncludeSubdirectories = true;
        fsWatcher.NotifyFilter = NotifyFilters.LastWrite;

        Console.WriteLine("Waiting for changes...");
        
        fsWatcher.Changed += OnChanged;

        var input = string.Empty;

        ConsoleMenu.PresentConsoleMenu();

        while (true)
        {
            Console.WriteLine(ConsoleMenu.MainMenu);

            input = Console.ReadKey().KeyChar.ToString();

            if (ConsoleMenuValidator.IsUserInputNullOrEmpty(input))
            {
                Console.WriteLine(ConsoleMenu.InputMessagesDict[ConsoleMenu.InputMessages.InputIsNullOrEmtpy]);                
            }
            else if (!ConsoleMenuValidator.IsUserInputOptionValid(input))
            {
                Console.WriteLine(ConsoleMenu.InputMessagesDict[ConsoleMenu.InputMessages.InputIsNotAValidOption]);
            }
            else
            {
                ConsoleMenu.PresentSubMenu(input);
            }
        }
    }
} catch (Exception ex)
{
    throw new Exception(ex.Message);
}
