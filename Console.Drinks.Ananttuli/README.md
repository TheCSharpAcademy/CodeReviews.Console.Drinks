# DrinkMenu

An electronic drinks menu which can dynamically retrieve and display
the latest drinks info from an external API.

## Features

- Display drink categories
- Display list of drinks by category
- Display drink info

## Run locally

Note: Endpoints configurable via `/DrinksApi/appsettings.json` if needed.

- Clone this repo & `cd` into it
- `cd Program`
- `dotnet run`

## Technical details

- C# console app
- Uses [CocktailDB API](https://www.thecocktaildb.com/api.php) to fetch latest drink info
- Endpoints configurable via `/DrinksApi/appsettings.json`
