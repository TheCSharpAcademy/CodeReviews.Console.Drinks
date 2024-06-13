# Drinks Info Console App

This is a one of the C# Academy Intermediate Console application projects. This application is used to show drinks information
for the user based on the selection. Information is retrieved using external API through HTTP requests. User will
make first selection of the category and then choose the drink which data is wanted to shown.

Below are the application's requirements, features, user manual, and areas for improvement.

## Requirements

- [x] Ability to pull data from any drink from the database via API without the need
      for local storage or SQL operations.
- [x] A user-friendly interface for browsing drink categories and viewing drink details.
- [x] Ensure complete drink information is displayed without any empty properties.
- [x] Upon application launch, present users with a categorized menu of drink options for easy navigation.
- [x] Use HTTP requests and .NET's class library to communicate with the external API.

## Features and validations

- **API integration**: The application connects to a external database via API,
  utilizing HTTP requests and .NET's class library.
- **ID Validation**: When user inputs a drink ID, the program validates if it exists. If not
  error message is shown for the user.
- **Spectre.Console -library utilization**: Used for menu selections, displaying
  drink data to users, and enhancing console presentation with colors.

## User Manual

### Category selection

- Selection of the drink categories is shown for the user when application opens. User selects the category
  using up and down arrow keys and confirming selection by pressing enter.  
![DrinkMenu](https://github.com/HopelessCoding/learning/assets/161690352/9c4842d6-0602-437d-a658-49a23896e13e)

### Drink selection

- User selects drink by writing its ID or writing "exit" if wanting to return back to category selection.  
![DrinksSelection](https://github.com/HopelessCoding/learning/assets/161690352/b788c59b-5024-4432-aedd-c4d8474f1bb8)

### Drink details

- Drink details are displayed for the user, with ingredients and measurements shown on a single line for
  better visualization. The user can press any key to return to the main menu.  
![DrinkDetails](https://github.com/HopelessCoding/learning/assets/161690352/65648295-6ee0-4107-a623-6bbe09c81c3a)

## Areas for Improvement and Lessons Learned

- **APIs**: This is completely new to me. While APIs have been a familiar term, now I've finally started to
  understand what they are and how to use them. There's still much to learn, but I'm sure that I'll
  face APIs in many future coding tasks.
- **Use of Classes and Objects**: Correct and effective use of classes and object sometimes feels a bit
  uncertain for me. Will try to focus more on these topics to learn how to use them better.
