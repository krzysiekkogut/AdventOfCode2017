using Shared;
using System;

namespace Day15_DuelingGenerators
{
    public class DuelingGeneratorsInput : IPuzzleInput<DuelingGeneratorsInput>
    {
        private const string introduction = "Generator A starts with ";

        public long InititalValueA { get; set; }
        public long InititalValueB { get; set; }

        public DuelingGeneratorsInput ParseFromText(string textInput)
        {
            var splitText = textInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            InititalValueA = int.Parse(splitText[0].Substring(introduction.Length));
            InititalValueB = int.Parse(splitText[1].Substring(introduction.Length));
            return this;
        }
    }
}