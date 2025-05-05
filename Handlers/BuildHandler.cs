using Microsoft.Build.Execution;

namespace BuildWatcher.Handlers
{
    internal static class BuildHandler
    {

        public static void Build(string pathToProject, string[]? defaultTargetsToBuild = null)
        {
            if (defaultTargetsToBuild == null)
            {
                defaultTargetsToBuild = ["Build"];
            }

            var projHandler = new ProjectHandler(pathToProject);

            var isProjectBuilt = projHandler.Project.Build();
            
            if (!isProjectBuilt)
            {
                using (var bm = new BuildManager())
                {
                    var bmparams = new BuildParameters(projHandler.ProjectCollection);

                    var projInstance = bm.GetProjectInstanceForBuild(projHandler.Project);

                    var bmreqdata = new BuildRequestData(projInstance, defaultTargetsToBuild);
                    
                    bm.BeginBuild(bmparams);
                    
                    var bmres = bm.BuildRequest(bmreqdata);
                    
                    bm.EndBuild();
                }
            }
        }
    }
}
