# ASP.NET-Core-Weather-Forecast-Service

                                 _ABSTRACT_ 

The following is a Weather Forecast Service written in Asp.NET Core. 
It calls OpenWeatherMap API (https://api.openweathermap.org) to get weather information for specified cities. 


                               _Instructions_
                                    
 1) download and unpack the archive.
 2) open visual studio as administrator.
 3) from inside visual studio navigate to the unzipped folder and open the "WeatherService.sln" file.
 4) Build the solution and then run it!
 
 5) There is one actions created in WeatherDetailController.cs
	1.ReadWeatherDetails
		
	ReadWeatherDetails:-
	This is Post Mathod
	Postman localhost URl:- https://localhost:44359/api/forecast/ReadWeatherDetails
	This will read file from InputFolder present in bin directory in WeatherService.API
	Sample Path:- C:\Users\Bhavin.Busa\source\repos\WeatherService\WeatherService\bin\Debug\netcoreapp3.1\InputFolder
	I have added a Sample File in "InputFolder" , Path:- WeatherService\InputFolder
	
	Note:- "InputFolder" need to be creted in bin folder and a file with "myFile.json" (FileName) need to be added in this folder and then need to trigger this Action.
	
	This will generate JSON file per city in OutputFolder of bin directory in WeatherService.API
	Sample Path:- C:\Users\Bhavin.Busa\source\repos\WeatherService\WeatherService\bin\Debug\netcoreapp3.1\OutputFolder
	
	Note:- If "OutputFolder" does not exists inside bin folder , it wil get created automatically when this action is called
 
                                  
                             HAVE A SUNNY DAY :)
