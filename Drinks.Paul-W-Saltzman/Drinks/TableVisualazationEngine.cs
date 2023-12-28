using static drinks_info.GlobalVariables;
using drinks_info.Models;
namespace drinks_info
{
    internal class TableVisualisationEngine
    {
        internal static void ShowDrinkTabOne(DrinkDetail drinkDetail)
        {
            string iba = "";
            string tags = "";

            if (drinkDetail.strIBA != null)
            {
                iba = drinkDetail.strIBA.ToString();
            }
            if (drinkDetail.strTags != null)
            {
                tags = drinkDetail.strTags.ToString();
            }
            int tabSizeRows = 8;
            int tabSizeCol = 61;
            int currentTabSize = 0;
            bool addToTab = true;
            string star = $"{green}*";
            string starReset = $"{green}*{resetColor}";
            int starSpaces = (green.Length*2) + resetColor.Length; 

            bool inFavorites = Favorite.InFavorites(drinkDetail.idDrink);

            string topLine = $"{new string(' ', 4)}|{new string(' ', 5)}".PadRight(tabSizeCol, '-');
            string blankLine = $"{new string(' ', 4)}|".PadRight(tabSizeCol, ' ') + "|";
            string drinkIdLine = $"{new string(' ', 4)}|{new string(' ', 5)}ID: {drinkDetail.idDrink}".PadRight(tabSizeCol, ' ') + "|";
            string drinkNameLine = $"{new string(' ', 4)}|{new string(' ', 5)}Drink: {drinkDetail.strDrink}".PadRight(tabSizeCol, ' ') + "|";
            string drinkNameLineFavorite = $"{new string(' ', 4)}|{new string(' ', 5)}{starReset}Drink: {drinkDetail.strDrink}{star}".PadRight(tabSizeCol, ' ') + new string(' ', starSpaces) + "|";
            string bottomLine = $"{new string(' ', 4)}".PadRight(tabSizeCol, '-');

            Console.Write($"{green}");
            Console.WriteLine(topLine); currentTabSize++;
            Console.WriteLine(blankLine); currentTabSize++;
            Console.WriteLine(drinkIdLine); currentTabSize++;
            if(inFavorites)
            {
            Console.WriteLine(drinkNameLineFavorite);
            }
            else
            {
            Console.WriteLine(drinkNameLine); currentTabSize++;
            }

            while (addToTab)
            {
                if (currentTabSize < tabSizeRows)
                {
                    Console.WriteLine(blankLine); currentTabSize++;
                }
                else
                {
                    addToTab = false;
                }
            }
            Console.WriteLine(bottomLine);
            Console.WriteLine($"{resetColor}");
        }

        internal static void ShowDrinkTabTwo(DrinkDetail drinkDetail)
        {
            string iba = "";
            string tags = "";

            if (drinkDetail.strIBA != null)
            {
                iba = drinkDetail.strIBA.ToString();
            }
            if (drinkDetail.strTags != null)
            {
                tags = drinkDetail.strTags.ToString();
            }
            int tabSizeRows = 8;
            int tabSizeCol = 61;
            int currentTabSize = 0;
            bool addToTab = true;


            string topLine = $"{new string(' ', 4)}{new string('-', 10)}{new string(' ',11)}".PadRight(tabSizeCol, '-');
            string blankLine = $"{new string(' ', 4)}|".PadRight(tabSizeCol, ' ') + "|";
            string drinkIdLine = $"{new string(' ', 4)}|{new string(' ', 5)}ID: {drinkDetail.idDrink}".PadRight(tabSizeCol, ' ') + "|";
            string drinkNameLine = $"{new string(' ', 4)}|{new string(' ', 5)}Drink: {drinkDetail.strDrink}".PadRight(tabSizeCol, ' ') + "|";
            string bottomLine = $"{new string(' ', 4)}".PadRight(tabSizeCol, '-');
            string tagsLine = $"{new string(' ', 4)}|{new string(' ', 5)}Tags: {tags}".PadRight(tabSizeCol, ' ') + "|";
            string ibaLine = $"{new string(' ', 4)}|{new string(' ', 5)}IBA: {iba}".PadRight(tabSizeCol, ' ') + '|';
            string glassLine = $"{new string(' ', 4)}|{new string(' ', 5)}Glass: {drinkDetail.strGlass}".PadRight(tabSizeCol, ' ') + '|';
            string categoryLine = $"{new string(' ', 4)}|{new string(' ', 5)}Category: {drinkDetail.strCategory}".PadRight(tabSizeCol, ' ') + "|";
            string alchoholicLine = $"{new string(' ', 4)}|{new string(' ', 5)}Alcohol Content: {drinkDetail.strAlcoholic}".PadRight(tabSizeCol, ' ') + "|";


            Console.Write($"{green}");
            Console.WriteLine(topLine); currentTabSize++;
            Console.WriteLine(blankLine); currentTabSize++;
            if (drinkDetail.idDrink != null) {Console.WriteLine(drinkIdLine); currentTabSize++; }
            if (drinkDetail.strDrink != null) { Console.WriteLine(drinkNameLine); currentTabSize++; }
            if (drinkDetail.strCategory != null) {Console.WriteLine(categoryLine); currentTabSize++; }
            if (drinkDetail.strAlcoholic != null) { Console.WriteLine(alchoholicLine); currentTabSize++; }
            if (drinkDetail.strIBA != null) { Console.WriteLine(ibaLine); currentTabSize++; }
            if (drinkDetail.strTags != null) { Console.WriteLine(tagsLine); currentTabSize++; }
            if (drinkDetail.strGlass != null) { Console.WriteLine(glassLine); currentTabSize++; }
            while (addToTab)
            {
                if (currentTabSize < tabSizeRows)
                {
                    Console.WriteLine(blankLine); currentTabSize++;
                }
                else 
                {
                    addToTab = false;
                }
            }
            Console.WriteLine(bottomLine);
            Console.WriteLine($"{resetColor}");
        }

