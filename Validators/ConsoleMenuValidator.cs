using BuildWatcher.Exceptions;
using BuildWatcher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildWatcher.Validators
{
    internal static class ConsoleMenuValidator
    {
        private enum InputMessages
        {
            InputIsNullOrEmtpy = 1,
            InputIsNotAValidOption = 2,
        }

        private static Dictionary<InputMessages, string> InputMessagesDict => new()
        {
            { InputMessages.InputIsNullOrEmtpy, "Input was empty. Try again." + _newLineChooseOption },
            { InputMessages.InputIsNotAValidOption, "That's not an option! Try again." + _newLineChooseOption }
        };

        private static readonly string _newLineChooseOption = Environment.NewLine + "Choose: ";

        private static bool IsUserInputOptionValid(string inputOption)
        {
            if (int.TryParse(inputOption, out int result))
            {                
                return ConsoleMenu.ValidOptions.Contains(result);
            }

            return false;
        }       
        
        private static bool IsPathToProjExtensionCorrect(string inputPathToProj)
        {
            if (ProjectValidator.ValidatePath(inputPathToProj))
            {
                return true;
            }
            
            return false;
        }

        private static bool IsUserInputNullOrEmpty(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return false;
        }

        public static void Validate(string input, string? pathToProj, string? pathToWatch, string? pathToMSBuild)
        {


            if (!string.IsNullOrEmpty(pathToProj))
            {
                IsPathToProjExtensionCorrect(pathToProj);
            }
        }
    }
}
