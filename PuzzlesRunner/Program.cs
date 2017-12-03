﻿using System;
using System.IO;
using System.Linq;
using Day01_Captcha;
using Day02_Checksum;
using Day03_SpiralMemory;
using Shared;
using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        static void Main()
        {
            WriteLine("Type puzzle number:");
            try
            {
                var dayNumber = ReadLine();
                var puzzleInput = GetPuzzleInput(dayNumber);
                var puzzleSolver = GetPuzzleSolver(dayNumber);
                WriteLine(puzzleSolver.Solve(puzzleInput));
            }
            catch (Exception e)
            {
                WriteLine($"Error occured. Message: {e.Message}");
            }
            finally
            {
                WriteLine("Press any key to finish...");
                ReadKey();
            }
        }

        private static IPuzzleSolver GetPuzzleSolver(string dayNumber)
        {
            switch (dayNumber)
            {
                case "01":
                    return new Captcha();
                case "01b":
                    return new Captcha();
                case "02":
                    return new ChecksumMinMax();
                case "02b":
                    return new CheckSumEvenlyDivisible();
                case "03":
                    return new SpiralMemory();
                default:
                    WriteLine($"Day '{dayNumber}' is not yet solved.");
                    throw new Exception($"Day '{dayNumber}' is not yet solved.");

            }
        }

        private static IPuzzleInput GetPuzzleInput(string dayNumber)
        {
            switch (dayNumber)
            {
                case "01":
                    return new CaptchaInput { Text = File.ReadAllText(GetInputFileName(dayNumber)), IsStepByOne = true } as IPuzzleInput;
                case "01b":
                    return new CaptchaInput { Text = File.ReadAllText(GetInputFileName(dayNumber)), IsStepByOne = false } as IPuzzleInput;
                case "02":
                    return new ChecksumInput { Spreadsheet = File.ReadAllLines(GetInputFileName(dayNumber)).Select(rowText => rowText.Split('\t')).Select(rowCellsText => rowCellsText.Select(cellText => int.Parse(cellText))) } as IPuzzleInput;
                case "02b":
                    return new ChecksumInput { Spreadsheet = File.ReadAllLines(GetInputFileName(dayNumber)).Select(rowText => rowText.Split('\t')).Select(rowCellsText => rowCellsText.Select(cellText => int.Parse(cellText))) } as IPuzzleInput;
                case "03":
                    return new SpiralMemoryInput { RegistryNumber = int.Parse(File.ReadAllText(GetInputFileName(dayNumber))) } as IPuzzleInput;
                default:
                    throw new Exception($"Day '{dayNumber}' is not yet solved.");
            }
        }

        private static string GetInputFileName(string dayNumber) => $"day{dayNumber}_input.txt";
    }
}
