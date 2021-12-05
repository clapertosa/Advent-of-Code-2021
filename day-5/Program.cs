using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_5
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

        private class Coordinate
        {
            public int X1 { get; set; }
            public int Y1 { get; set; }
            public int X2 { get; set; }
            public int Y2 { get; set; }
        }

        static List<Coordinate> ParseCoordinates()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            foreach (string line in input)
            {
                int[] startingCoordinates =
                    line.Split(" -> ")[0].Split(" -> ")[0].Split(',').Select(int.Parse).ToArray();
                int[] endingCoordinates =
                    line.Split(" -> ")[1].Split(" -> ")[0].Split(',').Select(int.Parse).ToArray();
                coordinates.Add(
                    new Coordinate
                    {
                        X1 = startingCoordinates[0],
                        Y1 = startingCoordinates[1],
                        X2 = endingCoordinates[0],
                        Y2 = endingCoordinates[1]
                    }
                );
            }

            return coordinates;
        }

        static int PartOne()
        {
            List<Coordinate> coordinates = ParseCoordinates();
            int result = 0;

            int maxX1Coordinate = coordinates.Select(x => x.X1).Distinct().Max();
            int maxX2Coordinate = coordinates.Select(x => x.X2).Distinct().Max();
            int maxY1Coordinate = coordinates.Select(x => x.Y1).Distinct().Max();
            int maxY2Coordinate = coordinates.Select(x => x.Y2).Distinct().Max();
            int[,] grid = new int[
                Math.Max(maxX1Coordinate, maxX2Coordinate) + 2,
                Math.Max(maxY1Coordinate, maxY2Coordinate) + 2];

            foreach (Coordinate coordinate in coordinates)
            {
                if (coordinate.X1 == coordinate.X2)
                {
                    for (int i = Math.Min(coordinate.Y1, coordinate.Y2);
                        i <= Math.Max(coordinate.Y1, coordinate.Y2);
                        i++)
                    {
                        grid[i, coordinate.X1] += 1;
                    }
                }
                else if (coordinate.Y1 == coordinate.Y2)
                {
                    for (int i = Math.Min(coordinate.X1, coordinate.X2);
                        i <= Math.Max(coordinate.X1, coordinate.X2);
                        i++)
                    {
                        grid[coordinate.Y1, i] += 1;
                    }
                }
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    result += grid[i, j] > 1 ? 1 : 0;
                }
            }

            return result;
        }

        static int PartTwo()
        {
            List<Coordinate> coordinates = ParseCoordinates();
            int result = 0;

            int maxX1Coordinate = coordinates.Select(x => x.X1).Distinct().Max();
            int maxX2Coordinate = coordinates.Select(x => x.X2).Distinct().Max();
            int maxY1Coordinate = coordinates.Select(x => x.Y1).Distinct().Max();
            int maxY2Coordinate = coordinates.Select(x => x.Y2).Distinct().Max();
            int[,] grid = new int[
                Math.Max(maxX1Coordinate, maxX2Coordinate) + 2,
                Math.Max(maxY1Coordinate, maxY2Coordinate) + 2];

            List<int> newXCoordinates = new List<int>();
            List<int> newYCoordinates = new List<int>();


            foreach (Coordinate coordinate in coordinates)
            {
                int maxDiff = Math.Max(Math.Abs(coordinate.X1 - coordinate.X2),
                    Math.Abs(coordinate.Y1 - coordinate.Y2));

                for (int i = 0; i <= maxDiff; i++)
                {
                    if (coordinate.X1 == coordinate.X2) newXCoordinates.Add(coordinate.X1);
                    else if (coordinate.X1 < coordinate.X2) newXCoordinates.Add(coordinate.X1 + i);
                    else newXCoordinates.Add(coordinate.X1 - i);

                    if (coordinate.Y1 == coordinate.Y2) newYCoordinates.Add(coordinate.Y1);
                    else if (coordinate.Y1 < coordinate.Y2) newYCoordinates.Add(coordinate.Y1 + i);
                    else newYCoordinates.Add(coordinate.Y1 - i);
                }
            }

            // Merge coordinates
            List<int[]> newCoordinates = newXCoordinates.Select((t, i) => new[] {t, newYCoordinates[i]}).ToList();

            foreach (int[] coordinate in newCoordinates)
            {
                grid[coordinate[0], coordinate[1]] += 1;
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    result += grid[i, j] > 1 ? 1 : 0;
                }
            }

            return result;
        }
    }
}