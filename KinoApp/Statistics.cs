﻿using System;
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
            NumberFrequency = new int [80]; // Array default Initialization that consists of 80 elements, this Array calculates how many times each number has been drawn
            KinoBonusFrequency = new int [80]; // Array default Initialization that consists of 80 elements, this Array calculates how many times each number has been drawn as Kino Bonus
        }


        public void FindNumberFrequency()
        {
            foreach (var kinoDraw in ListOfKinoDraws)
            {
                for (int i = 0; i < kinoDraw.Numbers.Length; i++)
                {
                    NumberFrequency[kinoDraw.Numbers[i]-1] ++; // for each number found in Array Numbers, add 1 in NumberFrequency's corresponding element
                }
                    KinoBonusFrequency[kinoDraw.Numbers[kinoDraw.Numbers.Length-1]-1] ++; // for each element in Array Numbers, add 1 in KinoBonusFrequency's corresponding element
            }
        }

        // Calculates the 3 most appeared numbers using the Array Method Max() on a Copy NumberFrequency Array
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
                Console.Write(index + 1 + "\t");
                maxFrequency[index] = 0;
            }
        }


        // Calculates the 3 most least numbers not including elements == 0 using the Array Method Min() on a Copy NumberFrequency Array
        public void FindMin()
        {
            int[] minFrequency = new int[80];
            Array.Copy(NumberFrequency, minFrequency, 80);
            int index;
            int maxNumber;
            Console.WriteLine("\nThe 3 least appeared numbers are:");
            for (int i = 0; i < 3; i++)
            {
                int minNotZero = minFrequency.Where(x => x != 0).DefaultIfEmpty().Min(); // filters out the 0 values
                maxNumber = minFrequency.Max();
                index = Array.IndexOf(minFrequency, minNotZero);
                Console.Write(index + 1 + "\t");
                minFrequency[index] = maxNumber;
            }
        }
        public void MinMaxKinoBonus()
        {
            int minNotZero = KinoBonusFrequency.Where(x => x != 0).DefaultIfEmpty().Min(); // filters out the 0 values
            int indexMin = Array.IndexOf(KinoBonusFrequency, minNotZero);
            int indexMax = Array.IndexOf(KinoBonusFrequency, KinoBonusFrequency.Max()); 
            Console.WriteLine($"\nKino Bonus most appeard number is: {indexMax + 1}");
            Console.WriteLine($"\nKino Bonus least appeard number is: {indexMin + 1}");
         
            
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
