using BuildWatcher.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Validators
{
    internal static class ProjectValidator
    {
        public static void ValidateProjExtension(string pathToProj)
        {
            if (!pathToProj.EndsWith(".csproj"))
            {
                throw new MissingProjectException("Path to project is not ending with .csproj");
            }
        }
    }
}
