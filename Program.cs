using System;

namespace ConsoleApp
{
    class Game
    {
        private Player player;
        private int daycount;

        public Game()
        {
            player = new Player();
            daycount = 0;
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the survival game");
            while (player.isdead() != true)
            {
                Console.Clear();
                Console.WriteLine($"Day {daycount+1}");
                player.performActivities();
                daycount++;
            }
        }

    } 

    class Program
    {
        static void Main(string[] args)
        {
            Game game= new Game();
            game.StartGame();
        }

    }
}