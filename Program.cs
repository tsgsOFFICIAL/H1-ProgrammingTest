using System;
using System.Collections.Generic;

namespace H1_ProgrammingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hi {Environment.UserName}!");
            Console.WriteLine("Do you wish to set up a tournament?");

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();
                        Console.WriteLine("Aighty mighty!\nLet's get started!");
                        System.Threading.Thread.Sleep(500);
                        Tournament tournament = new Tournament(SelectHeroes());
                        RunTournament(tournament);
                        break;
                    case ConsoleKey.N:
                        Console.Clear();
                        Console.WriteLine($"Aight, bye {Environment.UserName}");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static List<Hero> SelectHeroes()
        {
            List<Hero> heroes = new List<Hero>();
            Console.Clear();
            Console.WriteLine("First you need to select some heroes, or alternatively, use one of each (Press 'ENTER' for one of each)\n");
            Console.WriteLine("Here are your options:");

            string[] heroList = Enum.GetNames(typeof(Hero.Type));
            for (int i = 1; i <= heroList.Length; i++)
            {
                Console.WriteLine($"({i}) {heroList[i - 1]}");
            }

            while (heroes.Count < 8)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        heroes.Add(new Hero(Hero.Type.KongFu));
                        break;
                    case ConsoleKey.NumPad1:
                        heroes.Add(new Hero(Hero.Type.KongFu));
                        break;
                    case ConsoleKey.D2:
                        heroes.Add(new Hero(Hero.Type.SuperDogDino));
                        break;
                    case ConsoleKey.NumPad2:
                        heroes.Add(new Hero(Hero.Type.SuperDogDino));
                        break;
                    case ConsoleKey.D3:
                        heroes.Add(new Hero(Hero.Type.FastCarl));
                        break;
                    case ConsoleKey.NumPad3:
                        heroes.Add(new Hero(Hero.Type.FastCarl));
                        break;
                    case ConsoleKey.D4:
                        heroes.Add(new Hero(Hero.Type.VenomousGunner));
                        break;
                    case ConsoleKey.NumPad4:
                        heroes.Add(new Hero(Hero.Type.VenomousGunner));
                        break;
                    case ConsoleKey.D5:
                        heroes.Add(new Hero(Hero.Type.MinimouseMikkel));
                        break;
                    case ConsoleKey.NumPad5:
                        heroes.Add(new Hero(Hero.Type.MinimouseMikkel));
                        break;
                    case ConsoleKey.D6:
                        heroes.Add(new Hero(Hero.Type.CatTiger));
                        break;
                    case ConsoleKey.NumPad6:
                        heroes.Add(new Hero(Hero.Type.CatTiger));
                        break;
                    case ConsoleKey.D7:
                        heroes.Add(new Hero(Hero.Type.RubberGoat));
                        break;
                    case ConsoleKey.NumPad7:
                        heroes.Add(new Hero(Hero.Type.RubberGoat));
                        break;
                    case ConsoleKey.D8:
                        heroes.Add(new Hero(Hero.Type.MooseEgon));
                        break;
                    case ConsoleKey.NumPad8:
                        heroes.Add(new Hero(Hero.Type.MooseEgon));
                        break;
                    case ConsoleKey.Enter:
                        heroes.Add(new Hero(Hero.Type.KongFu));
                        heroes.Add(new Hero(Hero.Type.SuperDogDino));
                        heroes.Add(new Hero(Hero.Type.FastCarl));
                        heroes.Add(new Hero(Hero.Type.VenomousGunner));
                        heroes.Add(new Hero(Hero.Type.MinimouseMikkel));
                        heroes.Add(new Hero(Hero.Type.CatTiger));
                        heroes.Add(new Hero(Hero.Type.RubberGoat));
                        heroes.Add(new Hero(Hero.Type.MooseEgon));
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Alright, you got these heroes:");
            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero.Name);
            }
            System.Threading.Thread.Sleep(1500);
            return heroes;
        }

        private static void RunTournament(Tournament tournament)
        {
            while (tournament.Stage >= 0 && tournament.Stage < 3)
            {
                Console.Clear(); //Clear the screen
                //Print the current status
                foreach (Hero hero in tournament.Heroes)
                {
                    Console.WriteLine($"{hero.Name} is {hero.Alive} ({hero.HP})");
                    
                    Console.Write("Attack values: ");
                    foreach (byte attack in hero.Attack)
                    {
                        Console.Write($"{attack}, ");
                    }
                    Console.WriteLine();
                    Console.Write("Defence values: ");
                    foreach (byte defence in hero.Defence)
                    {
                        Console.Write($"{defence}, ");
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine("Move on? (Y/N), pressing N will result in the program closing down");
                bool wait = true; 
                while (wait)
                {
                    switch (Convert.ToString(Console.ReadKey(true).KeyChar).ToLower())
                    {
                        case "y":
                            wait = false;
                            tournament.StartStage();
                            wait = true;
                            break;
                        case "n":
                            Console.Clear();
                            Console.WriteLine($"Aight, bye {Environment.UserName}");
                            System.Threading.Thread.Sleep(1000);
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("The tournament has finished!");
            Console.WriteLine($"The winner is... {tournament.Winner.Name}!");

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

    }
}
