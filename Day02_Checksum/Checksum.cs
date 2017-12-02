using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02_Checksum
{
    public class Checksum
    {
        public static int SolveMinMax(IEnumerable<IEnumerable<int>> spreadsheet)
        {
            return spreadsheet
                .Select(row => (Max: row.Max(), Min: row.Min()))
                .Select(rowMinMax => rowMinMax.Max - rowMinMax.Min)
                .Sum();
        }

        public static int SolveEvenlyDivisible(IEnumerable<IEnumerable<int>> spreadsheet)
        {
            return spreadsheet
                .Select(row =>
                {
                    var cells = row.ToArray();
                    for (var i = 0; i < cells.Length; i++)
                    {
                        for (var j = 0; j < cells.Length; j++)
                        {
                            if (i == j)
                            {
                                continue;
                            }

                            var dividend = cells[i];
                            var divider = cells[j];
                            if (divider == 0)
                            {
                                continue;
                            }

                            if (dividend % divider == 0)
                            {
                                return dividend / divider;
                            }
                        }
                    }

                    throw new Exception("Wrong input.");
                })
                .Sum();
        }
    }
}
