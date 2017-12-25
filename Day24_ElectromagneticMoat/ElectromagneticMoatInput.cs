using Shared;
using System;
using System.Linq;

namespace Day24_ElectromagneticMoat
{
    public class ElectromagneticMoatInput : IPuzzleInput<ElectromagneticMoatInput>
    {
        internal Tuple<int, int>[] Elements { get; set; }

        public ElectromagneticMoatInput ParseFromText(string textInput)
        {
            Elements = textInput
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(elementText =>
                {
                    var split = elementText.Split('/');
                    return Tuple.Create(int.Parse(split[0]), int.Parse(split[1]));
                })
                .ToArray();

            return this;
        }
    }
}