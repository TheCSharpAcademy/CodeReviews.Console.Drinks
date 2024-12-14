#Drinks Menu Application
#Introduction
Welcome to the Drinks Menu application! This console application provides a simple and interactive way to explore a variety of drinks from an external API (TheCocktailDB). It allows users to browse drink categories, view drinks in a selected category, and get detailed information about each drink.

#Features
Drinks Category Menu: Upon opening the application, users are presented with a list of available drink categories and are invited to choose one.
Drink Selection: After selecting a category, users can view a list of drinks within that category and select a drink by entering its ID. If an invalid ID is entered, the application will prompt the user with an appropriate message until a correct ID is provided.
Drink Details: When a drink is selected, detailed information about it will be displayed, ensuring a complete and informative view.
How It Works
The Drinks Menu application interacts with TheCocktailDB's external API to fetch drink data. It makes HTTP requests to retrieve drink categories and detailed information, which is then processed and displayed to the user in a clean, easy-to-read format.

#The application works as follows:

Fetch Categories: The application starts by fetching a list of available drink categories.
Fetch Drinks by Category: Once a category is selected, drinks from that category are displayed.
View Drink Details: After a drink is selected, detailed information about that drink is shown.
Please note that the categories are case-sensitive, so be sure to enter the category names exactly as they appear.

#Getting Started
Follow the instructions below to get started with the Drinks Menu application:

Prerequisites
Before running the application, ensure that you have the following:

.NET 5.0 or later
A stable internet connection (to fetch data from TheCocktailDB API)

#Installing Required Packages

The following NuGet packages have been installed in this project:

RestSharp: A simple HTTP client for making API requests.
Newtonsoft.Json: A popular JSON library for parsing and serializing data.
ConsoleTableExt: A package for rendering clean, table-like structures in the console.

To install these packages, use the following commands in your terminal or Package Manager Console:
dotnet add package RestSharp
dotnet add package Newtonsoft.Json
dotnet add package ConsoleTableExt
Running the Application
Clone or download the project to your local machine.
Open the project in your preferred IDE or editor.
Build and run the project using .NET CLI or Visual Studio.

The application will prompt you to select a drink category. Once you choose a category, it will display a list of drinks.
Select a drink by entering its ID, and the application will fetch and display detailed information about the selected drink.

#Example Usage
When prompted, select a drink category (e.g., Ordinary_Drinks).
Choose a drink from the list by entering its ID (e.g., 11007).
The application will fetch and display details about the selected drink.

#Conclusion
This Drinks Menu application offers a fun and interactive way to explore a wide variety of drinks through an easy-to-use console interface. By fetching real-time data from TheCocktailDB, it provides an engaging user experience. Enjoy browsing and learning about different drinks!