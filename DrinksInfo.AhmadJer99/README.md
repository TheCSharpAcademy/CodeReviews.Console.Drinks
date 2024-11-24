# DrinksInfo

***A restaurant asked me to create a solution for their drinks menu, 
Their drinks menu is provided by an external company.
 All the data about the drinks is in the companies database, accessible through an Api.***
 
![istockphoto-1202283098-612x612](https://github.com/user-attachments/assets/32fa701c-d4b2-45d3-a8af-c47b4fd6613b)

- Console based application that utilizes external Api requests to get information for a drinks menu from an external website 
- Developed using C# and the [TheCockTailDatabase](https://www.thecocktaildb.com/api.php) Api

# P.S some weird visual bugs may appear such as text duplication when in windowed mode of the console application, for optimal testing please keep the console in fullscreen!
 
# Given Requirements:
- Create a system that allows the restaurant employee to pull data from any drink in the database
- you need is to create an user-friendly way to present the data to the users (the restaurant employees)
- When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.
- When the users visualise the drink detail, there shouldn't be any properties with empty values

# Resources
- [How to Deserialize JSON Nested Arrays into C# using Newtonsoft.](https://www.youtube.com/watch?v=LWtxg7g5s9U)
- [How to Run an Async Method Synchronously in .NET](https://code-maze.com/run-async-method-synchronously-dotnet/)
- [My stack Over Flow question](https://stackoverflow.com/questions/79217327/how-to-dynamically-handle-and-display-varying-numbers-of-columns-e-g-drink-in/79217357?noredirect=1#comment139691970_79217357)
- [Microsoft Docs: Http Requests](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient)

# Features
- Used [Spectre.Console](https://spectreconsole.net/) Library to add colors and select the first menu with arrow keys.
- Provides a user-friendly view for the user to select any Category / Drink 
- ![image](https://github.com/user-attachments/assets/f0c8a301-26cc-41b2-b423-537f0a4ba14d)
  
- ![image](https://github.com/user-attachments/assets/496fd2ca-e73b-4808-8f8d-ac584027e467)
  
- Displays a user-friendly, well formatted and non cluttered view for the drinks information 
- ![image](https://github.com/user-attachments/assets/f2415b56-8a8b-4267-8d58-007a32594f4e)

- The application handles any invalid input in any menu and handles any null values from the Api requests.
  
# Lessons learned
- I learnt how to do Http requests to external Api's through Microsoft documentation.
- I learnt how to deserialize Json files into the correct models.
- I learnt how to map and bind Json properties into my own structure and not allow the Json properties to structure my models, and i've done that using JsonPropert feature.
- I learnt how to handle async method and how to make it sync.

# Future Improvments
- I can defintely still imrpove my OOP side, I think i could have done stuff more efficiently in the menus if I learned to utilize OOP correclty.
- My organization of models and files and even class names can be improved.
- I still need to work on the SOC area in most of my code.
- Maybe there is a better way to handle the DrinkDetails model columns, I am not sure.

