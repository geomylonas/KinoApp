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

        public List<int> NumbersFound { get; set; }


        public Game()
        {

            Gambler = new Gambler();
            KinoDraw = new KinoDraw();
            NumbersFound = new List<int>();
        }
        public Game(Gambler gambler, KinoDraw kinoDraw)
        {
            Gambler = gambler;
            KinoDraw = kinoDraw;
            NumbersFound = new List<int>();
        }

        
        public List<int> CheckNumbers()
        {
            foreach (int numberPlayed in Gambler.GamblerChoices)
            {
                if (KinoDraw.Numbers.Contains(numberPlayed))
                {
                    NumbersFound.Add(numberPlayed);
                }
            }
            return NumbersFound;
        }

        public bool CheckKinoBonus()
        {
            if (NumbersFound.Contains(KinoDraw.Numbers[KinoDraw.Numbers.Length - 1]))
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
            KinoDraw.DrawNumbers();
            Console.WriteLine(KinoDraw.ToString());
            Gambler.PopulateChoices();
            CheckNumbers();
            
            Console.WriteLine($"Gambler has matched {NumbersFound.Count} numbers!");
            if (Gambler.Kinobonus)
            {
                CheckKinoBonus();
            }


        }

            

    }
}
