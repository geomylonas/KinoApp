using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class NumberOfGamblers
    {
        public List<Gambler> Gamblers {get;set;}
        public int NumberOfPlayers { get; set; }

        public NumberOfGamblers()
        {
            Gamblers = new List<Gambler>();
        }

        public void PopulateGamblers()
        {
            Gambler gambler;
            Random kinoRandom = new Random();
            Random randomNumber = new Random();
            Console.WriteLine("Enter the number of players participating in the draw");
            bool isInt = int.TryParse(Console.ReadLine(), out int numberOfPlayers);

            for (int i = 0; i < numberOfPlayers; i++)
            {   
                gambler = new Gambler();
                gambler.PopulateRandomChoices(kinoRandom, randomNumber);
                foreach (var item in gambler.GamblerChoices)
                {
                    Console.Write(item + "\t");
                }
                Gamblers.Add(gambler);
            }

            //foreach (var item in Gamblers)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
