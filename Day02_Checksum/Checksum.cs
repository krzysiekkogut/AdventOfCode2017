using System.Collections.Generic;
using System.Linq;

namespace Day02_Checksum
{
    public class Checksum
    {
        public static int Solve(IEnumerable<IEnumerable<int>> spreadsheet)
        {
            return spreadsheet
                .Select(row => (Max: row.Max(), Min: row.Min()))
                .Select(rowMinMax => rowMinMax.Max - rowMinMax.Min)
                .Sum();
        }
    }
}
