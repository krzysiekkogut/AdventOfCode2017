using Shared;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace Day10_KnotHash
{
    public class KnotHashInput : IPuzzleInput<KnotHashInput>
    {
        public IList<int> KnotLengths { get; private set; }
        public IList<int> KnotLengthsFromASCII { get; private set; }

        public KnotHashInput ParseFromText(string textInput)
        {
            KnotLengthsFromASCII =
                Encoding.ASCII
                .GetBytes(textInput)
                .Concat(new byte[] { 17, 31, 73, 47, 23 })
                .Select(b => Convert.ToInt32(b))
                .ToList();
            KnotLengths =
                textInput
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(lengthText =>
                {
                    int.TryParse(lengthText, out int knotLength);
                    return knotLength;
                })
                .ToList();
            return this;
        }
    }
}