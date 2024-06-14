## DrinksInfo Application

### Overview

The DrinksInfo application is a console-based application that interacts with an external drinks API to retrieve and display various drink categories, types, and details. This application demonstrates the use of HTTP requests, JSON deserialization, and a command-line interface for user interaction.

### Key Features

- Fetch and display drink categories
- Fetch and display drink types based on selected categories
- Fetch and display detailed information about selected drinks
- User-friendly command-line interface with loading indicators

### Technologies Used

- .NET
- Spectre.Console for enhanced console output
- Newtonsoft.Json for JSON serialization and deserialization

### Lessons Learned

- Ensuring that the JSON models match the API response exactly to avoid deserialization issues.
- Handling HTTP requests and responses efficiently.

### Application Structure

#### DrinksController

The `DrinksController` class is responsible for managing the interactions with the `IDrinksService` to fetch data from the drinks API.

#### App

The `App` class contains the main logic for running the application, including user interactions and displaying the data.`

#### Models

The application uses various models to map the JSON responses from the API.

- `Drink`
- `DrinksResponse`
- `DrinkDetail`
- `DrinkDetailResponse`
- `DrinksCategory`
- `DrinkCategories`

These models ensure that the data is correctly deserialized and available for use within the application.

#### Services

The `DrinksService` class handles the HTTP requests to the external API.

### Usage

Upon running the application, the user will be prompted to select a drink category, followed by selecting a drink type, and finally viewing detailed information about the selected drink. The application uses a user-friendly command-line interface with colored output for better user experience.