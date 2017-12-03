using Shared;

namespace Day01_Captcha
{
    public class CaptchaInput : IPuzzleInput
    {
        public string Text { get; set; }

        public bool IsStepByOne { get; set; }

        public int Step => IsStepByOne ? 1 : Text.Length / 2;
    }
}