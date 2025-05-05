namespace BuildWatcher
{
    public static class TargetDotNetVersionFactory
    {
        public static ITargetDotNetVersionFactory TargetDotNetVersion(string pathToMSBuild)
        {
#if NETFRAMEWORK
            return new DotNetFramework481(pathToMSBuild);
#elif NET8_0_OR_GREATER
            return new DotNet8(pathToMSBuild);
#endif
        }
    }
}
