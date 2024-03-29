﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDag
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player
            Hero hero = new Hero
                ("Jack", 100, 10, 8, 20, 0);

            //Monsters
            //Floor1
            Monster gob = new Monster
                ("Goblin", 20, 5, 3, 0, 10);
            Monster gobShaman = new Monster
                ("GoblinShaman", 15, 2, 0, 10, 15);
            //Floor2
            Monster skeleton = new Monster
                ("Skeleton", 40, 10, 5, 10, 25);
            Monster skeletonMage = new Monster
                ("Bone-Magi", 30, 5, 5, 20, 30);
            Monster boneKnight = new Monster
                ("Bone-Knight", 60, 15, 3, 15, 40);

            //Boss'
            //floor1
            Boss gobBoss = new Boss
                ("Goblin King", 75, 5, 10, 2, 0, 50);
            //floor2
            Boss lich = new Boss
                ("Lich", 100, 5, 10, 7, 50, 120);


            //Spells
            //Hero
            Spell HeavyFall = new Spell
                ("Heavy Fall", "Offense", 5, 2,
                "Bring down your weapon in one big motion attempting to sever the enemy in twain" +
                ": dealing 200% dmg.");
            //Hero and goblin shaman
            Spell LesserHeal = new Spell
                ("Lesser Heal", "Support", 5, 0.2,
                "Say a prayer to a higher power and receive a boon of mending" +
                ": heal 20% of target's max Health.");
            //skeleton, bone-knight
            Spell rattleStrike = new Spell
                ("Rattle Strike", "Offense", 5, 1.2,
                "Strike your foe with a bone ratteling attack, weakening them for a moment" + 
                ": dealing 120% dmg, targets next Offensive action -20%.");
            //lich, hero
            Spell firebolt = new Spell
                ("FireBolt", "Offense", 5, 1,
                "Conjure a bolt of flames and send it hurling at an unfortunate soul" + 
                ": dealing 100% magicdmg.");
            //lich
            Spell deathTouch = new Spell
                ("Death touch", "Offense", 15, 3,
                "Drain the soul of the living, revitalising the casters body and leave the target in agonizing pain" + 
                ": dealing 300% magicdmg and heal for 5% of the dmg dealt.");


            //Characterstats - Player
            string playerCharacter = "Player";
            int playerHP = 100;
            int playerAttack = 10;
            int playerEvade = 8;
            int PlayerEXP = 0;


            //Characterstats - Goblin
            string enemyCharacter = "Goblin";
            int GoblinHP = 20;
            int GoblinAttack = 5;
            int GoblinEvade = 3;
            int EXPGoblin = 10;

            //Charecterstats - Goblin Shaman
            string enemyGoblinShaman = "Goblin Shaman";
            int GoblinShamanHP = 15;
            int GoblinShamanATK = 2;
            int GoblinShamanEvade = 0;
            int EXPGoblinShaman = 15;


            //Characterstats - Boss
            string bossCharacter = "Goblin-King";
            int bossHP = 75;
            Random boss = new Random();
            int bossAttack; //(Random 5-10)
            int bossEvade = 2;
            int EXPBoss = 50;

            Random rand = new Random();

            int atk;
            int floorRand;
            int trapHit;
            int treasureRole;
            int itemRole;

            bool system = true;
            bool bossCombat = true;

            int floor = 0;

            while (system)
            {
                while (floor <= 4)
                {
                    floor++;
                    Console.WriteLine("You arrive at floor {0}.", floor);
                    floorRand = rand.Next(1, 11);
                    if (floorRand <= 4)
                    {
                        Console.WriteLine("There is a {0}, Time to fight!", enemyCharacter);
                        Console.ReadKey();

                        //Combat system
                        while (true)
                        {
                            Console.WriteLine("Attack");
                            atk = rand.Next(0, 11);
                            if (atk > GoblinEvade)
                            {
                                Console.WriteLine("Hit!\n");
                                GoblinHP -= playerAttack;
                            }
                            if (atk == 10)
                            {
                                Console.WriteLine("Critical Hit!!!\n");
                                GoblinHP = GoblinHP - (playerAttack * 2);
                            }
                            if (atk <= GoblinEvade)
                            {
                                Console.WriteLine("Miss.\n");
                            }
                            else if (GoblinHP <= 0)
                            {
                                Console.WriteLine("The monster has been defeated!\n");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("The Monster attacks.");
                            atk = rand.Next(1, 10);
                            if (atk <= playerEvade)
                            {
                                Console.WriteLine("It missed. pheew\n");
                            }
                            if (atk > playerEvade)
                            {
                                Console.WriteLine("It hit. ouch\n");
                                playerHP -= GoblinAttack;
                            }
                            if (atk == 10)
                            {
                                Console.WriteLine("A CRITICAL HIT! ARRGH\n");
                                playerHP = playerHP - (GoblinAttack * 2);
                            }
                            if (playerHP <= 0)
                            {
                                Console.WriteLine("You Died.\n");
                                Console.Write("Do you wanna try again? (y/n)");
                                string exit = Console.ReadLine();
                                if (exit == "y")
                                {
                                    break;
                                }
                                if (exit == "n")
                                {
                                    system = false;
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        itemRole = rand.Next(1,21);
                        if (itemRole <= 12)
                        {
                            
                        }
                        if (itemRole <= 17 && itemRole > 12)
                        {
                            Console.WriteLine("The {0} had a potion of minor health.\n+ 3 HP", enemyCharacter);
                            playerHP += 3;
                        }
                        else if (itemRole < 17)
                        {
                            Console.WriteLine("The {0} had a winged amulet.\n+ 1 AGI", enemyCharacter);
                            playerEvade += 1;
                        }
                    }
                    if (floorRand > 4 && floorRand <= 7)
                    {
                        Console.WriteLine("It's empty. How boring");
                        Console.ReadKey();
                        itemRole = rand.Next(1, 21);
                        if (itemRole <= 12)
                        {
                            
                        }
                        if (itemRole <= 17 && itemRole > 12)
                        {
                            Console.WriteLine("You spot a small box under some cloth, it contains a potion of minor health\n+ 3 HP");
                            playerHP += 3;
                        }
                        else if (itemRole < 17)
                        {
                            Console.WriteLine("You spot a corpse skeleton behind some boxes, he is wearing a winged amulet\n+ 1 AGI");
                            playerEvade += 1;
                        }
                    }
                    if (floorRand > 7 && floorRand <= 9)
                    {
                        Console.WriteLine("It's a trap!");
                        trapHit = rand.Next(0, 7);
                        if (trapHit > playerEvade)
                        {
                            Console.WriteLine("Ouch that hurts");
                            playerHP -= 2;
                        }
                        if (trapHit <= playerEvade)
                        {
                            Console.WriteLine("You skilfully avoid the trap. 'to easy'");
                        }
                        Console.ReadKey();
                        itemRole = rand.Next(1, 21);
                        if (itemRole <= 12)
                        {
                            
                        }
                        if (itemRole <= 17 && itemRole > 12)
                        {
                            Console.WriteLine("You spot something glimting behind a rock, potion of minor health, lucky!\n+ 3 HP");
                            playerHP += 3;
                        }
                        else if (itemRole < 17)
                        {
                            Console.WriteLine("There is a Winged amulet stuck in a branch by the exit\n+ 1 AGI");
                            playerEvade += 1;
                        }
                    }
                    if (floorRand == 10)
                    {
                        Console.WriteLine("Treasure chest, wuup wuup.");
                        Console.ReadKey();
                        treasureRole = rand.Next(1,4);
                        if (treasureRole == 1)
                        {
                            Console.WriteLine("You got an enchanted ring");
                            Console.WriteLine("+ 3 ATK");
                            playerAttack += 3;
                        }
                        if (treasureRole == 2)
                        {
                            Console.WriteLine("You got a set of wind boots");
                            Console.WriteLine("+ 2 AGI");
                            playerEvade += 2;
                        }
                        if (treasureRole == 3)
                        {
                            Console.WriteLine("You got a steel chainmail");
                            Console.WriteLine("+ 5 HP");
                            playerHP += 5;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine(playerCharacter);
                    Console.WriteLine("HP: {0}",playerHP);
                    Console.WriteLine("ATK: {0}",playerAttack);
                    Console.WriteLine("AGI: {0}",playerEvade);
                    Console.ReadKey();
                    Console.Clear();
                }

                Console.WriteLine("You enter a room with a big fat goblin sitting on a trone, it's boss time");
                while (floor == 5)
                {
                    //Combat System
                    while (bossCombat)
                    {
                        Console.WriteLine("Attack");
                        atk = rand.Next(0, 11);
                        if (atk > bossEvade)
                        {
                            Console.WriteLine("Hit!\n");
                            bossHP -= playerAttack;
                        }
                        if (atk == 10)
                        {
                            Console.WriteLine("Critical Hit!!!\n");
                            bossHP = bossHP - (playerAttack * 2);
                        }
                        if (atk < bossEvade)
                        {
                            Console.WriteLine("Miss.\n");
                        }
                        else if (bossHP <= 0)
                        {
                            Console.WriteLine("The monster has been defeated!\n");
                            Console.ReadKey();
                            bossCombat = false;
                        }
                        Console.WriteLine("The Monster attacks.");
                        atk = rand.Next(1, 10);
                        if (atk <= playerEvade)
                        {
                            Console.WriteLine("It missed. pheew\n");
                        }
                        if (atk > playerEvade)
                        {
                            bossAttack = boss.Next(4, 9);
                            Console.WriteLine("It hit. ouch\n");
                            playerHP -= bossAttack;
                        }
                        if (atk == 10)
                        {
                            bossAttack = boss.Next(4,9);
                            Console.WriteLine("A CRITICAL HIT! ARRGH\n");
                            playerHP = playerHP - (bossAttack * 2);
                        }
                        if (playerHP <= 0)
                        {
                            Console.WriteLine("You Died.\n");
                            Console.Write("Do you wanna try again? (y/n)");
                            string exit = Console.ReadLine();
                            if (exit == "y")
                            {
                                break;
                            }
                            if (exit == "n")
                            {
                                system = false;
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        Console.WriteLine(bossCharacter);
                        Console.WriteLine("HP: {0}", bossHP);
                    }
                    break;
                }
            }

            Console.WriteLine("Goodbye.");
            Console.ReadKey();
        }
    }
}
