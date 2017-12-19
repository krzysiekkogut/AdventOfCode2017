using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Shared;
using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        private static IDictionary<string, (Type solverType, object[] args)> _solversDictionary;

        static Program()
        {
            _solversDictionary = new Dictionary<string, (Type solverType, object[] args)>
            {
                ["01"] = (typeof(Day01_Captcha.Captcha), new object[] { true }),
                ["01b"] = (typeof(Day01_Captcha.Captcha), new object[] { false }),
                ["02"] = (typeof(Day02_Checksum.ChecksumMinMax), new object[] { }),
                ["02b"] = (typeof(Day02_Checksum.CheckSumEvenlyDivisible), new object[] { }),
                ["03"] = (typeof(Day03_SpiralMemory.SpiralMemory), new object[] { }),
                ["03b"] = (typeof(Day03_SpiralMemory.SpiralMemorySumOfAdjacentRegistries), new object[] { }),
                ["04"] = (typeof(Day04_Passphrases.Passphrases), new object[] { true }),
                ["04b"] = (typeof(Day04_Passphrases.Passphrases), new object[] { false }),
                ["05"] = (typeof(Day05_Trampolines.Trampolines), new object[] { false }),
                ["05b"] = (typeof(Day05_Trampolines.Trampolines), new object[] { true }),
                ["06"] = (typeof(Day06_MemoryReallocation.MemoryReallocation), new object[] { false }),
                ["06b"] = (typeof(Day06_MemoryReallocation.MemoryReallocation), new object[] { true }),
                ["07"] = (typeof(Day07_RecursiveCircus.RecursiveCircus), new object[] { false }),
                ["07b"] = (typeof(Day07_RecursiveCircus.RecursiveCircus), new object[] { true }),
                ["08"] = (typeof(Day08_Registers.Registers), new object[] { false }),
                ["08b"] = (typeof(Day08_Registers.Registers), new object[] { true }),
                ["09"] = (typeof(Day09_StreamProcessing.StreamProcessing), new object[] { false }),
                ["09b"] = (typeof(Day09_StreamProcessing.StreamProcessing), new object[] { true }),
                ["10"] = (typeof(Day10_KnotHash.KnotHash), new object[] { false }),
                ["10b"] = (typeof(Day10_KnotHash.KnotHash), new object[] { true }),
                ["11"] = (typeof(Day11_HexGrid.HexGrid), new object[] { false }),
                ["11b"] = (typeof(Day11_HexGrid.HexGrid), new object[] { true }),
                ["12"] = (typeof(Day12_DigitalPlumber.DigitalPlumber), new object[] { false }),
                ["12b"] = (typeof(Day12_DigitalPlumber.DigitalPlumber), new object[] { true }),
                ["13"] = (typeof(Day13_PacketScanners.PacketScanners), new object[] { false }),
                ["13b"] = (typeof(Day13_PacketScanners.PacketScanners), new object[] { true }),
                ["14"] = (typeof(Day14_DiskDefragmentation.DiskDefragmentation), new object[] { false }),
                ["14b"] = (typeof(Day14_DiskDefragmentation.DiskDefragmentation), new object[] { true }),
                ["15"] = (typeof(Day15_DuelingGenerators.DuelingGenerators), new object[] { false }),
                ["15b"] = (typeof(Day15_DuelingGenerators.DuelingGenerators), new object[] { true }),
                ["16"] = (typeof(Day16_PermutationPromenade.PermutationPromenade), new object[] { true }),
                ["16b"] = (typeof(Day16_PermutationPromenade.PermutationPromenade), new object[] { false }),
                ["17"] = (typeof(Day17_Spinlock.Spinlock), new object[] { false }),
                ["17b"] = (typeof(Day17_Spinlock.Spinlock), new object[] { true }),
                ["18"] = (typeof(Day18_Duet.Duet), new object[] { false }),
                ["18b"] = (typeof(Day18_Duet.Duet), new object[] { true }),
                ["19"] = (typeof(Day19_SeriesOfTubes.SeriesOfTubes), new object[] { true }),
                ["19b"] = (typeof(Day19_SeriesOfTubes.SeriesOfTubes), new object[] { false })
            };
        }

        static void Main()
        {
            while (true)
            {
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
            if (_solversDictionary.TryGetValue(dayNumber, out var solverDefinition))
            {
                return Activator.CreateInstance(solverDefinition.solverType, BindingFlags.CreateInstance, null, solverDefinition.args, null) as IPuzzleSolver;
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
