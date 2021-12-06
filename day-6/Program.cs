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
                        numbers.Add(8+1);
                    }
                }

                days--;
            }

            return numbers.Count;

        }

        static int PartTwo()
        {
            return 0;
        }
    }
}
