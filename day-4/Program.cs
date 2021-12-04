using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_4
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

        static List<string[,]> GetBoards()
        {
            List<string[,]> boards = new List<string[,]>();
            string[] newInput = input.Select(x => x).ToArray();
            newInput[0] = "";
            string[] numbers = string.Join(" ", newInput).Trim().Replace("   ", " ").Replace("  ", " ").Split(' ');
            int numbersIndex = 0;
            for (int boardNumber = 0; boardNumber < numbers.Length / 25; boardNumber++)
            {
                boards.Add(new string[5, 5]);
                for (int row = 0; row < 5; row++)
                {
                    for (int column = 0; column < 5; column++)
                    {
                        boards[boardNumber][row, column] = numbers[numbersIndex];
                        numbersIndex++;
                    }
                }
            }

            return boards;
        }


        static int PartOne()
        {
            string[] drawnNumbers = input[0].Split(',');
            List<string[,]> boards = GetBoards();
            List<string> currentDrawnNumbers = new List<string>();
            int? winningBoardIndex = null;

            foreach (string drawnNumber in drawnNumbers)
            {
                if (winningBoardIndex.HasValue == false)
                {
                    currentDrawnNumbers.Add(drawnNumber);
                    for (int i = 0; i < boards.Count; i++)
                    {
                        for (int row = 0; row < boards[i].GetLength(0); row++)
                        {
                            string[] rowNumbers = new string[5];
                            string[] columnNumbers = new string[5];
                            for (int column = 0; column < boards[i].GetLength(1); column++)
                            {
                                rowNumbers[column] = boards[i][row, column];
                                columnNumbers[column] = boards[i][column, row];
                            }

                            if (rowNumbers.All(x => currentDrawnNumbers.Contains(x)) ||
                                columnNumbers.All(x => currentDrawnNumbers.Contains(x)))
                            {
                                winningBoardIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

            List<int> boardNumbers = new List<int>();

            for (int row = 0; row < boards[winningBoardIndex.Value].GetLength(0); row++)
            {
                for (int column = 0; column < boards[winningBoardIndex.Value].GetLength(1); column++)
                {
                    boardNumbers.Add(int.Parse(boards[winningBoardIndex.Value][row, column]));
                }
            }

            return boardNumbers.Where(x => !currentDrawnNumbers.Select(int.Parse).Contains(x)).Sum() *
                   int.Parse(currentDrawnNumbers.Last());
        }

        static int PartTwo()
        {
            string[] drawnNumbers = input[0].Split(',');
            List<string[,]> boards = GetBoards();
            List<string> currentDrawnNumbers = new List<string>();
            List<int> winnerBoardsIndexes = new List<int>();

            foreach (string drawnNumber in drawnNumbers)
            {
                if (winnerBoardsIndexes.Count < boards.Count)
                {
                    currentDrawnNumbers.Add(drawnNumber);
                    for (int i = 0; i < boards.Count; i++)
                    {
                        for (int row = 0; row < boards[i].GetLength(0); row++)
                        {
                            string[] rowNumbers = new string[5];
                            string[] columnNumbers = new string[5];
                            for (int column = 0; column < boards[i].GetLength(1); column++)
                            {
                                rowNumbers[column] = boards[i][row, column];
                                columnNumbers[column] = boards[i][column, row];
                            }

                            if (rowNumbers.All(x => currentDrawnNumbers.Contains(x)) ||
                                columnNumbers.All(x => currentDrawnNumbers.Contains(x)))
                            {
                                winnerBoardsIndexes.Add(i);
                            }

                            winnerBoardsIndexes = new List<int>(winnerBoardsIndexes.Distinct());
                            if (boards.Count <= winnerBoardsIndexes.Count()) break;
                        }
                    }
                }
            }

            List<int> boardNumbers = new List<int>();

            for (int row = 0; row < boards[winnerBoardsIndexes.Last()].GetLength(0); row++)
            {
                for (int column = 0; column < boards[winnerBoardsIndexes.Last()].GetLength(1); column++)
                {
                    boardNumbers.Add(int.Parse(boards[winnerBoardsIndexes.Last()][row, column]));
                }
            }

            return boardNumbers.Where(x => !currentDrawnNumbers.Select(int.Parse).Contains(x)).Sum() *
                   int.Parse(currentDrawnNumbers.Last());
        }
    }
}