using static drinks_info.GlobalVariables;
using drinks_info.Models;

namespace drinks_info
{
    internal class Menu
    {
        internal static void MainMenu()
        {
            string pageText = "Welcome to Drinks: a cocktail reference program";
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            bool exitMenu = false;
            (int left, int top) = Console.GetCursorPosition();
            string color = $"{checkMark}{green}   ";

            List<Category> categories = DrinksService.GetCategoriesListAsync().GetAwaiter().GetResult();

            Console.CursorVisible = false;
            while (!exitMenu)
            {
                while (!isSelected)
                {
                    OpenMenu(pageText,1);

                    Console.WriteLine($@"{(option == 1 ? color : "    ")}EXIT    {resetColor}");
                    Console.WriteLine($@"{(option == 2 ? color : "    ")}  My Ingredients{resetColor}");
                    Console.WriteLine($@"{(option == 3 ? color : "    ")}  My Favorites{resetColor}");
                    Console.WriteLine($@"{(option == 4 ? color : "    ")}  Ingredients{resetColor}");
                    Console.WriteLine($@"{(option == 5 ? color : "    ")}  Categories{resetColor}");
                    Console.WriteLine($@"{(option == 6 ? color : "    ")}  Random Cocktail {resetColor}");
                    Console.WriteLine($@"{(option == 7 ? color : "    ")}  Settings {resetColor}");


                    key = Console.ReadKey(true);



                    switch (key.Key)

                    {
                        case ConsoleKey.DownArrow:
                            option = option == 7 ? 1 : option + 1;
                            break;

                        case ConsoleKey.UpArrow:
                            option = option == 1 ? 7 : option - 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                switch (option)
                {
                    case 1://Exit
                        exitMenu = true;
                        isSelected = true;
                        break;
                    case 2://Ingredients
                        inventoryMenu();
                        isSelected = false;
                        break;
                    case 3://Favorites
                        FavoriteDrinksMenu();
                        isSelected = false;
                        break;
                    case 4://Ingredients
                        IngredientsMenu();
                        isSelected = false;
                        break;
                    case 5://Categories
                        CategoriesMenu(categories);
                        isSelected = false;
                        break;
                    case 6://Random Cocktail
                        DrinksService.GetDrinkRandom();
                        isSelected = false;
                        break;
                    case 7://Settings
                        SettingsMenu();
                        isSelected = false;
                        break;
                }

            }
            Console.Clear();
            Console.WriteLine($@"Goodbye");
            Console.ReadLine();

        }

        private static void inventoryMenu()
        {
            Console.Clear();
            string pageText = "Inventory";

            bool searchByMultipleIngredients = false;
            string multiSelected = string.Empty;
            List<string> multipleIngrediants = new List<string>();

            ConsoleKeyInfo key;
            int option = 1;
            bool exitMenu = false;
            bool isSelected = false;
            while (!exitMenu)
            {
                while (!isSelected)
                {

                    string color = $"{checkMark}{green}   ";
                    string star = $"{green}*{resetColor}";

                    List<Inventory> inventory = Data.GetInventory();
                    int numberOfItems = inventory.Count;
                    int itemsPerPage = 13;
                    int totalPages = (int)Math.Ceiling((double)numberOfItems / itemsPerPage);
                    int currentPage = 1;
                    int index = 1;
            
                    OpenMenu(pageText, 5);

                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");
                    index++;

                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(currentPage * itemsPerPage, numberOfItems);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {inventory[i].InventoryName}{resetColor}");
                        index++;
                    }

                    Console.WriteLine($"Page {currentPage} of {totalPages}");
                    if (searchByMultipleIngredients == true)
                    {
                        Console.WriteLine($@"Press{green} A {resetColor}to add ingredients to the search, or{green} C {resetColor}to clear your search list. Then press{green} Enter {resetColor}to search");
                        foreach (string ingrediant in multipleIngrediants)
                        {
                            Console.Write($@"{ingrediant}, ");
                        }

                    }

                    index = 1;

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option == ((numberOfItems + 1) - (itemsPerPage * (currentPage - 1))) && currentPage == totalPages)
                            {
                                option = 1;
                                currentPage = 1;
                            }
                            else
                            {
                                if (option == itemsPerPage + 1)
                                {
                                    option = 1;
                                    if (currentPage < totalPages)
                                    {
                                        currentPage++;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option++;
                                };
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (option == 1 && currentPage == 1)
                            {
                                option = (numberOfItems + 1) - (itemsPerPage * (totalPages - 1));
                                currentPage = totalPages;
                            }
                            else
                            {
                                if (option == 1)
                                {
                                    option = itemsPerPage + 1;
                                    if (currentPage > 1)
                                    {
                                        currentPage--;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option--;
                                }
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentPage > 1)
                            {
                                currentPage--;
                                index = 1;
                            }
                            else
                            {
                                currentPage = totalPages;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentPage < totalPages)
                            {
                                currentPage++;
                                index = 1;
                            }
                            else
                            {
                                currentPage = 1;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.M:
                            {
                                
                                if (searchByMultipleIngredients == false)
                                {
                                    searchByMultipleIngredients = true;
                                }
                                else
                                {
                                    searchByMultipleIngredients = false;
                                }

                                isSelected = false;
                                exitMenu = false;
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                Inventory selectedInventory = inventory[option - 2 + ((currentPage - 1) * itemsPerPage)];
                                Ingredient selectedIngredient = new Ingredient { strIngredient1 = selectedInventory.InventoryName };
                                Data.toggleIngredientInInventory(selectedIngredient);
                                isSelected = false;
                                exitMenu = false;
                            }
                            break;
                        case ConsoleKey.C:
                            multipleIngrediants.Clear();
                            isSelected = false;
                            exitMenu = false;
                            break;
                        case ConsoleKey.A:
                            {
                                if (searchByMultipleIngredients)
                                {
                                    multiSelected = inventory[option - 2 + ((currentPage - 1) * itemsPerPage)].InventoryName;
                                    multiSelected = Helpers.CleanString(multiSelected);
                                    multipleIngrediants.Add(multiSelected);
                                    isSelected = false;
                                    exitMenu = false;
                                }
                                else
                                { break; }
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (option == 1)
                            {
                                exitMenu = true;
                                isSelected = true;
                                break;
                            }
                            else if (searchByMultipleIngredients)
                            {
                                int ingredientCount = multipleIngrediants.Count;
                                Dictionary<Drink, int> drinkInfoDict = Helpers.MultiSearch(multipleIngrediants);
                                multiSearchResult(ingredientCount, drinkInfoDict);

                            }
                            else
                            {
                                Inventory selectedInventory = inventory[option - 2 + ((currentPage - 1) * itemsPerPage)];
                                Console.Clear();
                                Ingredient selectedIngredient = new Ingredient { strIngredient1 = selectedInventory.InventoryName };
                                List<Drink> drinks = DrinksService.GetDrinkListByIngredient(selectedIngredient);
                                FilteredDrinksMenu(drinks);

                                isSelected = false;
                            }
                            break;
                    }
                }
            }
        }

        private static void multiSearchResult(int ingredientCount, Dictionary<Drink, int> drinkInfoDict)
        {
            string pageText = $"You searched {green}{ingredientCount}{resetColor} ingredients. How many ingredients would you like your results to match on?";
            Console.Clear();

            ConsoleKeyInfo key;
            int option = 1;
            bool exitMenu = false;
            bool isSelected = false;
            while (!exitMenu)
            {
                while (!isSelected)
                {

                    string color = $"{checkMark}{green}   ";
                    string star = $"{green}*{resetColor}";

                    int itemsPerPage = 13;
                    int totalPages = (int)Math.Ceiling((double)ingredientCount / itemsPerPage);
                    int currentPage = 1;
                    int index = 1;

                    OpenMenu(pageText, 1);

                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");
                    index++;

                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(currentPage * itemsPerPage, ingredientCount);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {i+1}{resetColor}");
                        index++;
                    }

                    Console.WriteLine($"Page {currentPage} of {totalPages}");

                    index = 1;

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option == ((ingredientCount + 1) - (itemsPerPage * (currentPage - 1))) && currentPage == totalPages)
                            {
                                option = 1;
                                currentPage = 1;
                            }
                            else
                            {
                                if (option == itemsPerPage + 1)
                                {
                                    option = 1;
                                    if (currentPage < totalPages)
                                    {
                                        currentPage++;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option++;
                                };
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (option == 1 && currentPage == 1)
                            {
                                option = (ingredientCount + 1) - (itemsPerPage * (totalPages - 1));
                                currentPage = totalPages;
                            }
                            else
                            {
                                if (option == 1)
                                {
                                    option = itemsPerPage + 1;
                                    if (currentPage > 1)
                                    {
                                        currentPage--;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option--;
                                }
                                index = 1;
                                break;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (currentPage > 1)
                            {
                                currentPage--;
                                index = 1;
                            }
                            else
                            {
                                currentPage = totalPages;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentPage < totalPages)
                            {
                                currentPage++;
                                index = 1;
                            }
                            else
                            {
                                currentPage = 1;
                                index = 1;
                            }
                            break;
                            case ConsoleKey.Enter:
                            if (option == 1)
                            {
                                exitMenu = true;
                                isSelected = true;
                                break;
                            }
                            else
                            {
                                int matches = option - 1;
                                Dictionary<Drink, int> sortedDictionary = Helpers.SortDictionaryByTvalue(drinkInfoDict);
                                List<Drink> drinks = Helpers.DictionaryToList(matches, sortedDictionary);
                                if (drinks.Count > 0)
                                {
                                    FilteredDrinksMenu(drinks);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("There are no results based on your criteria.  Try Lowering your require matches");
                                    Console.ReadKey();
                                }
                            }
                            break;
                    }
                }
            }
        }

        private static void IngredientsMenu()
        {
            Console.Clear();
            string pageText = "Ingredients";

            ConsoleKeyInfo key;
            int option = 1;
            bool exitMenu = false;
            bool isSelected = false;

            bool searchByMultipleIngredients = false;
            string multiSelected = string.Empty;
            List <string> multipleIngrediants= new List<string>();


            string color = $"{checkMark}{green}   ";
            string star = $"{green}*{resetColor}";

            List<Ingredient> ingredients = DrinksService.GetIngredientsList();
            Ingredient selectedIngredient = new Ingredient();
            int numberOfItems = ingredients.Count;
            int itemsPerPage = 13;
            int totalPages = (int)Math.Ceiling((double)numberOfItems / itemsPerPage);
            int currentPage = 1;
            int index = 1;

            while (!exitMenu)
            {
                while (!isSelected)
                {
                    
                    OpenMenu(pageText, 2);
                    
                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");
                    index++;

                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(currentPage * itemsPerPage, numberOfItems);

                    

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        List<Inventory> inventory = Data.GetInventory();

                        string CleanIngredient = ingredients[i].strIngredient1.Replace(star, "");
                        CleanIngredient = CleanIngredient.Replace(green, "");

                        bool inInventory = Inventory.InInventory(CleanIngredient);
                        if (inInventory == true)
                        {
                            ingredients[i].strIngredient1 = Helpers.CleanString(ingredients[i].strIngredient1);
                            ingredients[i].strIngredient1 = star + ingredients[i].strIngredient1 + star;

                            if (option == index)
                            {
                                ingredients[i].strIngredient1 = Helpers.CleanString(ingredients[i].strIngredient1);
                                ingredients[i].strIngredient1 = star+green+ingredients[i].strIngredient1+star;
                            }
                        }
                        else
                        {
                            if (ingredients[i].strIngredient1.Contains(star))
                            {
                                ingredients[i].strIngredient1 = ingredients[i].strIngredient1.Replace(star, "");
                            }
                        }
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {ingredients[i].strIngredient1}{resetColor}");
                        index++;
                    }

                    Console.WriteLine($"Page {currentPage} of {totalPages}");

                    if (searchByMultipleIngredients == true)
                    {
                        Console.WriteLine($@"Press{green} A {resetColor}to add ingredients to the search, or{green} C {resetColor}to clear your search list. Then press{green} Enter {resetColor}to search");
                        foreach (string ingrediant in multipleIngrediants)
                        {
                            Console.Write($@"{ingrediant}, ");
                        }

                    }

                    index = 1; 

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option == ((numberOfItems + 1) - (itemsPerPage * (currentPage - 1))) && currentPage == totalPages)
                            {
                                option = 1;
                                currentPage = 1;
                            }
                            else
                            {
                                if (option == itemsPerPage + 1)
                                {
                                    option = 1;
                                    if (currentPage < totalPages)
                                    {
                                        currentPage++;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option++;
                                };
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (option == 1 && currentPage == 1)
                            {
                                option = (numberOfItems + 1) - (itemsPerPage * (totalPages - 1));
                                currentPage = totalPages;
                            }
                            else
                            {
                                if (option == 1)
                                {
                                    option = itemsPerPage + 1;
                                    if (currentPage > 1)
                                    {
                                        currentPage--;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option--;
                                }
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentPage > 1)
                            {
                                currentPage--;
                                index = 1; 
                            }
                            else
                            {
                                currentPage = totalPages;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentPage < totalPages)
                            {
                                currentPage++;
                                index = 1; 
                            }
                            else
                            {
                                currentPage = 1;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.M:
                            {
                                if (searchByMultipleIngredients == false)
                                { 
                                    searchByMultipleIngredients = true; 
                                }
                                else
                                { 
                                    searchByMultipleIngredients =  false; 
                                }

                                isSelected = false;
                                exitMenu = false;
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                selectedIngredient = ingredients[option - 2 + ((currentPage - 1) * itemsPerPage)];
                                selectedIngredient.strIngredient1 = Helpers.CleanString(selectedIngredient.strIngredient1);
                                Data.toggleIngredientInInventory(selectedIngredient);
                                isSelected = false;
                                exitMenu = false;
                            }
                            break;
                        case ConsoleKey.C:
                            multipleIngrediants.Clear();
                            isSelected = false;
                            exitMenu = false;
                            break;
                        case ConsoleKey.A:
                            {
                                if (searchByMultipleIngredients)
                                {
                                    multiSelected = ingredients[option - 2 + ((currentPage - 1) * itemsPerPage)].strIngredient1;
                                    multiSelected = Helpers.CleanString(multiSelected);
                                    multipleIngrediants.Add(multiSelected);
                                    isSelected = false;
                                    exitMenu = false;
                                }
                                else
                                { break; }
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (option == 1)
                            {
                                exitMenu = true;
                                isSelected = true;
                                break;
                            }
                            else if (searchByMultipleIngredients)
                            {
                                int ingredientCount = multipleIngrediants.Count;
                                Dictionary<Drink, int> drinkInfoDict = Helpers.MultiSearch(multipleIngrediants);
                                multiSearchResult(ingredientCount, drinkInfoDict);
                            }
                            else
                            {
                                selectedIngredient = ingredients[option - 2 + ((currentPage - 1) * itemsPerPage)];
                                selectedIngredient.strIngredient1 = Helpers.CleanString(selectedIngredient.strIngredient1);
                                List<Drink> drinks = DrinksService.GetDrinkListByIngredient(selectedIngredient);
                                FilteredDrinksMenu(drinks);

                                isSelected = false;
                            }
                            break;
                    }
                }
            }
        }

        private static void SettingsMenu()
        {
            {
                Settings settings = Data.GetSettings();
                string pageText = "Settings";
                ConsoleKeyInfo key;
                int option = 1;
                bool isSelected = false;
                bool exitMenu = false;
                (int left, int top) = Console.GetCursorPosition();
                string color = $"{checkMark}{green}   ";

                List<Category> categories = DrinksService.GetCategoriesListAsync().GetAwaiter().GetResult();

                Console.CursorVisible = false;
                while (!exitMenu)
                {
                    while (!isSelected)
                    {
                        OpenMenu(pageText, 1);

                        Console.WriteLine($@"{(option == 1 ? color : "    ")}EXIT    {resetColor}");
                        Console.WriteLine($@"{(option == 2 ? color : "    ")}Language{resetColor}");
                        if (option > 1)
                        {
                            foreach (Settings.LanguageEnum language in Enum.GetValues(typeof(Settings.LanguageEnum)))
                            {
                                string displayName = settings.GetLanguageDisplayName(language);
                                string formattedName = $"{(option == (int)language + 3 ? color : "    ")}  *{displayName}*{resetColor}";

                                if (settings.Language == language)
                                {
                                    Console.WriteLine(formattedName);
                                }
                                else
                                {
                                    Console.WriteLine(formattedName.Replace("*", ""));
                                }
                            }
                        }

                        key = Console.ReadKey(true);



                        switch (key.Key)

                        {
                            case ConsoleKey.DownArrow:
                                option = option == 6 ? 1 : option + 1;
                                break;

                            case ConsoleKey.UpArrow:
                                option = option == 1 ? 6 : option - 1;
                                break;

                            case ConsoleKey.Enter:
                                isSelected = true;
                                break;
                        }
                    }

                    switch (option)
                    {
                        case 3:
                            settings.Language = Settings.LanguageEnum.EN;
                            break;
                        case 4:
                            settings.Language = Settings.LanguageEnum.DE;
                            break;
                        case 5:
                            settings.Language = Settings.LanguageEnum.FR;
                            break;
                        case 6:
                            settings.Language = Settings.LanguageEnum.IT;
                            break;
                        default:
                            settings.Language = Settings.LanguageEnum.EN;
                            break;

                    }

                    switch (option)
                    {
                        case 1://Exit
                            exitMenu = true;
                            isSelected = true;
                            break;
                        case 2://Language
                            option++;
                            isSelected = false;
                            break;
                        default://Update Language
                            Data.UpdateSettings(settings);
                            isSelected = false;
                            break;
                            

                    }

                }
            }
        }

        internal static void OpenMenu(string pageText, int option)
        {
            Console.Clear();

            (int left, int top) = Console.GetCursorPosition();

            Console.Clear();
            Console.SetCursorPosition(left, top);
            switch (option)
            {
                case (1):
                    { Console.WriteLine($@"Use {green}{upArrow}{resetColor} and {green}{downArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select."); }
                    break;
                case (2):
                    { 
                        Console.WriteLine($@"Use {green}{upArrow}{resetColor}, {green}{downArrow}{resetColor}, {green}{leftArrow}{resetColor}, and {green}{rightArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select.");
                        Console.WriteLine($@"Press {green}I{resetColor} to {green}Add/Remove{resetColor} an ingredient from the inventory.");
                        Console.WriteLine($@"Press {green}M{resetColor} to search by multiple agreements.");
                    }
                    break;
                case (3):
                    { 
                        Console.WriteLine($@"Use {green}{leftArrow}{resetColor} and {green}{rightArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select.");
                        Console.WriteLine($@"Press {green}F{resetColor} to favorite a drink.");
                    }
                    break;
                case (4):
                    {
                        Console.WriteLine($@"Use {green}{upArrow}{resetColor}, {green}{downArrow}{resetColor}, {green}{leftArrow}{resetColor}, and {green}{rightArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select.");
                    }
                    break;
                case (5):
                    {
                        Console.WriteLine($@"Use {green}{upArrow}{resetColor}, {green}{downArrow}{resetColor}, {green}{leftArrow}{resetColor}, and {green}{rightArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select.");
                        Console.WriteLine($@"Press {green}I{resetColor} to {green}Remove{resetColor} an ingredient from the inventory.");
                        Console.WriteLine($@"Press {green}M{resetColor} to search by multiple agreements.");
                    }
                    break;
            }
            Console.WriteLine(pageText);
            Console.WriteLine();
        }
        internal static void CategoriesMenu(List<Category> categories)
        {
            Console.Clear();
            string pageText = "Categories";

            ConsoleKeyInfo key;
            int option = 1;
            bool exitMenu = false;
            bool isSelected = false;
            string color = $"{checkMark}{green}   ";

            int numberOfItems = categories.Count;
            int index = 1;


            while (!exitMenu)
            {
                while (!isSelected)
                {
                    Menu.OpenMenu(pageText, 1);

                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");

                    index++;


                    foreach (Category category in categories)
                    {
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {category.strCategory}{resetColor}");
                        index++;
                    }
                    index = 1;//reset index
                    key = Console.ReadKey(true);


                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            option = (option == (numberOfItems + 1) ? 1 : option + 1);
                            break;
                        case ConsoleKey.UpArrow:
                            option = (option == 1 ? (numberOfItems + 1) : option - 1);
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                if (option == 1)
                {
                    exitMenu = true;
                    isSelected = true;
                    break;
                }
                else
                {
                    Category selectedCategory = categories[option - 2];
                    Console.Clear();
                    List<Drink> drinks = DrinksService.GetDrinkListByCategory(selectedCategory.strCategory);
                    FilteredDrinksMenu(drinks);
                    isSelected = false;
                }
            }
        }

        internal static void FilteredDrinksMenu(List<Drink> drinks)
        {
            Console.Clear();
            string pageText = "Drinks";

            ConsoleKeyInfo key;
            int option = 1;

            bool exitMenu = false;
            bool isSelected = false;
            
            string color = $"{checkMark}{green}   ";
            string star = $"{green}*{resetColor}";

            int numberOfItems = drinks.Count;
            int itemsPerPage = 13;
            int totalPages = (int)Math.Ceiling((double)numberOfItems / itemsPerPage);
            int currentPage = 1;
            int index = 1;

            while (!exitMenu)
            {
                while (!isSelected)
                {
                    Menu.OpenMenu(pageText, 1);

                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");
                    index++;

                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(currentPage * itemsPerPage, numberOfItems);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        bool inFavorites = Favorite.InFavorites(drinks[i].idDrink);
                        if (inFavorites == true)
                        {
                            
                                drinks[i].strDrink = drinks[i].strDrink.Replace(star, "");
                                drinks[i].strDrink = drinks[i].strDrink.Replace(green, "");
                                drinks[i].strDrink = star + drinks[i].strDrink + star;
                            
                            if (option== index)
                            {
                                drinks[i].strDrink = drinks[i].strDrink.Replace(star, "");
                                drinks[i].strDrink =star+green+drinks[i].strDrink+star;
                            }
                        }
                        else
                        {
                            if (drinks[i].strDrink.Contains(star))
                            {
                                // Replace the substring with an empty string
                                drinks[i].strDrink = drinks[i].strDrink.Replace(star, "");
                            }
                        }
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {drinks[i].strDrink}{resetColor}");
                        index++;
                    }

                    Console.WriteLine($"Page {currentPage} of {totalPages}");

                    index = 1; // Reset index

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option == ((numberOfItems+1)-(itemsPerPage*(currentPage-1))) && currentPage == totalPages)
                            {
                                option = 1;
                                currentPage = 1;
                            }
                            else
                            {
                                if (option == itemsPerPage + 1)
                                {
                                    option = 1;
                                    if (currentPage < totalPages)
                                    {
                                        currentPage++;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option++;
                                };
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (option == 1 && currentPage == 1)
                            {
                                option = (numberOfItems + 1) - (itemsPerPage * (totalPages - 1));
                                currentPage = totalPages;
                            }
                            else
                            {
                                if (option == 1)
                                {
                                    option = itemsPerPage + 1;
                                    if (currentPage > 1)
                                    {
                                        currentPage--;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option--;
                                }
                                index = 1;
                                break;
                            }
                            break;
                        
                        case ConsoleKey.LeftArrow: // Back to the previous page
                            if (currentPage > 1)
                            {
                                currentPage--;
                                index = 1; // Reset index for the new page
                            }
                            else
                            {
                                currentPage = totalPages;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.RightArrow: // Go to the next page
                            if (currentPage < totalPages)
                            {
                                currentPage++;
                                index = 1; // Reset index for the new page
                            }
                            else
                            {
                                currentPage = 1;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                if (option == 1)
                {
                    exitMenu = true;
                    isSelected = true;
                    break;
                }
                else
                {
                    Drink selectedDrink = drinks[option - 2 + ((currentPage-1)*itemsPerPage)];
                    Console.Clear();
                    DrinkDetail selectedDrinkDetail = DrinksService.GetDrink(selectedDrink.idDrink);
                    RecepeMenu(selectedDrinkDetail);

                    isSelected = false;
                }
            }
        }

        internal static void FavoriteDrinksMenu()
        {
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.Clear();
                string pageText = "Drinks";

                ConsoleKeyInfo key;
                int option = 1;
               
                bool isSelected = false;
                string color = $"{checkMark}{green}   ";

                List<Favorite> favorites = Data.GetFavorites();
                int numberOfItems = favorites.Count;
                int itemsPerPage = 13;
                int totalPages = (int)Math.Ceiling((double)numberOfItems / itemsPerPage);
                int currentPage = 1;
                int index = 1;
                int instructionsOption = 4;
                if (numberOfItems > itemsPerPage) 
                {
                    instructionsOption = 2;
                }

                while (!isSelected)
                {
                    Menu.OpenMenu(pageText,instructionsOption);

                    Console.WriteLine($@"{(option == index ? color : "    ")}BACK     {resetColor}   ");
                    index++;

                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(currentPage * itemsPerPage, numberOfItems);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Console.WriteLine($@"{(option == index ? color : "    ")}  {favorites[i].DrinkStr}{resetColor}");
                        index++;
                    }

                    Console.WriteLine($"Page {currentPage} of {totalPages}");

                    index = 1; // Reset index

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option == ((numberOfItems + 1) - (itemsPerPage * (currentPage - 1))) && currentPage == totalPages)
                            {
                                option = 1;
                                currentPage = 1;
                            }
                            else
                            {
                                if (option == itemsPerPage + 1)
                                {
                                    option = 1;
                                    if (currentPage < totalPages)
                                    {
                                        currentPage++;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option++;
                                };
                                index = 1;
                                break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (option == 1 && currentPage == 1)
                            {
                                option = (numberOfItems + 1) - (itemsPerPage * (totalPages - 1));
                                currentPage = totalPages;
                            }
                            else
                            {
                                if (option == 1)
                                {
                                    option = itemsPerPage + 1;
                                    if (currentPage > 1)
                                    {
                                        currentPage--;
                                    }
                                    index = 1;
                                    break;
                                }
                                else
                                {
                                    option--;
                                }
                                index = 1;
                                break;
                            }
                            break;

                        case ConsoleKey.LeftArrow: // Back to the previous page
                            if (currentPage > 1)
                            {
                                currentPage--;
                                index = 1; // Reset index for the new page
                            }
                            else
                            {
                                currentPage = totalPages;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.RightArrow: // Go to the next page
                            if (currentPage < totalPages)
                            {
                                currentPage++;
                                index = 1; // Reset index for the new page
                            }
                            else
                            {
                                currentPage = 1;
                                index = 1;
                            }
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                if (option == 1)
                {
                    exitMenu = true;
                    isSelected = true;
                    break;
                }
                else
                {
                    Favorite selectedFavorite = favorites[option - 2 + ((currentPage - 1) * itemsPerPage)];
                    Console.Clear();
                    string strDrinkID = selectedFavorite.DrinkID.ToString();
                    DrinkDetail selectedDrinkDetail = DrinksService.GetDrink(strDrinkID);
                    RecepeMenu(selectedDrinkDetail);

                    isSelected = true;
                    exitMenu = false;
                }
            }
        }

        internal static void RecepeMenu(DrinkDetail selectedDrink)
        {
            string pageText = "Drink Recipe";
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            bool exitMenu = false;
            (int left, int top) = Console.GetCursorPosition();
            
            string color = $"{green}    ";
            string noColor = $"    ";
            string colorTop = $"{green}    ";
            string noColorTop = $"    ";
            string star = $"{green}*{resetColor}";


            List<Category> categories = DrinksService.GetCategoriesListAsync().GetAwaiter().GetResult();

            Console.CursorVisible = false;
            while (!exitMenu)
            {
                while (!isSelected)
                {
                    Console.Clear();

                    (left,top) = Console.GetCursorPosition();

                    OpenMenu(pageText, 3);


                    Console.Write($@"{(option == 1 ? colorTop : noColorTop)}______{resetColor}");
                    Console.Write($@"{(option == 2 ? colorTop : noColorTop)}____________{resetColor}");
                    Console.Write($@"{(option == 3 ? colorTop : noColorTop)}______________{resetColor}");
                    Console.WriteLine($@"{(option == 4 ? colorTop : noColorTop)}_____________{resetColor}");


                    Console.Write($@"{(option == 1 ? color : noColor)}|Back|{resetColor}"); 
                    Console.Write($@"{(option == 2 ? color : noColor)}|Drink Info|{resetColor}");
                    Console.Write($@"{(option == 3 ? color : noColor)}|Instructions|{resetColor}");
                    Console.WriteLine($@"{(option == 4 ? color : noColor)}|Ingrediants|{resetColor}");

                    switch (option)
                    {
                        case 1:
                            TableVisualisationEngine.ShowDrinkTabOne(selectedDrink);
                            break;
                        case 2:
                            TableVisualisationEngine.ShowDrinkTabTwo(selectedDrink);
                            break;
                        case 3:
                            TableVisualisationEngine.ShowDrinkTabThree(selectedDrink);
                            break;
                        case 4:
                            TableVisualisationEngine.ShowDrinkTabFour(selectedDrink);
                            break;
                    }

                    key = Console.ReadKey(true);



                    switch (key.Key)

                    {
                        case ConsoleKey.RightArrow:
                            option = option == 4 ? 1 : option + 1;
                            break;

                        case ConsoleKey.LeftArrow:
                            option = option == 1 ? 4 : option - 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;

                        case ConsoleKey.F:
                            FavoriteMenu(selectedDrink);
                            isSelected = false; 
                            break;
                    }
                }

                switch (option)
                {
                    case 1://Exit
                        exitMenu = true;
                        isSelected = true;
                        break;
                    default: 
                        exitMenu = false;
                        isSelected = false;
                    break;
                }

            }

        }

        internal static void FavoriteMenu(DrinkDetail selectedDrink)
        {
            string pageText = "Favorite Drink";
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            bool exitMenu = false;
            (int left, int top) = Console.GetCursorPosition();

            string color = $"{green}    ";
            string noColor = $"    ";
            string colorTop = $"{green}    ";
            string noColorTop = $"    ";


            Console.CursorVisible = false;
            while (!exitMenu)
            {
                while (!isSelected)
                {
                    Console.Clear();

                    (left, top) = Console.GetCursorPosition();

                    Console.Clear();
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($@"Use {green}{leftArrow}{resetColor} and {green}{rightArrow}{resetColor} to navigate and press {green}Enter{resetColor} to select.");
                    Console.WriteLine(pageText);
                    Console.WriteLine();

                    Console.WriteLine($@"ID: {selectedDrink.idDrink}");
                    Console.WriteLine($@"Drink: {selectedDrink.strDrink}");


                    Console.Write($@"{(option == 1 ? color : noColor)}Yes{resetColor}");
                    Console.Write($@"{(option == 2 ? color : noColor)}No{resetColor}");

                    key = Console.ReadKey(true);

                    switch (key.Key)

                    {
                        case ConsoleKey.RightArrow:
                            option = option == 2 ? 1 : option + 1;
                            break;

                        case ConsoleKey.LeftArrow:
                            option = option == 1 ? 2 : option - 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }

                switch (option)
                {
                    case 1://Favorite
                        bool inFavorites = Favorite.InFavorites(selectedDrink.idDrink);
                        if (!inFavorites)
                        {
                            Data.EnterFavorite(selectedDrink);
                            Console.WriteLine();
                            Console.WriteLine($@"{green}{selectedDrink.strDrink}{resetColor} has been favorited.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($@"{green}{selectedDrink.strDrink}{resetColor} is already in your favorites.");
                            Console.ReadKey();
                        }
                        exitMenu = true;
                        isSelected= true;
                        break;
                    case 2://Exit
                        Data.RemoveFavorite(selectedDrink);
                        exitMenu = true;
                        isSelected = true;
                        break;
                }
            }
        }
    }
}
