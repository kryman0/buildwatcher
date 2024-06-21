using BuildWatcher.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Interfaces
{
    internal class ConsoleMenu : BaseMenu, IMenu
    {
        private const int _optionProject = 1;
        private const int _optionWatch = 2;
        private const int _optionMSBuild = 3;

        private string _presentMenuOptions => new StringBuilder(
            "Choose an option:" + Environment.NewLine +
            _configureProject + Environment.NewLine +
            _configureWatch + Environment.NewLine +
            _configureMSBuild + Environment.NewLine
        ).ToString();

        private string _configureProject => "1. Configure Project";
        private string _configureWatch => "2. Configure Folder(s) to watch";
        private string _configureMSBuild => "3. Configure MSBuild";

        private void PresentMenu()
        {
            Console.WriteLine(_presentMenuOptions);
            
            var input = Console.ReadLine();
            
            GetMenuByInputOption(input);
        }

        private void GetMenuByInputOption(string? option)
        {            
            if (int.TryParse(option, out int result)) {
                switch (result)
                {
                    case _optionProject:
                        MenuProject();
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

        private void MenuProject()
        {
            //MenuText.AppendLine("1. Enter absoulute path to project.");
            
        }

        public string Menu => "Console";

        public StringBuilder MenuText => new StringBuilder();

        //public ConsoleMenu() 
        //{
        //    PresentMenu();
        //}
    }
}
