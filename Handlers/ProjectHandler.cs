using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Handlers
{
    internal class ProjectHandler
    {
        public ProjectCollection ProjectCollection {  get; private set; }

        public Project Project { get; private set; }

        public ProjectHandler(string pathToProject)
        {
            ProjectCollection = new ProjectCollection();
            Project = GetProject(pathToProject);
        }

        private Project GetProject(string pathToProject)
        {
            var project = new Project(
                ProjectRootElement.Open(pathToProject),
                globalProperties: null,
                toolsVersion: null,
                ProjectCollection,
                loadSettings: ProjectLoadSettings.DoNotEvaluateElementsWithFalseCondition);

            return project;
        }
    }
}
