# DrinkInfo Console Applicaton

This drinkInfo console application was developed based on C#/.Net and [Spectre.Console](https://spectreconsole.net/) nuget library.
Specifically, this console application uses `System.Net.Http.HttpClient` class to fetch free datas from [TheCocktailDB](https://www.thecocktaildb.com/) and displays data using Spectre.

## Features

* Fetch data from the free web apis
* Implement a simple paging function

## Some ScreenShots

Show the categories of the drinks when application starts.

![Categories](screenshots/Categories.png)

Show the prompt waiting message when the data is not returned.

![DisplayWaitingMsg](screenshots/DisplayWaitingMsg.png)

Display data in pages.

![Paging0](screenshots/Paging0.png)

![Paging1](screenshots/Paging1.png)

Select a drink by its id and display its detail.

![Select98Drink](screenshots/Select98Drink.png)

![DrinkDetail](screenshots/DrinkDetail.png)

## Reference

* [Drink Info](https://thecsharpacademy.com/project/15)
* [Spectre.Console](https://spectreconsole.net/)
* Some posts of Stack Overflow
