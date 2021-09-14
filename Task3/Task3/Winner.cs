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

        public static string FinalResultFirstCase(int players_choice, int pc_choice, string[] args)
        {
            if (players_choice > pc_choice && players_choice <= pc_choice + args.Length / 2)
            {
                return "WIN";
            }
            else
            {
                return "LOSE";
            }
        }

        public static string FinalResultSecondCase(int players_choice, int pc_choice, string[] args)
        {
            if (players_choice < pc_choice && players_choice >= pc_choice - args.Length / 2)
            {
                return "LOSE";
            }
            else
            {
                return "WIN";
            }
        }

        public static string CheckingResults(string[] args, int pc_choice, int players_choice, bool array_sides)
        {
            int npc = 0;
            for (int i = 0; i < args.Length; i++)
                if (players_choice == i)
                {
                    npc = i;
                    break;
                }

            if (pc_choice == npc)
            {
                Console.WriteLine("DRAW", npc);
                return "DRAW";
            }

            if (array_sides == true)
            {
                return FinalResultFirstCase(players_choice, pc_choice, args);
            }
            else
            {
                return FinalResultSecondCase(players_choice, pc_choice, args);
            }
        }
    }
}
