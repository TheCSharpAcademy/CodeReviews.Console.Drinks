# Drinks Info System

## Introduction
Modern software solutions often rely on external data to provide dynamic and interactive features. One common way to access this data is by using third-party APIs (Application Programming Interfaces). This application demonstrates how to connect to an external API via HTTP requests using .NET’s class libraries and popular tools like RestSharp and Newtonsoft.Json.

The goal of this application is to create an efficient, user-friendly interface for restaurant employees to access drink information provided by an external company’s API. Employees can view drink categories, select a category, browse available drinks, and view detailed information about each drink.

## Features
- Fetch and display drink categories from an external API.
- Allow users to select a category and view drinks within it.
- Provide detailed information about individual drinks.
- Ensure all displayed drink details contain no empty fields.

---

## Requirements
The application fulfills the following requirements:
1. **External API Integration:** Accesses drink data from a third-party API.
2. **User-Friendly Interface:** Designed for restaurant employees with clear and intuitive menus.
3. **Dynamic Data Retrieval:** Pulls data dynamically without requiring a database or SQL operations.
4. **Validation:** Handles user inputs robustly, ensuring valid category and drink selections.
5. **No Empty Fields:** Filters out properties with empty values in drink details.

---

## Technologies Used
- **C#/.NET:** Application development and business logic.
- **RestSharp:** Simplifies making HTTP requests to the external API.
- **Newtonsoft.Json:** Processes JSON responses from the API.
- **Console UI:** Provides a clear and interactive command-line interface.

---

## Installation
1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd DrinksInfoSystem
   ```

2. **Restore dependencies:**  
   Run the following command to ensure all required dependencies (e.g., `RestSharp` and `Newtonsoft.Json`) are installed:
   ```bash
   dotnet restore
   ```

3. **Build the project:**  
   Compile the application using:
   ```bash
   dotnet build
   ```

4. **Run the application:**  
   Launch the console app using:
   ```bash
   dotnet run
   ```
