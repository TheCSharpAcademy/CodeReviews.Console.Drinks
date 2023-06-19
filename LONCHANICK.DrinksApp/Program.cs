using LONCHANICK.DrinksApp.Request;



while (true)
{

    var drinkCategories = await DrinksRequest.GetDrinkCategories();

    Console.Clear();
    Console.WriteLine("\t--- DRINK CATEGORIES ---");
    
    Console.WriteLine("Enter your choice: ");
    Console.WriteLine(" 0)Exit ");
    Console.WriteLine(drinkCategories);
    Console.Write("Enter any valid option ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Clear();
            var aux = await DrinksRequest.GetDrinksByCategory("Cocktail");
            Console.WriteLine(aux);
            break;
        case "2":
            Console.Clear();
            break;
        case "3":
            Console.Clear();
            break;
        case "4":
            break;
        case "5":
            break;
        case "6":
            break;
        case "7":
            break;
        case "8":
            break;
        case "9":
            break;
        case "10":
            break;
        case "11":
            break;
        case "0":
            return;
        default:
            Console.Clear();
            Console.WriteLine("Invalid input.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            break;
    }
}