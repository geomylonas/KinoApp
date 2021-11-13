using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class KinoDraw
    {
        public int[] Numbers { get; set; }


        public KinoDraw()
        {
            Numbers = new int[12];
        }

        int counter = 0;
        public int DrawNumbers()
        {
            do
            {
                int newNumber = GenerateNumber();
                if (Numbers.Contains(newNumber))
                {
                    continue;
                }
                else
                {
                    Numbers[counter++] = newNumber;         
                }
            } while (counter < Numbers.Length);
            return 1;
        }

       


    
    

        
        public int GenerateNumber() 
        {

            Random random = new Random();
            return random.Next(1, 81);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(int a in Numbers)
            {
                sb.Append($"{a}\t");
            }
            return sb.ToString();
        }
    }


    
}
