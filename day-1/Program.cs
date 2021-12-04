using System;
using System.IO;

namespace day_1
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
            int result = 0;
            int temp = 0;
            foreach (string line in input)
            {
                int value = int.Parse(line);
                if (value > temp && temp > 0) result++;
                temp = value;
            }

            return result;
        }

        static int PartTwo()
        {
            int result = 0;
            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int value = 0;
                if (i + 3 < input.Length)
                {
                    value = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
                    if (value > temp) result++;
                }

                temp = value;
            }

            return result;
        }
    }
}