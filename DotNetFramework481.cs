namespace BuildWatcher;

public class DotNetFramework481 : ITargetDotNetVersionFactory
{
    public string PathToMSBuild { get; private set; }

    public DotNetFramework481(string pathToMSBuild)
    {
        PathToMSBuild = pathToMSBuild;
    }
}