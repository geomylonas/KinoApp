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

        public static double Bonus { get; set; }

        public static double InitialReward { get; set; }
        public double GameReward { get; set; }
        public static double[] RewardPercentages { get; set; }
        public static double Charity { get; set; }

        static Game ()
        {
            Bonus = 0;
            Charity = 0;
            RewardPercentages = new double[12] { 0.2, 0.4, 0.6, 0.8, 1, 2, 3, 5, 7, 15, 23, 35 }; // Array that helps to calculate the Reward Per Winning Category
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public Game()
        {
            
            WinnersCategory = new List<Gambler>[13]; // Array that contains 13 lists with every Category of Matching Numbers (+Kino Bonus) Per Gambler
            for (int i = 0; i < WinnersCategory.Length; i++)
            {
                WinnersCategory[i] = new List<Gambler>(); // Initialization
            }
            Gambler = new Gambler();
            KinoDraw = new KinoDraw();
            NumbersFoundPerPlayer = new Dictionary<Gambler,List<int>>();

            GameReward = InitialReward + Bonus;
            Console.WriteLine($"The total amount distributed for this Draw is: {GameReward.ToString("#.##")}€");
            Charity += CharityReward(); 
        }
        
        public static void InsertReward()
        {
            double initialReward;
            bool isDouble;

            do
            {
                Console.WriteLine("\n \nGive the Reward");
                isDouble = double.TryParse(Console.ReadLine(), out initialReward);
            } while (!isDouble);
            InitialReward = initialReward;
        }


        // Method that Checks how many Numbers a Gambler has matched and returns a Dictionary with the Gambler's successful matches
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

        // Check if Gambler has matched Kino Bonus
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

        public void PlayGame(SelectionOfGamblers selectionOfGamblers)
        {
            KinoDraw.DrawNumbers();
            Console.WriteLine(KinoDraw.ToString());
            foreach (var gambler in selectionOfGamblers.Gamblers)
            {
                CheckNumbers(gambler);
                int numbersFound = NumbersFoundPerPlayer[gambler].Count;

                Console.WriteLine($"Gambler  {gambler.GamblerID} has matched {numbersFound} numbers!");
                int index = (numbersFound * 2 - 1 > 0 ? numbersFound * 2 - 1 : 0);
                if (gambler.Kinobonus)
                {
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

            Bonus = CalculateReward();

        }


        // Method that Calculates the Reward per Winning Category and per Gambler, if there is no Winner then the winning amount adds to the Next Kino Draw Reward
        public double CalculateReward()
        {
            
            double result = 0;
            for (int i = WinnersCategory.Length-1; i > 0; i--)
            {
                if (WinnersCategory[i].Count > 0)
                {
                    double categoryReward = (RewardPercentages[i - 1] / 100 * GameReward);
                    Console.WriteLine($"In category {(i+1) / 2} {(i % 2 == 0 ? '+' : ' ')} the reward is {categoryReward.ToString("#.##")}€");
                    Console.WriteLine($"The reward per player is {(categoryReward/WinnersCategory[i].Count).ToString("#.##")}€");
                }
                else
                {
                    Console.WriteLine($"There was no winner in category {(i+1) / 2} {(i % 2 == 0 ? '+' : ' ')}");
                    result += RewardPercentages[i - 1] / 100 * GameReward;  
                }
                
            }
            return result;
        }

        // Method that calculates the amount of money for Charity
        double CharityReward()
        {
            double result = GameReward * 0.07;
            Console.WriteLine($"The amount of {result.ToString("#.##")}€ goes to Charity!!!");
            return result;
        }
    }
}
