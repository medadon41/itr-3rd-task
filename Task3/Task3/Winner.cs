using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Winner
    {
        public static bool CheckArrWinRange(string[] args, int pc_choice)
        {
            if (args.Length / 2 + pc_choice < args.Length)
                return true;
            else return false;
        }

        public static void CheckingResults(string[] args, int pc_choice, int players_choice, bool array_sides)
        {
            int numplayerschoice = 0;
            for (int i = 0; i < args.Length; i++)
                if (players_choice == i)
                {
                    numplayerschoice = i;
                    break;
                }

            if (pc_choice == numplayerschoice)
            {
                Console.WriteLine("Draw", numplayerschoice);
                return;
            }

            if (array_sides == true)
            {
                if (numplayerschoice > pc_choice && numplayerschoice <= pc_choice + args.Length / 2)
                {
                    Console.WriteLine("PC win!");
                    return;
                }
                else
                {
                    Console.WriteLine("Player win!");
                    return;
                }
            }
            else
            {
                if (numplayerschoice < pc_choice && numplayerschoice >= pc_choice - args.Length / 2)
                {
                    Console.WriteLine("Player win!");
                    return;
                }
                else
                {
                    Console.WriteLine("PC win!");
                    return;
                }
            }
        }
    }
}
