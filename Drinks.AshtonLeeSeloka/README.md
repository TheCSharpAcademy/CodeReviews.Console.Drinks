## Drinks Info

A simple Console app which consumes an API from https://www.thecocktaildb.com/.
This allows for drink information to be presented to the user.

## Key Features

- Consumes third party api from thecocktaildb.
- Displays Drink information to the user.
- Makes use of .Net HttpClient.
- Simple and user-friendly console interface.
  - Spectre.Console Library used to create User Interface.
    
 ## UI Samples
 
### Main Menu
![Main Menu](https://github.com/AshtonLeeSeloka/Drinks.AshtonLeeSeloka/blob/master/Drinks.AshtonLeeSeloka/Resources/Screenshot%202025-01-22%20221043.png)

### Drink Selection Menu
![Drinks selection menu](https://github.com/AshtonLeeSeloka/Drinks.AshtonLeeSeloka/blob/master/Drinks.AshtonLeeSeloka/Resources/Screenshot%202025-01-22%20221135.png)

### Drink Info Menu
![info](https://github.com/AshtonLeeSeloka/Drinks.AshtonLeeSeloka/blob/master/Drinks.AshtonLeeSeloka/Resources/Screenshot%202025-01-22%20221211.png)

## Lessons Learnt

Through this project,
I was able to learnt about .Nets HttpClient and how to interact with external Api's
I experienced challenges regarding deserializing the JSON data but came across C#'s Record class
This allowed for easy binding of information to my drinks object.

### Key Lessons
- HttpClient
- Repositories
- Deserializing Json Data

## Stack
- C#
- .Net
- Spectre.Console

## Resources
- MS Docs [HttpClient Tutorial](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient)
- [Article](https://dev.to/sebastiandevelops/working-with-nested-json-data-using-c-records-559h) outling how to work with nested Json.
