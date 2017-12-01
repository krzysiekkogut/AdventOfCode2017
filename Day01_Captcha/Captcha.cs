namespace Day01_Captcha
{
    public class Captcha
    {
        public static int Solve(string input)
        {
            var result = 0;
            for (var currentPosiion = 0; currentPosiion < input.Length; currentPosiion++)
            {
                var nextPosition = (currentPosiion + 1) % input.Length;
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
