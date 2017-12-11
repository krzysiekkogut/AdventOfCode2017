using System.Linq;
using Shared;

namespace Day02_Checksum
{
    public class ChecksumMinMax : PuzzleSolver<ChecksumInput>
    {
        protected override PuzzleSolution SolveInternal(ChecksumInput input)
        {
            var result = input.Spreadsheet
                .Select(row => (Max: row.Max(), Min: row.Min()))
                .Select(rowMinMax => rowMinMax.Max - rowMinMax.Min)
                .Sum();
            return new ChecksumSolution(result);
        }
    }
}
