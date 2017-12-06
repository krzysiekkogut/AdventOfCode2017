using Shared;

namespace Day01_Captcha
{
    public class CaptchaInput : IPuzzleInput<CaptchaInput>
    {
        public string Text { get; set; }

        public int Step(bool isStepByOne) => isStepByOne ? 1 : Text.Length / 2;

        public CaptchaInput ParseFromText(string textInput)
        {
            Text = textInput;
            return this;
        }
    }
}