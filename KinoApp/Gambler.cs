﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class Gambler
    {
        public int[] GamblerChoices { get; set; }
        public bool Kinobonus { get; set; }

        public Gambler()
        {
            GamblerChoices = new int[6];
        }

        public void PopulateChoices()
        {
            bool isInt;
            int newNumber;
            string choice = PlayKinoBonus();



            for (int i = 0; i < GamblerChoices.Length; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine("You have entered these numbers");
                    for (int a = 0; a < i; a++)
                    {
                        Console.Write(GamblerChoices[a] + "\t");
                    }
                }

                Console.WriteLine($"\nGive {i + 1} number");
                isInt = false;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out newNumber);
                    if (!isInt || newNumber < 1 || newNumber > 80)
                    {
                        Console.WriteLine("Give a valid number (1-80)");
                    }
                } while (!isInt || newNumber < 1 || newNumber > 80);

                if (GamblerChoices.Contains(newNumber))
                {
                    i--;
                    continue;

                }
                else
                {
                    GamblerChoices[i] = newNumber;
                }
            }
        }



        private string PlayKinoBonus()
        {
            string choice;
            do
            {
                Console.WriteLine("Do you want to play kino bonus (Y/N)?");
                choice = Console.ReadLine().ToUpper();


            } while (choice != "Y" && choice != "N");

            if (choice == "Y")
            {
                Kinobonus = true;
            }
            else
            {
                Kinobonus = false;
            }

            return choice;
        }
    }
}