using Shared;

namespace Day01_Captcha
{
    public class Captcha : PuzzleSolver<CaptchaInput>, IPuzzleSolver
    {
        protected override int SolveInternal(CaptchaInput input)
        {
            var result = 0;
            for (var currentPosiion = 0; currentPosiion < input.Text.Length; currentPosiion++)
            {
                var nextPosition = (currentPosiion + input.Step) % input.Text.Length;
                var currentDigit = int.Parse(input.Text[currentPosiion].ToString());
                var nextDigit = int.Parse(input.Text[nextPosition].ToString());
                if (currentDigit == nextDigit)
                {
                    result += currentDigit;
                }
            }

            return result;
        }
    }
}
