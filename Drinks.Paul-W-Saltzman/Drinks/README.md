# Drinks

# Requirements
 * You were hired by restaurant to create a solution for their drinks menu.
  - [x] Their drinks menu is provided by an external company. All the data about the drinks is in the companies database, accessible through an API.
  - [x] Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.
  - [x] You don't need SQL here, as you won't be operating the database. All you need is to create an user-friendly way to present the data to the users (the restaurant employees)
  - [x] When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.
  - [x] When the users visualise the drink detail, there shouldn't be any properties with empty values

# Additional Challenge 
  - [x] Add the ability to Favorite drinks

# Additional Personal Challenges
  - [x] Add Random Drink Call.
  - [x] Add Search by ingredient.
  - [x] Add Inventory, and search by inventory.
  - [x] Add search by multiple ingredients.

# Features
	* Connection to drinks api.
	* SQLite Database connection for storing inventory, favorites, and settings.
	* A Console app where the user can navigate by key presses.

# Program
	* My Ingredients
		- List of ingredients saved by the user.
		- Search by ingredient.
		- Search by Multiple Ingredients.
		- Remove ingredients. 
	* My Favorites
		- List of drinks saved by the user.
		- Remove Favorites.
	* Ingredients
		- List of ingredients from the API.
		- Add / Remove ingredients from My Ingredients.
		- Search by ingredient.
		- Interface denotes those items in My Ingredients.
		- Search by Multiple Ingredients.
	* Categories
		- Seach by Category.
		- interface denotes those drinks in My Favorites.
	* Random Drink
		- Uses the API's random drink option to present a random drink.
	* Settings
		- Uses the options in the API to change the language of the instructions under the drink tabs.

	* Drinks Visualization.  
		- Shows a drink in a tabed view with each tab holding different information about the drink.
		- Favorite drink.

# What I learned
This is the first time I've worked with an API.  I also have never worked with a dictionary or a tuple before.  


# resources
https://www.thecocktaildb.com/api.php
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
https://stackoverflow.com/questions/8002455/how-to-easily-initialize-a-list-of-tuples
https://stackoverflow.com/questions/42785492/adding-an-item-to-a-tuple-in-c-sharp
