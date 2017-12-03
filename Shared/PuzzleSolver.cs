namespace Shared
{
    public abstract class PuzzleSolver<T> where T : class, IPuzzleInput
    {
        public T CastInput(IPuzzleInput input)
        {
            return input as T;
        }

        public int Solve(IPuzzleInput input)
        {
            var castedInput = CastInput(input);
            return SolveInternal(castedInput);
        }

        protected abstract int SolveInternal(T input);
    }
}
