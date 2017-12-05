using Shared;

namespace Day05_Trampolines
{
    public class TrampolinesInput : IPuzzleInput
    {
        public int[] Instructions { get; set; }
        public bool DecrementWhenJumpIsThreeOrMore { get; set; }
    }
}