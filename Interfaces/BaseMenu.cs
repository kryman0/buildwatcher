using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class BaseMenu
    {
        public static string PathToProj { get; set; } = "none";
        public static string PathToWatch { get; set; } = "none";
        public static string PathToMSBuild { get; set; } = "none";

        //public BaseMenu(string pathToProj, string pathToWatch, string pathToMSBuild)
        //{
        //    PathToProj = pathToProj;
        //    PathToWatch = pathToWatch;
        //    PathToMSBuild = pathToMSBuild;
        //}
    }
}
