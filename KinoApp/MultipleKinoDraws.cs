﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class MultipleKinoDraws
    {
        List<Game> Games { get; set; }
        SelectionOfGamblers selectionOfGamblers { get; set; }
        public List<KinoDraw> KinoDraws { get; set; }
        private int _numberOfKinoDraws;
        public int NumberOfKinoDraws
        {
            get { return _numberOfKinoDraws; }
            set { _numberOfKinoDraws = value; }
        }

        public MultipleKinoDraws()
        {
            Games = new List<Game>();
            selectionOfGamblers = new SelectionOfGamblers();
            selectionOfGamblers.PopulateGamblers();
            KinoDraws = new List<KinoDraw>();
        }

        public void PlayKino()
        {
            Game game;
            Statistics stats;
            bool isInt;

            do
            {
                Console.WriteLine("\n \nGive number of draws");
                isInt = int.TryParse(Console.ReadLine(), out _numberOfKinoDraws);
            } while (!isInt);
            Game.InsertReward();

            for (int i = 0; i < _numberOfKinoDraws; i++)
            {
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine($"Kino Draw {i+1}");
                game = new Game();
                game.PlayGame(selectionOfGamblers);
                KinoDraws.Add(game.KinoDraw);
                Games.Add(game);
            
            }
            stats = new Statistics(KinoDraws);
            stats.GenerateStatistics();

        }







    }
}
