using Shared;

namespace Day17_Spinlock
{
    public class SpinlockInput : IPuzzleInput<SpinlockInput>
    {
        public int Step { get; set; }

        public SpinlockInput ParseFromText(string textInput)
        {
            Step = int.Parse(textInput);
            return this;
        }
    }
}