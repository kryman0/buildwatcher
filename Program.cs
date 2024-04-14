using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Locator;

namespace BuildWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToWatch; 
            string pathToProj;
            string pathToMSBuild;

#if NETFRAMEWORK
            pathToWatch = Path.GetFullPath("D:\\source\\WebFormsTest2\\WebFormsTest2\\");
            pathToProj = pathToWatch + "WebFormsTest2.csproj";
            pathToMSBuild = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\";
#elif NET8_0_OR_GREATER
            pathToWatch = Path.GetFullPath("D:\\source\\ConsoleAppTest\\ConsoleAppTest\\");            
            pathToProj = pathToWatch + "ConsoleAppTest.csproj";
            pathToMSBuild = "C:\\Program Files\\dotnet\\sdk\\8.0.203\\";
#endif

            MSBuildLocator.RegisterMSBuildPath(pathToMSBuild);
            Build(pathToProj);
            //var vs = MSBuildLocator.QueryVisualStudioInstances().OrderByDescending(v => v.Version).FirstOrDefault();

            //RegisterVSInstance();

            //try
            //{
            //    using (var fsWatcher = new FileSystemWatcher(pathToWatch))
            //    {
            //        fsWatcher.EnableRaisingEvents = true;
            //        fsWatcher.IncludeSubdirectories = true;
            //        //fsWatcher.NotifyFilter -- add all kinds of changes
            //        Console.WriteLine("Waiting for changes...");
            //        //var waitForChangedResult = fsWatcher.WaitForChanged(WatcherChangeTypes.All);
            //        fsWatcher.Changed += OnChanged;
            //        Console.WriteLine("Type Enter to exit");
            //        Console.ReadLine();
            //    }
            //} catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}            
        }

        static void Build(string pathToProject)
        {
            using (var bm = new BuildManager("WebFormsTest2"))
            {
                var projColl = new ProjectCollection();

                //var project = projColl.LoadProject(pathToProj);

                var projRootEl = ProjectRootElement.Open(pathToProject);
                var netVersion = projRootEl.Properties.Where(p => p.ElementName.ToString() == "TargetFrameworkVersion").FirstOrDefault();
                var imports = projRootEl.Imports.Select(i => i.ProjectLocation);

                var webForms2Proj = new Project(
                    projRootEl,
                    globalProperties: null,
                    toolsVersion: null,
                    projColl,
                    loadSettings: ProjectLoadSettings.DoNotEvaluateElementsWithFalseCondition);

                var bmparams = new BuildParameters(projColl);

                ////var webForms2Proj = new Project(projRootEl, null, projColl.DefaultToolsVersion, null, projColl, loadSettings: ProjectLoadSettings.Default);

                var projInstance = bm.GetProjectInstanceForBuild(webForms2Proj);

                var bmreqdata = new BuildRequestData(projInstance, [ "Build" ]);
                bm.BeginBuild(bmparams);
                var bmres = bm.BuildRequest(bmreqdata);
                Console.WriteLine(bmres.OverallResult);
                //Console.ReadLine();
                bm.EndBuild();
            }
        }
        //static VisualStudioInstance? RegisterVSInstance(string version, ProjectRootElement p = null)
        //{

        //    //switch (version)
        //    //{
        //    //    case "v4.8.1":

        //    //}

        //    var vs = MSBuildLocator.QueryVisualStudioInstances().OrderByDescending(v => v.Version).FirstOrDefault();
        //    MSBuildLocator.RegisterInstance(vs);

        //    return vs;
        //}

        //private static void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    if (e.ChangeType == WatcherChangeTypes.Changed)
        //    {
        //        Console.WriteLine(
        //        $"File or Directory changed: {e.Name}\n" +
        //        $"Location of the change: {e.FullPath}\n" +
        //        $"ChangeType: {e.ChangeType}"
        //        );
        //    }
        //    Console.WriteLine("Type Enter to exit");
        //}
    }
}