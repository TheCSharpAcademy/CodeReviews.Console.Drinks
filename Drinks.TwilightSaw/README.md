# ConsoleDrinks

## Given Requirements:
- [x] This is an application where you can look for information about a drink from the menu.
- [x] When you open the application, you should be presented with the Drinks Category Menu and invited to choose a category. Then you'll have the chance to choose a drink and see information about it.
- [x] When you visualise the drink detail, there shouldn't be any properties with empty values.

## Features
* Connection with Free Cocktail API.

* A console based UI where you can navigate by user input.

   ![image](https://github.com/TwilightSaw/CodeReviews.Console.Drinks/blob/main/Drinks.TwilightSaw/images/ui.png)

* Table that contains details about drink you've chosen.

   ![image](https://github.com/TwilightSaw/CodeReviews.Console.Drinks/blob/main/Drinks.TwilightSaw/images/details.png)

## Challenges and Learned Lessons
- First connection to the API and using it was a little frustrasting, but it's relatively easy task after a moment.
- You need to create exact copy of JSON element from the API as your model to work with it.
- Tables in Spectre.Console are not very comfortable if you cant add Row with necessary information for all Columns at the same time.
- One of the two main challenges was to learn about async and Task to be able to correct use API.
- Another one was to use <T> for the first time, but it's very useful if you want to have more universal and clear code.

## Areas to Improve
- Better understanding of asynchronous methods in C#.
- Better usage of delegates and generic type parameters.

## Resources Used
- C# Academy guidelines and roadmap.
- ChatGPT for new information as delegates, generic type parameters, async and await, API usage etc..
- Spectre.Console documentation.
- This article about async methods (https://blog.stephencleary.com/2012/02/async-and-await.html).
- Free Cocktail API documentation.
- Various StackOverflow articles.
﻿