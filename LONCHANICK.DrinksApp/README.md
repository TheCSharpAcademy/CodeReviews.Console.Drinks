# Drinks Menu Application

## Drinks Menu Application

### Abstract

The Drinks Menu Application is designed to streamline the process of accessing and presenting a restaurant's drinks menu, which is sourced from an external vendor's API. The application allows restaurant employees to:

1. **Connect to an External API**: Utilize .NET's class library to make HTTP requests to the vendor's API, retrieving detailed information about various drinks.
2. **User-Friendly Interface**: Provide an intuitive interface for users to navigate through drink categories and select specific drinks.
3. **Detailed Drink Information**: Ensure that all displayed drink details are complete, filtering out any properties with empty values to enhance user experience.
4. **Dynamic Data Presentation**: Allow users to dynamically pull and view up-to-date data from the vendor's database without needing direct database interaction or SQL knowledge.

This application aims to simplify the workflow for restaurant employees, enabling them to efficiently access and present drink information to customers.

## Introduction

Often times developers work with third-party data. A very common way of accessing external vendor’s data is to make requests to their APIs (Application Programming Interface). Once we have access to their data, we can process it in our application to suit our needs. Another common scenario is when an organization has multiple independent applications that communicate amongst themselves, the so-called microservices.

In this application, we will learn how to connect to an external API through HTTP requests using .NET’s class library. It‘s easier than you imagine! Luckily there are many public APIs out there. Here’s a great list of public APIs for practice.

## Requirements

You were hired by a restaurant to create a solution for their drinks menu.

- Their drinks menu is provided by an external company. All the data about the drinks is in the company's database, accessible through an API.
- Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.
- You don't need SQL here, as you won't be operating the database. All you need is to create a user-friendly way to present the data to the users (the restaurant employees).
- When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.
- When the users visualize the drink detail, there shouldn't be any properties with empty values. 

## Resources

Here are the links for using HTTP calls with C# and to the Drinks API documentation:

- [Cocktail Database](https://www.thecocktaildb.com/api.php)
- [Microsoft Docs: Http Requests](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient)
- [Video: Drinks Info App (FULL PROJECT)](https://www.youtube.com/watch?v=dQw4w9WgXcQ)
