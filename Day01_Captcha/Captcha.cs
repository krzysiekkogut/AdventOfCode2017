using Shared;

namespace Day01_Captcha
{
    public class Captcha : PuzzleSolver<CaptchaInput>
    {
        private bool _isStepByOne;

        public Captcha(bool isStepByOne)
        {
            _isStepByOne = isStepByOne;
        }

        protected override IPuzzleSolution SolveInternal(CaptchaInput input)
        {
            var result = 0;
            for (var currentPosiion = 0; currentPosiion < input.Text.Length; currentPosiion++)
            {
                var nextPosition = (currentPosiion + input.Step(_isStepByOne)) % input.Text.Length;
                var currentDigit = int.Parse(input.Text[currentPosiion].ToString());
                var nextDigit = int.Parse(input.Text[nextPosition].ToString());
                if (currentDigit == nextDigit)
                {
                    result += currentDigit;
                }
            }

            return new CaptchaSolution(result);
        }
    }
}
