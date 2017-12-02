namespace Day01_Captcha
{
    public class Captcha
    {
        public static int Solve(string input, int step = 1)
        {
            var result = 0;
            for (var currentPosiion = 0; currentPosiion < input.Length; currentPosiion++)
            {
                var nextPosition = (currentPosiion + step) % input.Length;
                var currentDigit = int.Parse(input[currentPosiion].ToString());
                var nextDigit = int.Parse(input[nextPosition].ToString());
                if (currentDigit == nextDigit)
                {
                    result += currentDigit;
                }
            }

            return result;
        }
    }
}
