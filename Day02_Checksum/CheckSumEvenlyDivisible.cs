using System;
using System.Linq;
using Shared;

namespace Day02_Checksum
{
    public class CheckSumEvenlyDivisible : PuzzleSolver<ChecksumInput>
    {
        protected override PuzzleSolution SolveInternal(ChecksumInput input)
        {
            var result = input.Spreadsheet
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

            return new ChecksumSolution(result);
        }
    }
}
