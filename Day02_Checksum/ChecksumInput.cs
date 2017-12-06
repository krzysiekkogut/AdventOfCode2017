using System.Collections.Generic;
using Shared;
using System;
using System.Linq;

namespace Day02_Checksum
{
    public class ChecksumInput : IPuzzleInput<ChecksumInput>
    {
        public IEnumerable<IEnumerable<int>> Spreadsheet { get; set; }

        public ChecksumInput ParseFromText(string textInput)
        {
            Spreadsheet = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(rowText => rowText.Split('\t'))
                            .Select(rowCellsText => rowCellsText.Select(cellText => int.Parse(cellText)));
            return this;
        }
    }
}
