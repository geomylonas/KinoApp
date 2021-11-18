using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class Reward
    {
        public MultipleKinoDraws MultipleKinoDraws { get; set; }
        public double Rewards { get; set; }

        public Reward(MultipleKinoDraws multipleKinoDraws)
        {
            MultipleKinoDraws = multipleKinoDraws;
        }

       
    }
}
