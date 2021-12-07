using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_6
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
            List<int> numbers = input[0].Split(',').Select(int.Parse).ToList();

            int days = 80;
            while (days > 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > 0) numbers[i] -= 1;
                    else if (numbers[i] == 0)
                    {
                        numbers[i] = 6;
                        numbers.Add(8 + 1);
                    }
                }

                days--;
            }

            return numbers.Count;
        }

        static long PartTwo()
        {
            List<int> numbers = input[0].Split(',').Select(int.Parse).ToList();
            Dictionary<int, long> fish = new Dictionary<int, long>
                {{0, 0}, {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}};

            int days = 256;

            foreach (var n in numbers)
            {
                fish[n] += 1;
            }

            while (days > 0)
            {
                long fishZero = fish[0];
                for (int i = 0; i < fish.Count - 1; i++)
                {
                    fish[i] = fish[i + 1];
                }

                fish[8] = fishZero;
                fish[6] += fishZero;
                days--;
            }

            return fish.Select(x => x.Value).Sum();
        }
    }
}