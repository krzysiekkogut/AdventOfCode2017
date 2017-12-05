using System;
using System.IO;
using System.Linq;
using Day01_Captcha;
using Day02_Checksum;
using Day03_SpiralMemory;
using Shared;
using static System.Console;
using Day04_Passphrases;
using Day05_Trampolines;

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
                case "01b":
                    return new Captcha();
                case "02":
                    return new ChecksumMinMax();
                case "02b":
                    return new CheckSumEvenlyDivisible();
                case "03":
                    return new SpiralMemory();
                case "03b":
                    return new SpiralMemorySumOfAdjacentRegistries();
                case "04":
                case "04b":
                    return new Passphrases();
                case "05":
                case "05b":
                    return new Trampolines();
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
                    return new CaptchaInput
                    {
                        Text = File.ReadAllText(GetInputFileName(dayNumber)),
                        IsStepByOne = true
                    } as IPuzzleInput;
                case "01b":
                    return new CaptchaInput
                    {
                        Text = File.ReadAllText(GetInputFileName(dayNumber)),
                        IsStepByOne = false
                    } as IPuzzleInput;
                case "02":
                case "02b":
                    return new ChecksumInput
                    {
                        Spreadsheet =
                            File.ReadAllLines(GetInputFileName(dayNumber))
                            .Select(rowText => rowText.Split('\t'))
                            .Select(rowCellsText => rowCellsText.Select(cellText => int.Parse(cellText)))
                    } as IPuzzleInput;
                case "03":
                case "03b":
                    return new SpiralMemoryInput
                    {
                        RegistryNumber = int.Parse(File.ReadAllText(GetInputFileName(dayNumber)))
                    } as IPuzzleInput;
                case "04":
                    return new PassphrasesInput
                    {
                        Passphrases = File.ReadAllLines(GetInputFileName(dayNumber)).Select(passphraseText => passphraseText.Split(' ')),
                        AreAnagramsAllowed = true
                    };
                case "04b":
                    return new PassphrasesInput
                    {
                        Passphrases = File.ReadAllLines(GetInputFileName(dayNumber)).Select(passphraseText => passphraseText.Split(' ')),
                        AreAnagramsAllowed = false
                    };
                case "05":
                    return new TrampolinesInput
                    {
                        Instructions = File.ReadAllLines(GetInputFileName(dayNumber)).Select(instructionText => int.Parse(instructionText)).ToArray(),
                        DecrementWhenJumpIsThreeOrMore = false
                    };
                case "05b":
                    return new TrampolinesInput
                    {
                        Instructions = File.ReadAllLines(GetInputFileName(dayNumber)).Select(instructionText => int.Parse(instructionText)).ToArray(),
                        DecrementWhenJumpIsThreeOrMore = true
                    };
                default:
                    throw new Exception($"Day '{dayNumber}' is not yet solved.");
            }
        }

        private static string GetInputFileName(string dayNumber) => $"day{dayNumber}_input.txt";
    }
}
