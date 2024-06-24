using static DrinksInfos.Helpers;

namespace DrinksInfos;

public static class DataValidation
{
    public static int GetCategoryIdInput(string message = "")
    {
        bool idIsValid = false;
        int idInput = 0;
        var categories = GetSequencedCategoriesList();

        while (idIsValid == false)
        {
            idInput = GetNumberInput(message);

            foreach (var category in categories)
            {
                if (category.Id == idInput)
                {
                    idIsValid = true;
                    return idInput;
                }
            }

            DisplayError($"{idInput} is not a valid id");
        }

        return idInput;
    }

    public static int GetDrinkIdInput(string categoryName, string message = "")
    {
        bool idIsValid = false;
        var drinks = GetSequencedDrinkList(categoryName);

        while (idIsValid == false)
        {
            int idInput = GetNumberInput(message);

            if (idInput == 0) return idInput;

            foreach (var drink in drinks)
            {
                if (int.Parse(drink.Id) == idInput)
                {
                    idIsValid = true;
                    return idInput;
                }
            }

            DisplayError($"{idInput} is not a valid id");
        }
        return 0;
    }

    public static int GetNumberInput(string message = "")
    {
        Console.WriteLine(message);

        var input = Console.ReadLine();

        while (!int.TryParse(input, out _))
        {
            DisplayError($"{input} is not a number");
            Console.WriteLine(message);

            input = Console.ReadLine();
        }

        int validNumber = int.Parse(input);

        return validNumber;
    }
}
