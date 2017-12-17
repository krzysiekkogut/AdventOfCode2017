using System;
using System.Collections.Generic;
using System.IO;
using Shared;
using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        private static IDictionary<string, IPuzzleSolver> _solversDictionary;

        static void Main()
        {
            while (true)
            {
                ClearSolvers();
                WriteLine("Type puzzle number, 'all' or 'exit':");
                try
                {
                    var dayNumber = ReadLine();
                    if (dayNumber.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }

                    WriteLine($"Puzzle    Time [ms]    Solution");

                    if (dayNumber.Equals("all", StringComparison.OrdinalIgnoreCase))
                    {
                        var startTime = DateTime.Now;

                        foreach (var day in _solversDictionary.Keys)
                        {
                            SolvePuzzle(day);
                        }

                        var duration = DateTime.Now - startTime;
                        WriteLine($"All puzzles solved in {duration.TotalMilliseconds}.");
                    }
                    else
                    {
                        SolvePuzzle(dayNumber);
                    }
                }
                catch (Exception e)
                {
                    WriteLine($"Error occured. Message: {e.Message}");
                }
                finally
                {
                    WriteLine();
                }
            }
        }

        private static void ClearSolvers()
        {
            _solversDictionary = new Dictionary<string, IPuzzleSolver>
            {
                ["01"] = new Day01_Captcha.Captcha(true),
                ["01b"] = new Day01_Captcha.Captcha(false),
                ["02"] = new Day02_Checksum.ChecksumMinMax(),
                ["02b"] = new Day02_Checksum.CheckSumEvenlyDivisible(),
                ["03"] = new Day03_SpiralMemory.SpiralMemory(),
                ["03b"] = new Day03_SpiralMemory.SpiralMemorySumOfAdjacentRegistries(),
                ["04"] = new Day04_Passphrases.Passphrases(true),
                ["04b"] = new Day04_Passphrases.Passphrases(false),
                ["05"] = new Day05_Trampolines.Trampolines(false),
                ["05b"] = new Day05_Trampolines.Trampolines(true),
                ["06"] = new Day06_MemoryReallocation.MemoryReallocation(false),
                ["06b"] = new Day06_MemoryReallocation.MemoryReallocation(true),
                ["07"] = new Day07_RecursiveCircus.RecursiveCircus(false),
                ["07b"] = new Day07_RecursiveCircus.RecursiveCircus(true),
                ["08"] = new Day08_Registers.Registers(false),
                ["08b"] = new Day08_Registers.Registers(true),
                ["09"] = new Day09_StreamProcessing.StreamProcessing(false),
                ["09b"] = new Day09_StreamProcessing.StreamProcessing(true),
                ["10"] = new Day10_KnotHash.KnotHash(false),
                ["10b"] = new Day10_KnotHash.KnotHash(true),
                ["11"] = new Day11_HexGrid.HexGrid(false),
                ["11b"] = new Day11_HexGrid.HexGrid(true),
                ["12"] = new Day12_DigitalPlumber.DigitalPlumber(false),
                ["12b"] = new Day12_DigitalPlumber.DigitalPlumber(true),
                ["13"] = new Day13_PacketScanners.PacketScanners(false),
                ["13b"] = new Day13_PacketScanners.PacketScanners(true),
                ["14"] = new Day14_DiskDefragmentation.DiskDefragmentation(false),
                ["14b"] = new Day14_DiskDefragmentation.DiskDefragmentation(true),
                ["15"] = new Day15_DuelingGenerators.DuelingGenerators(false),
                ["15b"] = new Day15_DuelingGenerators.DuelingGenerators(true),
                ["16"] = new Day16_PermutationPromenade.PermutationPromenade(true),
                ["16b"] = new Day16_PermutationPromenade.PermutationPromenade(false),
                ["17"] = new Day17_Spinlock.Spinlock(false),
                ["17b"] = new Day17_Spinlock.Spinlock(true)
            };
        }

        private static void SolvePuzzle(string dayNumber)
        {
            var puzzleSolver = GetPuzzleSolver(dayNumber);
            var rawInputText = GetRawInputForDay(dayNumber);

            var startTime = DateTime.Now;
            var solution = puzzleSolver.Solve(rawInputText).PrintSolution();
            var duration = DateTime.Now - startTime;

            WriteLine(
                string.Join(
                    "    ",
                    dayNumber.PadLeft(6),
                    duration.TotalMilliseconds.ToString("F2").PadLeft(9),
                    solution));
        }

        private static IPuzzleSolver GetPuzzleSolver(string dayNumber)
        {
            if (_solversDictionary.TryGetValue(dayNumber, out IPuzzleSolver solver))
            {
                return solver;
            }
            else
            {
                throw new Exception($"Day '{dayNumber}' is not yet solved.");
            }
        }

        private static string GetRawInputForDay(string dayNumber)
            => File.ReadAllText($"day{dayNumber.Substring(0, 2)}_input.txt");
    }
}
