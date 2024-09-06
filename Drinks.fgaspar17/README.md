# Drinks
A console-based application to get information about drinks.

## Given Requirements:

- [x] This is an application where the users will create Stacks of Flashcards.
- [x] You were hired by restaurant to create a solution for their drinks menu.
- [x] Their drinks menu is provided by an external company. All the data about the
drinks is in the companies database, accessible through an API.
- [x] Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.
- [x] You don't need SQL here, as you won't be operating the database. All you need is to create an user-friendly
way to present the data to the users (the restaurant employees)
- [x] When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category.
Then they'll have the chance to choose a drink and see information about it.
- [x] When the users visualise the drink detail, there shouldn't be any properties with empty values

## Features

- API connection

  - The data is obtained via an API.

- Console-based UI to navigate the drinks

  - ![image](https://github.com/user-attachments/assets/cefa9729-711c-4182-b7ac-1217b3d6722c)
  - ![image](https://github.com/user-attachments/assets/0ddd8153-c212-4cef-8267-8c8ef44f1318)
  - ![image](https://github.com/user-attachments/assets/5af35f64-7e60-4443-b2ac-3ee0cde82c8f)

## Challenges

  - Consuming an API.
  - Managing the HTTP Client to avoid sockets exhaustion.
  - JSON serialization/deserialization.

## Lessons Learned

  - Working with JSON in .NET.
  - Singleton pattern to create one instance.
  - HTTP Client requests.
  - Async, await, and Tasks.

## Areas to Improve

  - Working with async.
  - API knowledge.

##  Resources used

  - StackOverflow posts
  - [HTTP Requests Microsoft Documentation]([https://learn.microsoft.com/en-us/sql/t-sql/queries/from-using-pivot-and-unpivot?view=sql-server-ver16](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient))
  - [Free Cocktail API]([https://www.thecocktaildb.com/api.php])
  - [Http Client Documentation](https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines)