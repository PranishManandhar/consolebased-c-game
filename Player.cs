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
    private int max_activities_per_day = 10;
    // object definations
    private static Random random = new Random();
    


    public void checkweather(){
        var (weather,temp,wind,precip) = WeatherSystem.GenerateWeather();
    }



    public Player()
    {
        Healthpoints = 100;
        supplies = 50;
        ActivitiesForDay = 0;
        Distance = 0;
    }

    public void Rest()
    {
        Healthpoints += 50;
        Distance += 3;
    }
    public void CheckStats()
    {
        Console.WriteLine($"HP: {Healthpoints}, Supplies: {supplies}, Distance: {Distance}, Activities Completed: {ActivitiesForDay}");
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
    public void travel()
    {

    }
    public void shop() { }
    public void performActivities()
    {
        for (int i = 1; i <= max_activities_per_day; i++)
        {
            Console.WriteLine("Choose an activity to perform: [1]Travel [2]Hunt [3]Rest");
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
                    travel();
                    break;
                case 2:
                    Hunt();
                    break;
                case 3:
                    Rest();
                    break;
                default:
                    Console.WriteLine("Invalid action");
                    i--;
                    continue;
            }

            ActivitiesForDay++;

            if (Healthpoints <= 0)
            {
                Console.WriteLine("Game Over!! you had a good run");
                break;
            }

            if (supplies <= 0)
            {
                Console.WriteLine("you are out of supplies");
                Healthpoints -= 5;
            }
        }
    }

}