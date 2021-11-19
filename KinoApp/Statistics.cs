using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoApp
{
    class Statistics
    {
        public List<KinoDraw> ListOfKinoDraws { get; set; }
        public int[] NumberFrequency { get; set; }
        public int[] KinoBonusFrequency { get; set; }

        public Statistics(List<KinoDraw> listOfKinoDraws){
            ListOfKinoDraws = listOfKinoDraws;
            NumberFrequency = new int [80];
            KinoBonusFrequency = new int [80];
        }

        public void FindNumberFrequency()
        {
            foreach (var kinoDraw in ListOfKinoDraws)
            {
                for (int i = 0; i < kinoDraw.Numbers.Length; i++)
                {
                    NumberFrequency[kinoDraw.Numbers[i]-1] ++;
                    KinoBonusFrequency[kinoDraw.Numbers[kinoDraw.Numbers.Length-1]-1] ++;
                }
            }
        }
        public void FindMax()
        {
            int[] maxFrequency = new int [80];
            Array.Copy(NumberFrequency, maxFrequency, 80);
            int number;
            int index;
            Console.WriteLine("The 3 most appeared numbers are:");
            for (int i = 0; i < 3; i++)
            {
                number = maxFrequency.Max();
                index = Array.IndexOf(maxFrequency, number);
                Console.Write(number + "\t");
                maxFrequency[index] = 0;
            }
        }
        public void FindMin()
        {
            int[] minFrequency = new int[80];
            Array.Copy(NumberFrequency, minFrequency, 80);
            int number;
            int index;
            int maxNumber;
            Console.WriteLine("The 3 most appeared numbers are:");
            for (int i = 0; i < 3; i++)
            {
                number = minFrequency.Min();
                index = Array.IndexOf(minFrequency, number);
                maxNumber = minFrequency.Max();
                Console.Write(number + "\t");
                minFrequency[index] = maxNumber;
            }
        }
        public void MinMaxKinoBonus()
        {
            Console.WriteLine($"Kino Bonus least appeard number is: {KinoBonusFrequency.Min()}");
            Console.WriteLine($"Kino Bonus most appeard number is: {KinoBonusFrequency.Max()}");
        }
        public void GenerateStatistics()
        {
            FindNumberFrequency();
            FindMax();
            FindMin();
            MinMaxKinoBonus();
        }
    }
}
