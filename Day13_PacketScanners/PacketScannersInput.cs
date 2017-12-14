using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13_PacketScanners
{
    public class PacketScannersInput : IPuzzleInput<PacketScannersInput>
    {
        internal IList<Scanner> Scanners { get; set; }

        public PacketScannersInput ParseFromText(string textInput)
        {
            Scanners = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(scannerText =>
                    {
                        var splittedScannerText = scannerText.Split(':');
                        return new Scanner
                        {
                            Depth = int.Parse(splittedScannerText[0].Trim()),
                            Range = int.Parse(splittedScannerText[1].Trim())
                        };
                    })
                .ToList();
            return this;
        }
    }
}