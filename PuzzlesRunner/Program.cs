using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        static void Main()
        {
            var dayNumber = ReadLine();

            WriteLine(new Func<string>(() =>
            {
                switch (dayNumber)
                {
                    case "01":
                        return Solve(
                            File.ReadAllText(GetInputFileName(dayNumber)),
                            input => Day01_Captcha.Captcha.Solve(input));
                    case "01b":
                        return Solve(
                            File.ReadAllText(GetInputFileName(dayNumber.Substring(0, 2))),
                            input => Day01_Captcha.Captcha.Solve(input, input.Length / 2));
                    case "02":
                        return Solve(
                            File.ReadAllLines(GetInputFileName(dayNumber)).Select(rowText => rowText.Split('\t')).Select(rowCellsText => rowCellsText.Select(cellText => int.Parse(cellText))),
                            input => Day02_Checksum.Checksum.Solve(input));
                    default:
                        return $"Day '{dayNumber}' is not yet solved.";
                }
            })());

            WriteLine("Press any key to finish...");
            ReadKey();
        }

        private static string GetInputFileName(string dayNumber) => $"day{dayNumber}_input.txt";

        static string Solve<TIn, TOut>(TIn input, Func<TIn, TOut> solver) => solver(input).ToString();
    }
}
