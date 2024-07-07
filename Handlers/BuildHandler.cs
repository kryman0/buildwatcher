using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
