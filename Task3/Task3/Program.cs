using System;
using System.Text;
using System.Security.Cryptography;

namespace Task3
{
    class Program
    {
        static void CheckIncorrect(bool incorrect) 
        {
            
        }
        static void Main(string[] args)
        {
            Table table = new Table();
            if (args.Length < 3)
            {
                Console.WriteLine($"You have not entered enough parameters: {args.Length}.");
                return;
            }

            foreach (string arg in args)
            {
                for (int i = Array.IndexOf(args, arg) + 1; i < args.Length; i++)
                {
                    if (arg == args[i])
                    {
                        Console.WriteLine($"You have entered duplicate arguments. Index of duplicate argument {arg}. Try again...");
                        return;
                    }
                }
            }

            if (args.Length % 2 == 0)
            {
                Console.WriteLine("You have entered an even number of arguments.");
                return;
            }

            bool steel_play = true;

            while (steel_play)
            {
                Random rnd = new Random();
                int pc_choice = rnd.Next(0, args.Length);
                byte[] key = HMAC.CreateHMACKey();
                HMAC.PrintByteArray(HMAC.CreateHMAC(args[pc_choice], key), "");

                Console.WriteLine("Available moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {args[i]}");
                }

                Console.WriteLine("To exit type \"exit\".\nTo get table type \"help\"");

                bool incorrect_input = true;
                int players_choice = 0;
                while (incorrect_input)
                {
                    Console.Write("Enter your move: ");
                    string input_str = Console.ReadLine();
                    if (input_str == "exit") 
                        return;
                    if (input_str == "help") 
                        table.CreateTable(args);
                    else
                    {
                        try
                        {
                            players_choice = int.Parse(input_str);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                    if (players_choice > 0 && players_choice <= args.Length)
                    {  
                        incorrect_input = false; 
                        Console.WriteLine($"Your move: {args[--players_choice]}");
                    }


                }

                Console.WriteLine($"Computer move: {args[pc_choice]}");

                bool array_sides = Winner.CheckArrWinRange(args, pc_choice);

                Console.WriteLine(Winner.CheckingResults(args, pc_choice, players_choice, array_sides));

                HMAC.PrintByteArray(key, "key");
                Console.WriteLine("Type any button");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
