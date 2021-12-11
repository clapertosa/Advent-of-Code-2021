using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_7
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
            int[] parse = input[0].Split(',').Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = 0; i < parse.Max(); i++)
            {
                numbers.Add(0);
                foreach (var n in parse)
                {
                    numbers[i] += Math.Abs(i - n);
                }
            }

            return numbers.Min();
        }

        static int PartTwo()
        {
            int[] parse = input[0].Split(',').Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = 0; i < parse.Max(); i++)
            {
                numbers.Add(0);
                foreach (var n in parse)
                {
                    int steps = 0;
                    for (int j = 0; j < Math.Abs(n - i); j++)
                    {
                        steps += j + 1;
                    }

                    numbers[i] += steps;
                }
            }

            return numbers.Min();
        }
    }
}