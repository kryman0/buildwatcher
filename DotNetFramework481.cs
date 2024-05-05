using System;
using System.Diagnostics;

namespace BuildWatcher;

public class DotNetFramework481 : ITargetDotNetVersionFactory
{
    //private string _pathToMSBuild;
    public string PathToMSBuild { get; private set; }

    //public ITargetDotNetVersionFactory TargetDotNetVersion(string pathToMSBuild)
    //{
    //    return this;
    //}

    public DotNetFramework481(string pathToMSBuild)
    {
        PathToMSBuild = pathToMSBuild;
    }

    public void Hi()
    {
        Console.WriteLine("from DotNetFrameWork481");
        //pathToWatch = Path.GetFullPath("D:\\source\\WebFormsTest2\\WebFormsTest2\\");
        //pathToProj = pathToWatch + "WebFormsTest2.csproj";
        //pathToMSBuild = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\";
        //pathToMSBuild = ToolLocationHelper.GetPathToBuildTools("11.0");
    }
}