using Spectre.Console;

namespace Inputs;

    public static class UserInput
    {    
        public static string GetCategoryName()
        {
            return AnsiConsole
            .Prompt(new TextPrompt<string>("Enter a category: "));
        }
    }