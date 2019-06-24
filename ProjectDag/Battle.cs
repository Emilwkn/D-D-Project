using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDag
{
    class Battle
    {
        public static void StartBattle(Hero hero, Monster monster)
        {
            while(true)
            {
                if(GetAttackResult(hero, monster) == "Battle Over")
                {
                    Console.WriteLine("Battle Over");
                    break;
                }
                if (GetAttackResult(monster, hero) == "Battle Over")
                {
                    Console.WriteLine("Battle Over");
                    break;
                }
            }
        }

        public static string GetAttackResult
            (Hero charA, Monster charB)
        {
            Random rnd = new Random();
            double charAAttkAmt = charA.Atk();
            double charARoll = rnd.Next(1,20);
            double charBEVAAmt = charB.Evade();

            double dmg = charAAttkAmt;

            if (charARoll > charBEVAAmt)
            {
                charB.HP = charB.HP - dmg;
            }
            else dmg = 0;

            Console.WriteLine("{0} Attcks {1} and Deals {2} Damage",
                charA.Name,
                charB.Name,
                dmg);

            Console.WriteLine("{0} Has {1} Health" +
                "\n",
                charB.Name,
                charB.HP);

            if (charB.HP <= 0)
            {
                Console.WriteLine("{0} Has Perished",
                    charB.Name);
                return "Battle Over";
            }
            else return "";
        }
    }
}
