using BuildWatcher.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal static class ConsoleMenu
    {
        private const int _optionProject = 1;
        private const int _optionWatch = 2;
        private const int _optionMSBuild = 3;

        private readonly static string _presentMenuOptions = 
            "Choose an option:" + Environment.NewLine +
            _configureProject + Environment.NewLine +
            _configureWatch + Environment.NewLine +
            _configureMSBuild + Environment.NewLine;

        private const string _configureProject = "1. Configure Project"; // add clargs and modify/remove below
        private const string _configureWatch = "2. Configure Folder";
        private const string _configureMSBuild = "3. Configure MSBuild";

        private static void PresentMenu()
        {
            Console.WriteLine(_presentMenuOptions);
            
            GetMenuByInputOption();
        }

        private static void GetMenuByInputOption(string? pathToProj = null, string? pathToWatch = null, string? pathToMSBuild = null)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result)) {
                switch (result)
                {
                    case _optionProject:
                        MenuProject(pathToProj ?? "none");
                        break;
                    case _optionWatch:
                        //
                        break;
                    case _optionMSBuild:
                        //
                        break;
                    default:
                        throw new ConsoleMenuException("That's not an option!");
                }
            }            
        }

        private static void MenuProject(string pathToProj)
        {
            Console.WriteLine($"1. Enter absoulute path to project. (Current: {pathToProj})");
            
            var input = Console.ReadLine();
        }
                
        //public ConsoleMenu() 
        //{
        //    PresentMenu();
        //}
    }
}
