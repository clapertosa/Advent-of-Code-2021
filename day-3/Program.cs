using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_3
{
    class Program
    {
        private static string[] input;

        static void Main(string[] args)
        {
            input = File.ReadAllLines("./input.txt");
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }

        static int PartOne()
        {
            string max = "";
            string min = "";
            for (int i = 0; i < input[0].Length; i++)
            {
                int zeroCounter = 0;
                int oneCounter = 0;
                foreach (string t in input)
                {
                    if (int.Parse(t[i].ToString()) == 0) zeroCounter++;
                    else oneCounter++;
                }

                if (zeroCounter > oneCounter)
                {
                    max += 0;
                    min += 1;
                }
                else
                {
                    max += 1;
                    min += 0;
                }
            }

            return Convert.ToInt32(max, 2) * Convert.ToInt32(min, 2);
        }

        static int PartTwo()
        {
            List<string> zero = input.Where(x => x[0] == '0').ToList();
            List<string> one = input.Where(x => x[0] == '1').ToList();

            List<string> oxygen = zero.Count > one.Count ? new List<string>(zero) : new List<string>(one);
            List<string> co2 = zero.Count < one.Count ? new List<string>(zero) : new List<string>(one);

            // Oxygen
            short oxygenIndex = 1;
            while (oxygen.Count > 1)
            {
                List<string> max = new List<string>();
                List<string> min = new List<string>();
                foreach (string o in oxygen)
                {
                    if (o[oxygenIndex] == '0') min.Add(o);
                    else max.Add(o);
                }

                if (max.Count == min.Count) oxygen = new List<string>(max);
                else if (max.Count > min.Count) oxygen = new List<string>(max);
                else oxygen = new List<string>(min);
                oxygenIndex++;
            }

            // CO2
            short co2Index = 1;
            while (co2.Count > 1)
            {
                List<string> max = new List<string>();
                List<string> min = new List<string>();
                foreach (string c in co2)
                {
                    if (c[co2Index] == '0') min.Add(c);
                    else max.Add(c);
                }

                if (max.Count == min.Count) co2 = new List<string>(min);
                else if (min.Count > max.Count) co2 = new List<string>(max);
                else co2 = new List<string>(min);
                co2Index++;
            }

            return Convert.ToInt32(oxygen[0], 2) * Convert.ToInt32(co2[0], 2);
        }
    }
}