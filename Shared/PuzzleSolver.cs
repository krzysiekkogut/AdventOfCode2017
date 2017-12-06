namespace Shared
{
    public abstract class PuzzleSolver<T> where T : class, IPuzzleInput<T>
    {
        public int Solve(string inputText)
        {
            var input = ParseInput(inputText);
            return SolveInternal(input);
        }

        protected abstract T ParseInput(string inputText);
        protected abstract int SolveInternal(T input);
    }
}
