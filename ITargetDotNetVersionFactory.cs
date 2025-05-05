namespace BuildWatcher
{
    public interface ITargetDotNetVersionFactory
    {
        public string PathToMSBuild { get; }
    }
}
