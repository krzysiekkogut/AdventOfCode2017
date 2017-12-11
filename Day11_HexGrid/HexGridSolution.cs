using Shared;

namespace Day11_HexGrid
{
    internal class HexGridSolution : PuzzleSolution<(int DistanceToStart, int MaxSteps)>
    {
        private readonly bool _showMaxSteps;

        public HexGridSolution(
            (int DistanceToStart, int MaxSteps) result,
            bool showMaxSteps)
            : base(result)
        {
            _showMaxSteps = showMaxSteps;
        }

        public override string PrintSolution()
        {
            return _showMaxSteps ? _result.MaxSteps.ToString() : _result.DistanceToStart.ToString();
        }
    }
}