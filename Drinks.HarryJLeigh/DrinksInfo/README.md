# Drinks Info Console Project

## Project Overview
This project aims to create a user-friendly application for restaurant employees to access and display drinks data from an external API. Users will start by selecting a drinks category, then choose a specific drink to view detailed information. The application will ensure no empty properties are shown, providing clean and accurate drink details. This solution simplifies menu management without requiring direct database interaction.

Created with C#/.NET utilising RestSharp, Newtonsoft.Json and ConsoleTableExt nuget packages.


## Requirements
- You were hired by restaurant to create a solution for their drinks menu.
- Their drinks menu is provided by an external company. All the data about the drinks is in the companies database, accessible through an API.
- Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.
- You don't need SQL here, as you won't be operating the database. All you need is to create an user-friendly way to present the data to the users (the restaurant employees)
- When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.
- When the users visualise the drink detail, there shouldn't be any properties with empty values

## Features 
- Fetches data using RestSharp from free web api - www.thecocktaildb.com
- Displays a simple page with the api response
- Categorized menu for easy browsing of drinks by type
- Allows users to view detailed information about selected drinks
- Filters out and hides properties with empty values in the drink details
- Provides a clean and intuitive interface for restaurant employees
- Includes input validation to ensure accurate selection of categories and drinks
- Supports seamless navigation back to the main menu or exiting the application

##  Lessons learned
### API Integration
- Developed practical experience in integrating external APIs using RestSharp, including managing HTTP requests, parsing JSON responses.
### Data Modeling with JsonProperty
- Learned to map API responses to models using JsonProperty for clean and structured data handling.
### User-Friendly Interfaces
- Improved at designing intuitive interfaces for browsing and viewing data.
### Input Validation and Error Handling
- Learned to validate inputs and handle errors for seamless operation.

## Challenges Faced
### API Data Mapping
- Mapping nested JSON responses to C# models with JsonProperty required careful structuring to handle dynamic and complex data.
### Filtering Empty Data
- Ensuring that no empty or null values were displayed in the drink details involved implementing efficient filtering logic.
