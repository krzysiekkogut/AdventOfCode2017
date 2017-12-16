using System;
using System.IO;
using Shared;
using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                WriteLine("Type puzzle number or 'exit':");
                try
                {
                    var dayNumber = ReadLine();
                    if (dayNumber.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }

                    var puzzleSolver = GetPuzzleSolver(dayNumber);
                    WriteLine(
                        puzzleSolver
                        .Solve(GetRawInputForDay(dayNumber))
                        .PrintSolution());
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

        private static IPuzzleSolver GetPuzzleSolver(string dayNumber)
        {
            switch (dayNumber)
            {
                case "01":
                    return new Day01_Captcha.Captcha(true);
                case "01b":
                    return new Day01_Captcha.Captcha(false);
                case "02":
                    return new Day02_Checksum.ChecksumMinMax();
                case "02b":
                    return new Day02_Checksum.CheckSumEvenlyDivisible();
                case "03":
                    return new Day03_SpiralMemory.SpiralMemory();
                case "03b":
                    return new Day03_SpiralMemory.SpiralMemorySumOfAdjacentRegistries();
                case "04":
                    return new Day04_Passphrases.Passphrases(true);
                case "04b":
                    return new Day04_Passphrases.Passphrases(false);
                case "05":
                    return new Day05_Trampolines.Trampolines(false);
                case "05b":
                    return new Day05_Trampolines.Trampolines(true);
                case "06":
                    return new Day06_MemoryReallocation.MemoryReallocation(false);
                case "06b":
                    return new Day06_MemoryReallocation.MemoryReallocation(true);
                case "07":
                    return new Day07_RecursiveCircus.RecursiveCircus(false);
                case "07b":
                    return new Day07_RecursiveCircus.RecursiveCircus(true);
                case "08":
                    return new Day08_Registers.Registers(false);
                case "08b":
                    return new Day08_Registers.Registers(true);
                case "09":
                    return new Day09_StreamProcessing.StreamProcessing(false);
                case "09b":
                    return new Day09_StreamProcessing.StreamProcessing(true);
                case "10":
                    return new Day10_KnotHash.KnotHash(false);
                case "10b":
                    return new Day10_KnotHash.KnotHash(true);
                case "11":
                    return new Day11_HexGrid.HexGrid(false);
                case "11b":
                    return new Day11_HexGrid.HexGrid(true);
                case "12":
                    return new Day12_DigitalPlumber.DigitalPlumber(false);
                case "12b":
                    return new Day12_DigitalPlumber.DigitalPlumber(true);
                case "13":
                    return new Day13_PacketScanners.PacketScanners(false);
                case "13b":
                    return new Day13_PacketScanners.PacketScanners(true);
                case "14":
                    return new Day14_DiskDefragmentation.DiskDefragmentation(false);
                case "14b":
                    return new Day14_DiskDefragmentation.DiskDefragmentation(true);
                case "15":
                    return new Day15_DuelingGenerators.DuelingGenerators(false);
                case "15b":
                    return new Day15_DuelingGenerators.DuelingGenerators(true);
                case "16":
                    return new Day16_PermutationPromenade.PermutationPromenade(true);
                case "16b":
                    return new Day16_PermutationPromenade.PermutationPromenade(false);
                default:
                    WriteLine($"Day '{dayNumber}' is not yet solved.");
                    throw new Exception($"Day '{dayNumber}' is not yet solved.");
            }
        }

        private static string GetRawInputForDay(string dayNumber) => File.ReadAllText($"day{dayNumber.Substring(0, 2)}_input.txt");
    }
}
