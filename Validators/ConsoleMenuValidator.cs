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
        public static bool IsPathToProjExtensionCorrect(string inputPathToProj)
        {
            if (ProjectValidator.ValidatePath(inputPathToProj))
            {
                return true;
            }
            
            return false;
        }

        public static bool IsUserInputNullOrEmpty(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return false;
        }
    }
}
