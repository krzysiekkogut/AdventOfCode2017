using Shared;

namespace Day07_RecursiveCircus
{
    internal class RecursiveCircusSolution : PuzzleSolution<(string BottomProgramName, int CorrectProgramWeight)>
    {
        private readonly bool _showCorrectProgramWeight;

        public RecursiveCircusSolution(
            (string BottomProgramName, int CorrectProgramWeight) result,
            bool showCorrectProgramWeight)
        : base(result)
        {
            _showCorrectProgramWeight = showCorrectProgramWeight;
        }

        public override string PrintSolution()
        {
            return _showCorrectProgramWeight ? _result.CorrectProgramWeight.ToString() : _result.BottomProgramName;
        }
    }
}