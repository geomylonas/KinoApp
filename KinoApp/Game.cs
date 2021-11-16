using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class Game
    {
        public Gambler Gambler { get; set; }
        public KinoDraw KinoDraw { get; set; }

        public Dictionary<Gambler,List<int>> NumbersFoundPerPlayer { get; set; }
        public List<Gambler>[] WinnersCategory { get; set; }


        public Game()
        {
            WinnersCategory = new List<Gambler>[13];
            for (int i = 0; i < WinnersCategory.Length; i++)
            {
                WinnersCategory[i] = new List<Gambler>();
            }
            Gambler = new Gambler();
            KinoDraw = new KinoDraw();
            NumbersFoundPerPlayer = new Dictionary<Gambler,List<int>>();
        }
        //public Game(Gambler gambler, KinoDraw kinoDraw)
        //{
        //    Gambler = gambler;
        //    KinoDraw = kinoDraw;
        //    NumbersFound = new List<int>();
        //}

        public Dictionary<Gambler,List<int>> CheckNumbers(Gambler gambler)
        {
            List<int> listOfSuccesses = new List<int>();
            foreach (int numberPlayed in gambler.GamblerChoices)
            {
                if (KinoDraw.Numbers.Contains(numberPlayed))
                {
                    listOfSuccesses.Add(numberPlayed);
                }
            }
            NumbersFoundPerPlayer.Add(gambler, listOfSuccesses);
            return NumbersFoundPerPlayer;
        }

        public bool CheckKinoBonus(Gambler gambler)
        {
            if (NumbersFoundPerPlayer[gambler].Contains(KinoDraw.Numbers[KinoDraw.Numbers.Length - 1]))
            {
                Console.WriteLine("You matched KINO BONUS!!!");
                return true;
            }
            else
            {
                Console.WriteLine("You didnt match KINO BONUS! Maybe next time!!!");
                return false;
            }
        }

        public void PlayGame()
        {
            NumberOfGamblers numberOfGamblers = new NumberOfGamblers();
            numberOfGamblers.PopulateGamblers();
            KinoDraw.DrawNumbers();
            Console.WriteLine(KinoDraw.ToString());
            foreach (var gambler in numberOfGamblers.Gamblers)
            {
                CheckNumbers(gambler);
                int numbersFound = NumbersFoundPerPlayer[gambler].Count;

                Console.WriteLine($"Gambler number {gambler.GamblerID} has matched {numbersFound} numbers!");
                int index = (numbersFound * 2 - 1 > 0 ? numbersFound * 2 - 1 : 0);
                if (gambler.Kinobonus)
                {
                    CheckKinoBonus(gambler);
                    if (CheckKinoBonus(gambler))
                    {
                        WinnersCategory[numbersFound * 2].Add(gambler);
                    }
                    else
                    {                       
                        WinnersCategory[index].Add(gambler);  
                    }
                }
                else
                {                    
                    WinnersCategory[index].Add(gambler);
                }               
            }


            for (int i = 0; i < WinnersCategory.Length; i++)
            {
                if (i % 2 != 0 || i == 0)
                {
                    Console.WriteLine($"There are {WinnersCategory[i].Count} players that found {(i + 1) / 2} out of the 6 numbers");
                }
                else
                {
                    Console.WriteLine($"There are {WinnersCategory[i].Count} players that found {i / 2} out of the 6 numbers plus Kino Bonus");
                }
            }

           

        }

    }
}
