# Drinks
This is a console app using C# designed to allow restaurant employees to view drink data by accessing an external API.

Written by Corey Jordan

Developed for The C# Academy - Drinks Console Exercise

## REQUIREMENTS
- The drink menu is provided by an external company, accessible through an API.
- SQL is not needed. This app simply presents the data from the API
- Upon opening the app, user should get a Drinks Category Menu, then they can choose a drink and get info
- There should be no empty values in data presentation

This app will reference TheCocktailDB located at https://www.thecocktaildb.com/api.php

As with previous projects, this app will make use of ConsoleTableExt

Additionally, we will use RestSharp and NewtonSoft.

## NOTES
- Console.Clear() misbehaves occasionally. I'm not sure exactly why but when scrolling up, artifacts of previous tables are left behind.
- One limitation with ConsoleTableExt is that there seems to be no obvious way to wrap text within a cell. THis can result in some awkward formatting with long entries. This was especially prevalent in the directions column.
- I'm still not 100% on the api calls. Specifically, why we have to make a list of 1 when we only want the single object.
