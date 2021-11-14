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


        public Game()
        {

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

                Console.WriteLine($"Gambler has matched {NumbersFoundPerPlayer[gambler].Count} numbers!");
                if (gambler.Kinobonus)
                {
                    CheckKinoBonus(gambler);
                }
            }
            
        }

    }
}
