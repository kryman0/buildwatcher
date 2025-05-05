namespace BuildWatcher.Validators
{
    internal static class ConsoleMenuValidator
    {
        public static bool IsPathToProjExtensionCorrect(string inputPathToProj)
        {
            if (ProjectValidator.Validate(inputPathToProj))
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
