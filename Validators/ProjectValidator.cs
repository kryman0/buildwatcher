using System.IO;

namespace BuildWatcher.Validators
{
    internal static class ProjectValidator
    {
        private const string _projExt = ".csproj";

        public static bool Validate(string pathToProj)
        {
            if (!Path.HasExtension(pathToProj) && Path.GetExtension(pathToProj).ToLower() != _projExt)
            {
                return false;
            }

            return true;
        }
    }
}
