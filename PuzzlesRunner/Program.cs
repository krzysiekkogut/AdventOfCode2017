using static System.Console;

namespace PuzzlesRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var dayNumber = args[0];
            var input = args[1];
            switch (dayNumber)
            {
                case "01":
                    WriteLine(Day01_Captcha.Captcha.Solve(input));
                    break;
                case "01b":
                    WriteLine(Day01_Captcha.Captcha.Solve(input, input.Length / 2));
                    break;
                default:
                    WriteLine($"Day '{dayNumber}' is not yet solved.");
                    break;
            }

            WriteLine("Press any key to finish...");
            ReadKey();
        }
    }
}
