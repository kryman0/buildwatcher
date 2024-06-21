using BuildWatcher;
using BuildWatcher.Handlers;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Locator;

//pathToMSBuild = "C:\\Program Files\\dotnet\\sdk\\8.0.203\\";
//var clArgs = new CommandLineArgs();

CommandLineArgs.Validate();

var dotNetVersion = TargetDotNetVersionFactory.TargetDotNetVersion(CommandLineArgs.PathToMSBuild);

MSBuildLocator.RegisterMSBuildPath(dotNetVersion.PathToMSBuild);


void OnChanged(object sender, FileSystemEventArgs e)
{
    if (e.ChangeType == WatcherChangeTypes.Changed && e.FullPath.Contains(".cs"))
    {        
        BuildHandler.Build(CommandLineArgs.PathToProj, null);

        Console.WriteLine(
            $"File or Directory changed: {e.Name}\n" +
            $"Location of the change: {e.FullPath}\n" +
            $"ChangeType: {e.ChangeType}\n");

        Console.WriteLine("Press Enter to exit:\n");
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
        
        Console.WriteLine("Press Enter to exit:\n");
        
        Console.ReadLine();
    }
} catch (Exception ex)
{
    throw new Exception(ex.Message);
}
