using System;
using System.IO;
using System.Linq;
using Day01_Captcha;
using Day02_Checksum;
using Day03_SpiralMemory;
using Day04_Passphrases;
using Day05_Trampolines;
using Day06_MemoryReallocation;
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
                    WriteLine(puzzleSolver.Solve(GetRawInputForDay(dayNumber)));
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
                    return new Captcha(true);
                case "01b":
                    return new Captcha(false);
                case "02":
                    return new ChecksumMinMax();
                case "02b":
                    return new CheckSumEvenlyDivisible();
                case "03":
                    return new SpiralMemory();
                case "03b":
                    return new SpiralMemorySumOfAdjacentRegistries();
                case "04":
                    return new Passphrases(true);
                case "04b":
                    return new Passphrases(false);
                case "05":
                    return new Trampolines(false);
                case "05b":
                    return new Trampolines(true);
                case "06":
                    return new MemoryReallocation(false);
                case "06b":
                    return new MemoryReallocation(true);
                default:
                    WriteLine($"Day '{dayNumber}' is not yet solved.");
                    throw new Exception($"Day '{dayNumber}' is not yet solved.");
            }
        }

        private static string GetRawInputForDay(string dayNumber) => File.ReadAllText($"day{dayNumber.Substring(0, 2)}_input.txt");
    }
}
