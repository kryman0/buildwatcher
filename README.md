# Introduction

Build Watcher enables the developer to recompile C# classes without the need to restart the debugger session. If the class uses dependencies outside its folder it's most likely it will not work. The application is made for C# projects for .NET Framework (4.X) and .NET 8. 

# Technologies

The application is built in C# targeting specific frameworks, .NET 4.X and .NET 8.

# Setup

The program accepts three mandatory arguments:

1. The full path to the project, e.g. `-proj:C:\source\MyProject\MyProject.csproj`. 
2. The path to the class or where the class resides, e.g. `-watch:C:\source\MyProject\SomeFolder\MyClass.cs` or `-watch:C:\source\MyProject\SomeFolder`.
3. The path to the MSBuild binary, e.g. if using Visual Studio 2022 Community edition, `-msbuild:'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin'`. Pay attention if using .NET 8 that it could reside as a library in, e.g. *C:\Program Files\dotnet\sdk\8.0.203*.

To run the application and to target a specific .NET version, run `dotnet run -f net481 -proj... -watch... -msbuild...`. This will listen to changes on a .NET Framework application given the arguments passed in.