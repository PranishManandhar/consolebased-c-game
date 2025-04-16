using System;
using weatherInfo;
public class Player
{
    // player properties
    private int Healthpoints { get; set; }
    public int ActivitiesForDay { get; set; }
    public int supplies { get; set; }
    private int Distance { get; set; }
    // variables for code
    public int max_activities_per_day = random.Next(5, 11);
    // object definations
    private static Random random = new Random();

    public Player()
    {
        Healthpoints = 100;
        supplies = 50;
        ActivitiesForDay = 0;
        Distance = 0;
    }
 
    public void checkweather((Weather weather, float temp, float wind, string precip) weatherData)
    {
        Console.WriteLine($"Today's Weather: {weatherData.weather}");
        Console.WriteLine($"Temperature: {weatherData.temp}");
        Console.WriteLine($"WindSpeed: {weatherData.wind}");
        Console.WriteLine($"Precipitation: {weatherData.precip}");
    }

    public void Rest()
    {
        Console.WriteLine("You Decided to take some rest");
        Healthpoints += 50;
        supplies+=2;
        Distance += 3;
    }
    public void Hunt()
    {
        int chance = random.Next(1, 4);

        switch (chance)
        {
            case 1:
                Console.WriteLine("You found some supplies while on the hunt.");
                supplies += 10;
                Distance += 10;
                break;

            case 2:
                Console.WriteLine("You found nothing on your hunt.");
                break;

            case 3:
                Console.WriteLine("You encountered some bandits, and they robbed you.");
                supplies -= 10;
                Distance -= 5;
                break;
        }
    }
    public void travel((Weather weather, float temp, float wind, string precip) weatherData)
    {
        Console.WriteLine($"Attempting to travel during {weatherData.weather} weather");

        if (weatherData.temp > 40 && weatherData.wind >30){
            Console.WriteLine("This Weather is not good to travel in.");
            Healthpoints-=5;
            supplies-=5;
        }
        else
        {
            int distanceperactivity = random.Next(1, 6);
            Distance+=distanceperactivity;
            supplies -= 5;
            Console.WriteLine($"you travelled {distanceperactivity} meters. Total Travelled Distance -> {Distance}");
        }
    }

    public void performActivities()
    {
        var weatherData = WeatherSystem.GenerateWeather();
        Console.WriteLine($"you can perform {max_activities_per_day} activities today");

        for (int i = 1; i <= max_activities_per_day; i++)
        {
            Console.WriteLine($"\nActivity: {i}\n");
            Console.WriteLine($"HP: {Healthpoints}, Supplies: {supplies}, Distance: {Distance}, Activities Completed: {ActivitiesForDay}");

            Console.WriteLine("\nChoose an activity to perform: [1]Travel [2]Hunt [3]Rest [4]Check Weather");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                i--;
                continue;
            }

            switch (choice)
            {
                case 1:
                    travel(weatherData);
                    break;
                case 2:
                    Hunt();
                    break;
                case 3:
                    Rest();
                    break;
                
                case 4:
                    checkweather(weatherData);
                    break;
                default:
                    Console.WriteLine("Invalid action");
                    i--;
                    continue;
            }


            if (Healthpoints <= 0)
            {
                Console.WriteLine("Game Over!! you had a good run");
                break;
            }

            if (supplies <= 0)
            {
                Console.WriteLine("you are out of supplies");
                Healthpoints -= 5;
                supplies = 0;
            }

            ActivitiesForDay++;
        
        }
    }

    public bool isdead()
    {
        if (Healthpoints <= 0)
        {
            return true;
        }
        return false;
    }
}