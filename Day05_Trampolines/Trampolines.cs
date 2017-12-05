using Shared;
using System.Linq;

namespace Day05_Trampolines
{
    public class Trampolines : PuzzleSolver<TrampolinesInput>, IPuzzleSolver
    {
        protected override int SolveInternal(TrampolinesInput input)
        {
            var countOfSteps = 0;
            var currentIndex = 0;
            var maxIndex = input.Instructions.Length - 1;

            while (currentIndex >= 0 && currentIndex <= maxIndex)
            {
                var jump = input.Instructions[currentIndex];
                input.Instructions[currentIndex] += input.DecrementWhenJumpIsThreeOrMore && jump >= 3 ? -1 : 1;
                currentIndex += jump;
                countOfSteps++;
            }

            return countOfSteps;
        }
    }
}
