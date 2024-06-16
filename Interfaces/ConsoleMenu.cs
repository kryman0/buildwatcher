using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Menus
{
    internal class ConsoleMenu : IMenu
    {
        private void SetMenu()
        {
            MenuText = new StringBuilder();
            MenuText.AppendLine("Choose an option:");
            MenuText.AppendLine("1. Enter absoulute path to project.");
            MenuText.AppendLine("2. Enter absoulute path to watch.");
            MenuText.AppendLine("3. Enter absoulute path to MSBuild.");
        }
        public string Menu => "Console";

        public StringBuilder MenuText { get; set; }

        public ConsoleMenu() 
        {
            SetMenu();
        }
    }
}
