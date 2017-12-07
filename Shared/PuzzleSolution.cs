namespace Shared
{
    public abstract class PuzzleSolution<T> : IPuzzleSolution
    {
        protected T _result;

        public PuzzleSolution(T result)
        {
            _result = result;
        }

        public virtual string PrintSolution()
        {
            return _result.ToString();
        }
    }
}
