using System.Collections.Generic;
using Shared;

namespace Day02_Checksum
{
    public class ChecksumInput : IPuzzleInput
    {
        public IEnumerable<IEnumerable<int>> Spreadsheet { get; set; }
    }
}