        internal static void ShowDrinkTabThree(DrinkDetail drinkDetail)
        {
            string iba = "";
            string tags = "";

            if (drinkDetail.strIBA != null)
            {
                iba = drinkDetail.strIBA.ToString();
            }
            if (drinkDetail.strTags != null)
            {
                tags = drinkDetail.strTags.ToString();
            }
            int tabSizeRows = 8;
            int tabSizeCol = 61;
            int currentTabSize = 0;
            bool addToTab = true;
            Settings settings = Data.GetSettings();
            string instructions = string.Empty;
            switch (settings.Language)
            {
                case Settings.LanguageEnum.EN:
                    instructions = drinkDetail.strInstructions;
                    break;
                case Settings.LanguageEnum.FR:
                    if (drinkDetail.strInstructionsFR != null)
                    {
                        instructions = drinkDetail.strInstructionsFR.ToString();
                    }
                    else
                    {
                        instructions = "There is no French translation for this recipe." + drinkDetail.strInstructions;
                    }
                    break;
                case Settings.LanguageEnum.DE:
                    if (drinkDetail.strInstructionsDE != null)
                    {
                        instructions = drinkDetail.strInstructionsDE.ToString();
                    }
                    else
                    {
                        instructions = "There is no German translation for this recipe." + drinkDetail.strInstructions;
                    }
                    break;
                case Settings.LanguageEnum.IT:
                    if (drinkDetail.strInstructionsDE != null)
                    {
                        instructions = drinkDetail.strInstructionsIT.ToString();
                    }
                    else
                    {
                        instructions = "There is no Italian translation for this recipe." + drinkDetail.strInstructions;
                    }
                    break;
                default:
                    instructions = drinkDetail.strInstructions;
                    break;
            }
            List<string> lines = Helpers.stringBreaker(instructions, tabSizeCol - 5);

            string topLine = $"{new string(' ', 4)}{new string('-', 26)}{new string(' ', 13)}".PadRight(tabSizeCol, '-');
            string blankLine = $"{new string(' ', 4)}|".PadRight(tabSizeCol, ' ') + "|";
            string bottomLine = $"{new string(' ', 4)}".PadRight(tabSizeCol, '-');

            Console.Write($"{green}");
            Console.WriteLine(topLine); currentTabSize++;
            Console.WriteLine(blankLine); currentTabSize++;
            foreach (string line in lines)
            {
                Console.WriteLine($"{new string(' ', 4)}|{line}".PadRight(tabSizeCol, ' ') + "|");
                currentTabSize++;
            }
            while (addToTab)
            {
                if (currentTabSize < tabSizeRows)
                {
                    Console.WriteLine(blankLine); currentTabSize++;
                }
                else
                {
                    addToTab = false;
                }
            }
            Console.WriteLine(bottomLine);
            Console.WriteLine($"{resetColor}");
        }


        internal static void ShowDrinkTabFour(DrinkDetail drinkDetail)
        {
            string iba = "";
            string tags = "";

            if (drinkDetail.strIBA != null)
            {
                iba = drinkDetail.strIBA.ToString();
            }
            if (drinkDetail.strTags != null)
            {
                tags = drinkDetail.strTags.ToString();
            }
            int tabSizeRows = 8;
            int tabSizeCol = 61;
            int currentTabSize = 0;
            bool addToTab = true;

            List<Tuple<string, string>> ingredients = Helpers.getIngrediantlist(drinkDetail);

            string topLine = $"{new string(' ', 4)}{new string('-', 45)}".PadRight(tabSizeCol, ' ')+'|';
            string blankLine = $"{new string(' ', 4)}|".PadRight(tabSizeCol, ' ') + "|";
            string bottomLine = $"{new string(' ', 4)}".PadRight(tabSizeCol, '-');


            Console.Write($"{green}");
            Console.WriteLine(topLine); currentTabSize++;
            Console.WriteLine(blankLine); currentTabSize++;

            foreach(var(ingredient, measurement) in ingredients)
            {
                Console.WriteLine($"{new string(' ', 4)}|{new string(' ', 5)}{ingredient}: {measurement}".PadRight(tabSizeCol,' ')+'|'); currentTabSize++;
            }

            while (addToTab)
            {
                if (currentTabSize < tabSizeRows)
                {
                    Console.WriteLine(blankLine); currentTabSize++;
                }
                else
                {
                    addToTab = false;
                }
            }
            Console.WriteLine(bottomLine);
            Console.WriteLine($"{resetColor}");
        }
    }
}
