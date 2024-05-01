using System;

namespace BuildWatcher;

public class DotNetFrameWork481 : ITargetDotNetVersionFactory
{
    public ITargetDotNetVersionFactory GetDotNetVersion()
    {
        return this;
    }

    public void Hi()
    {
        //pathToWatch = Path.GetFullPath("D:\\source\\WebFormsTest2\\WebFormsTest2\\");
        //pathToProj = pathToWatch + "WebFormsTest2.csproj";
        //pathToMSBuild = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\";
        //pathToMSBuild = ToolLocationHelper.GetPathToBuildTools("11.0");
    }
}