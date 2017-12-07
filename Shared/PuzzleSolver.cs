namespace Shared
{
    public abstract class PuzzleSolver<TIn> : IPuzzleSolver 
        where TIn : class, IPuzzleInput<TIn>
    {
        public IPuzzleSolution Solve(string inputText)
        {
            var input = ParseInput(inputText);
            return SolveInternal(input);
        }

        protected abstract TIn ParseInput(string inputText);
        protected abstract IPuzzleSolution SolveInternal(TIn input);
    }
}
