using Shared;

namespace Day05_Trampolines
{
    public class Trampolines : PuzzleSolver<TrampolinesInput>, IPuzzleSolver
    {
        private bool _decrementWhenJumpIsThreeOrMore;

        public Trampolines(bool decrementWhenJumpIsThreeOrMore)
        {
            _decrementWhenJumpIsThreeOrMore = decrementWhenJumpIsThreeOrMore;
        }

        protected override TrampolinesInput ParseInput(string inputText)
        {
            return new TrampolinesInput().ParseFromText(inputText);
        }

        protected override int SolveInternal(TrampolinesInput input)
        {
            var countOfSteps = 0;
            var currentIndex = 0;
            var maxIndex = input.Instructions.Length - 1;

            while (currentIndex >= 0 && currentIndex <= maxIndex)
            {
                var jump = input.Instructions[currentIndex];
                input.Instructions[currentIndex] += _decrementWhenJumpIsThreeOrMore && jump >= 3 ? -1 : 1;
                currentIndex += jump;
                countOfSteps++;
            }

            return countOfSteps;
        }
    }
}
