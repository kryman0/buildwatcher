using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class BaseMenu
    {
        public static string PathToProj { get; set; } = string.Empty;
        public static string PathToWatch { get; set; } = string.Empty;
        public static string PathToMSBuild { get; set; } = string.Empty;

        //public BaseMenu(string pathToProj, string pathToWatch, string pathToMSBuild)
        //{
        //    PathToProj = pathToProj;
        //    PathToWatch = pathToWatch;
        //    PathToMSBuild = pathToMSBuild;
        //}
    }
}
