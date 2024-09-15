
# Drinks-Info.Lawang
This application is connected to an external API through HTTP requests using .NET’s class library. 
we use Restsharp nuget package to handle requests and response and Newtonsoft.json to deserialze the response we get from API.


## Requirements
- Their drinks menu is provided by an external company. All the data about the drinks is in the companies database, accessible through an API.
- This console app allows the users to pull data from any drink in the database.
- When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.

## Features
* No database is utilised here.
* Uses RestSharp package for handling requests and response.
* Uses Newtonsoft Json for deserializing data.





 ## Screen shots:

![Screenshot from 2024-09-15 12-19-13](https://github.com/user-attachments/assets/07eab011-0822-4984-ab56-ae444f97f1f7)

![Screenshot from 2024-09-15 12-19-47](https://github.com/user-attachments/assets/643d8448-d09d-41c0-afcd-157d2794c8cf)


- Data is presented to user in Table format, using the external library Spectre.Console.
- This app is beautified using Spectre.Console.



## Project Summary
#### What challenges did you face and how did you overcome them?

* I didn't know how to send Http request to the api, so i had to learn about that, and found out there is even easier way to do that via using RestSharp
package, so I used that for this project.





## 🛠 Skills Learned
#### REST-SHARP
* Using RestClient and RestRequest from RestSharp package to handle request and response is way easier than directly using HttpClient. 

#### Spectre.Console
* I honed my Spectre.Console skill in this project which i previously learned.


## FAQ

#### How to beautify the table in the project?

Answer I used the Microsoft.Spectre.Console package, which you can get for Nuget package manager. Install it and add Reference to your project. 

For more information u can visit the docs https://spectreconsole.net




## Feedback

If you have any feedback, please reach out to us at depeshgurung44@gmail.com

