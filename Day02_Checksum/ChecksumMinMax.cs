using System.Linq;
using Shared;

namespace Day02_Checksum 
{
    public class ChecksumMinMax : PuzzleSolver<ChecksumInput>, IPuzzleSolver
    {
        protected override int SolveInternal(ChecksumInput input)
        {
            return input.Spreadsheet
                .Select(row => (Max: row.Max(), Min: row.Min()))
                .Select(rowMinMax => rowMinMax.Max - rowMinMax.Min)
                .Sum();
        }
    }
}
