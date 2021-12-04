using System;
using System.IO;
using System.Linq;

namespace day_2
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

        private class Direction
        {
            public string Instruction { get; set; }
            public int Value { get; set; }
        }

        static int PartOne()
        {
            Direction[] instructions = input.Select(x => x.Split(' '))
                .Select(x => new Direction {Instruction = x[0], Value = int.Parse(x[1])}).ToArray();
            int horizontal = 0;
            int depth = 0;
            foreach (var item in instructions)
            {
                switch (item.Instruction)
                {
                    case "forward":
                        horizontal += item.Value;
                        break;
                    case "up":
                        depth -= item.Value;
                        break;
                    case "down":
                        depth += item.Value;
                        break;
                    default: continue;
                }
            }

            return horizontal * depth;
        }

        static int PartTwo()
        {
            Direction[] instructions = input.Select(x => x.Split(' '))
                .Select(x => new Direction {Instruction = x[0], Value = int.Parse(x[1])}).ToArray();
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (var item in instructions)
            {
                switch (item.Instruction)
                {
                    case "forward":
                    {
                        horizontal += item.Value;
                        depth += aim * item.Value;
                    }
                        break;
                    case "up":
                        aim -= item.Value;
                        break;
                    case "down":
                        aim += item.Value;
                        break;
                    default: continue;
                }
            }

            return horizontal * depth;
        }
    }
}