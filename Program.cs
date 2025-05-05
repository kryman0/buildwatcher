using BuildWatcher;
using BuildWatcher.Handlers;
using BuildWatcher.Interfaces;
using Microsoft.Build.Locator;

ITargetDotNetVersionFactory dotNetVersion;

CommandLineArgs.Validate();

dotNetVersion = TargetDotNetVersionFactory.TargetDotNetVersion(CommandLineArgs.PathToMSBuild);

MSBuildLocator.RegisterMSBuildPath(dotNetVersion.PathToMSBuild);

UseFsWatcher(true);

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

        Console.WriteLine("Press Enter to exit\n");
    }        
}

void UseFsWatcher(bool useCLI)
{
    try
    {
        using (var fsWatcher = new FileSystemWatcher(CommandLineArgs.PathToWatch))
        {
            fsWatcher.EnableRaisingEvents = true;
            fsWatcher.IncludeSubdirectories = true;
            fsWatcher.NotifyFilter = NotifyFilters.LastWrite;

            Console.WriteLine("Waiting for changes...");

            fsWatcher.Changed += OnChanged;

            Console.WriteLine("Press Enter to exit\n");

            Console.ReadLine();
        }
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
}
