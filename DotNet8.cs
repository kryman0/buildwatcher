namespace BuildWatcher
{
    public class DotNet8 : ITargetDotNetVersionFactory
    {
        public string PathToMSBuild { get; private set; }

        public DotNet8(string pathToMSBuild)
        {
            PathToMSBuild = pathToMSBuild;
        }
    }
}
