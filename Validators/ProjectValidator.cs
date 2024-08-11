namespace BuildWatcher.Validators
{
    internal static class ProjectValidator
    {
        private const string _projExt = ".csproj";

        public static bool ValidatePath(string pathToProj)
        {
            if (pathToProj.EndsWith(_projExt))
            {
                return true;
            }

            return false;
        }
    }
}
